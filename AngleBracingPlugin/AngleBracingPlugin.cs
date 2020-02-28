using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleBracingPlugin.Modeler_Classes;

// Tekla Structures Namespaces
using TSM = Tekla.Structures.Model;
using TSD = Tekla.Structures.Dialog;
using TSDT = Tekla.Structures.Datatype;
using T3D = Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Tekla.Structures.Model.Operations;


namespace AngleBracingPlugin
{
    class StructuresData
    {
        [StructuresField("AngleBracingType")]
        public int AngleBracingType;
        [StructuresField("AngleBracingProfile")]
        public int AngleBracingProfile;
        [StructuresField("AnglePosition")]
        public int AnglePosition;
        [StructuresField("AngleOffset")]
        public string AngleOffset;
        [StructuresField("FirstOffset")]
        public string FirstOffset;
        [StructuresField("SecondOffset")]
        public string SecondOffset;
        [StructuresField("ThirdOffset")]
        public string ThirdOffset;
        [StructuresField("FourthOffset")]
        public string FourthOffset;
        [StructuresField("BoltQty")]
        public string BoltQty;
    }

    [Plugin("AngleBracingPlugin")] // Mandatory field which defines that the class is a plug-in-and stores the name of the plug-in to the system.
    [PluginUserInterface("AngleBracingPlugin.Form1")] // Mandatory field which defines the user interface the plug-in uses - A windows form class
    class AngleBracingPlugin : PluginBase
    {

        private StructuresData Data { get; set; }

        // fields for AngleBracingPlugin class
        private string[] _angleType = { "L3X3X1/4", "L4X4X3/8", "L5X5X1/2" };
        private int _angleBracingType;
        private int _angleBracingProfile;
        private int _anglePosition;
        private int _boltQty;
        private double _boltSize = 19.05;
        private double _boltDX = 38.1;
        private double _boltDy;
        private double _boltSpacing = 76.2;
        private double _angleOffset;
        private double _firstOffset;
        private double _secondOffset;
        private double _thirdOffset;
        private double _fourthOffset;
        private double _angleWidth;
        private string _angleProfile;
        private TSM.ContourPlate _plate1;
        private TSM.ContourPlate _plate2;
        private TSM.ContourPlate _plate3;
        private TSM.ContourPlate _plate4;
        private T3D.Point _point1;
        private T3D.Point _point2;
        private T3D.Point _point3;
        private T3D.Point _point4;
        private TSM.Model _classModel;
        private TSM.TransformationPlane _originalPlane;
        


        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public AngleBracingPlugin(StructuresData data)
        {
            
            Data = data;
            _classModel = new TSM.Model();

            // pass fields from Structures Data into AngleBracingPlugin class
            _angleBracingType = data.AngleBracingType;
            _anglePosition = data.AnglePosition;
            _angleBracingProfile = data.AngleBracingProfile;

            // Convert string offset values to double
            if (!Double.TryParse(data.AngleOffset, out _angleOffset))
            {
                _angleOffset = 0.0; // Default offset to 0 if parse fails
            }

            if (!Double.TryParse(data.FirstOffset, out _firstOffset))
            {
                _firstOffset = 0.0; // Default offset to 0 if parse fails
            }

            if (!Double.TryParse(data.SecondOffset, out _secondOffset))
            {
                _secondOffset = 0.0; // Default offset to 0 if parse fails
            }

            if (!Double.TryParse(data.ThirdOffset, out _thirdOffset))
            {
                _thirdOffset = 0.0; // Default offset to 0 if parse fails
            }

            if (!Double.TryParse(data.FourthOffset, out _fourthOffset))
            {
                _fourthOffset = 0.0; // Default offset to 0 if parse fails
            }

           
            if (!Int32.TryParse(data.BoltQty, out _boltQty))
            {
                _boltQty = 1; // Default bolt quantity to 1 if parse fails
            }     

            // Assign profile for angle
            try
            {
                _angleProfile = _angleType[_angleBracingProfile];
            }
            catch(IndexOutOfRangeException ex)
            {
                _angleProfile = _angleType[0];
            }
            catch(Exception ex)
            {
                _angleProfile = _angleType[0];
            }

            if (!Double.TryParse(_angleProfile.Substring(1, 1), out _angleWidth))
            {
                _angleWidth = 0.0;
            }
            else
            {
                _angleWidth *= 25.4;
            }

            _originalPlane = _classModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
        }


        public override List<InputDefinition> DefineInput()
        {
           
            // create new instance of TSMUI.Picker and input definition list
            TSMUI.Picker anglePicker = new TSMUI.Picker();
            List<InputDefinition> InputList = new List<InputDefinition>();
            // create array list to hold plates for input
            ArrayList PlateList = new ArrayList();

            try
            {
               

                // Prompt user to pick 4 plates 
                _plate1 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
                _plate2 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
                _plate3 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
                _plate4 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
              
                // Get coordinate system for first plate
                _classModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TSM.TransformationPlane(_plate1.GetCoordinateSystem()));

                // Prompt user to pick points
                _point1 = anglePicker.PickPoint() as T3D.Point;
                _point2 = anglePicker.PickPoint() as T3D.Point;
                _point3 = anglePicker.PickPoint() as T3D.Point;
                _point4 = anglePicker.PickPoint() as T3D.Point;

                // Add plates to array list
                PlateList.Add(_plate1.Identifier);
                PlateList.Add(_plate2.Identifier);
                PlateList.Add(_plate3.Identifier);
                PlateList.Add(_plate4.Identifier);

                // Create inputs to InputDefinition list.
                InputDefinition Input1 = new InputDefinition(_point1);
                InputDefinition Input2 = new InputDefinition(_point2);
                InputDefinition Input3 = new InputDefinition(_point3);
                InputDefinition Input4 = new InputDefinition(_point4);
                InputDefinition Input5 = new InputDefinition(PlateList);                

                // Add inputs to InputDefinition list.
                InputList.Add(Input1);
                InputList.Add(Input2);
                InputList.Add(Input3);
                InputList.Add(Input4);
                InputList.Add(Input5);

            }
            catch (Exception ex)
            {
                throw;
            }                                  

            return InputList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            // Fields for Run method
            List<T3D.Point> firstAnglePoints;
            List<T3D.Point> secondAnglePoints;
            List<T3D.Point> thirdAnglePoints;
            List<T3D.Point> fourthAnglePoints;
            List<T3D.Point> offsetPoints;
           double angleOnPlaneOffset;
            double distanceToCenter;

            try
            {                            
                // Get T3D Points from Input
                T3D.Point firstPoint = (T3D.Point)Input.ElementAt(0).GetInput();
                T3D.Point secondPoint = (T3D.Point)Input.ElementAt(1).GetInput();
                T3D.Point thirdPoint = (T3D.Point)Input.ElementAt(2).GetInput();
                T3D.Point fourthPoint = (T3D.Point)Input.ElementAt(3).GetInput();
                T3D.Point centerPoint = new T3D.Point();
                ArrayList PlateList = (ArrayList)Input.ElementAt(4).GetInput();

                // Use plate Identifiers from PlateList to obtain plates for bolting connection
                if (PlateList != null && PlateList.Count == 4)
                {                   
                    _plate1 = _classModel.SelectModelObject(PlateList[0] as Tekla.Structures.Identifier) as TSM.ContourPlate;
                    _plate2 = _classModel.SelectModelObject(PlateList[1] as Tekla.Structures.Identifier) as TSM.ContourPlate;
                    _plate3 = _classModel.SelectModelObject(PlateList[2] as Tekla.Structures.Identifier) as TSM.ContourPlate;
                    _plate4 = _classModel.SelectModelObject(PlateList[3] as Tekla.Structures.Identifier) as TSM.ContourPlate;
                }

                // Trim points
                AngleModelingUtil angleModelingUtil = new AngleModelingUtil();
                firstAnglePoints = angleModelingUtil.TrimPoints(firstPoint, (_firstOffset * 25.4), thirdPoint, (_thirdOffset * 25.4));
                secondAnglePoints = angleModelingUtil.TrimPoints(fourthPoint, (_fourthOffset * 25.4), secondPoint, (_secondOffset * 25.4));

                if (_angleBracingType == 0)
                {
                    // Create angle objects and set position
                    AngleModeler firstAngle = new AngleModeler(_classModel);
                    firstAngle.SetOnPlanePosition(1);
                    firstAngle.SetRotationPosition(0);
                    firstAngle.SetDepthPosition(1);
                    
                    angleOnPlaneOffset = (_angleWidth - (_angleOffset * 25.4)) * -1;

                    // Adjust angle offset
                    if (_anglePosition == 0)
                    { 
                        firstAngle.SetOnPlaneOffset((_angleWidth / 2) * -1);
                    }
                    else
                    {                        
                        firstAngle.SetOnPlaneOffset(angleOnPlaneOffset);
                    }

                    // Second angle
                    AngleModeler secondAngle = new AngleModeler(_classModel);
                    secondAngle.SetOnPlanePosition(1);
                    secondAngle.SetRotationPosition(0);
                    secondAngle.SetDepthPosition(1);
                    secondAngle.SetRotationOffset(180);
                    

                    // Adjust angle offset
                    if (_anglePosition == 0)
                    {
                        secondAngle.SetOnPlaneOffset((_angleWidth / 2) * -1);
                    }
                    else
                    {
                        secondAngle.SetOnPlaneOffset(angleOnPlaneOffset);
                    }

                    // Model angles
                    T3D.Point firstAngleStart = firstAnglePoints.ElementAt(0);
                    T3D.Point firstAngleFinish = firstAnglePoints.ElementAt(1);
                    T3D.Point secondAngleStart = secondAnglePoints.ElementAt(0);
                    T3D.Point secondAngleFinish = secondAnglePoints.ElementAt(1);
                    firstAngle.ModelAngle(firstAngleStart, firstAngleFinish, _angleProfile, false);
                    secondAngle.ModelAngle(secondAngleStart, secondAngleFinish, _angleProfile, false);

                    // Generate bolts
                    AngleBolts firstAngleBolts1 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts firstAngleBolts2 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts secondAngleBolts1 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts secondAngleBolts2 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts centerBolt = new AngleBolts(_classModel, _boltSize, 1);

                    // If angle is centered, set offset to 0
                    if (_anglePosition == 0)
                    {
                        _boltDy = 0;
                    }
                    else
                    {
                        _boltDy = angleOnPlaneOffset + (_angleWidth / 2);
                    }

                    

                    // If angle is centered, set offset to 0
                    if (_anglePosition == 0)
                    {
                        
                        // Find center point for center bolt
                        centerPoint = angleModelingUtil.CenterPoint(firstPoint, secondPoint, thirdPoint, fourthPoint);

                        // Bolt center bolt
                        distanceToCenter = Math.Sqrt(Math.Pow((centerPoint.X - firstPoint.X), 2) + Math.Pow(centerPoint.Y - firstPoint.Y, 2));
                        centerBolt.BoltAngle(firstAnglePoints.ElementAt(0), firstAnglePoints.ElementAt(1), 0.0, distanceToCenter, (-1 * _boltDy), firstAngle.getBeam());
                    }
                    else
                    {
                        //PROBLEM EXISTS SOMEWHERE IN THIS METHOD!!!
                        ////////////////////////////////////////////////
                        // Find center point for center bolt
                        centerPoint = angleModelingUtil.CenterPoint(firstPoint, secondPoint, thirdPoint, fourthPoint);
                        centerPoint = angleModelingUtil.OffsetCenter(firstAngleStart, firstAngleFinish, secondAngleStart, secondAngleFinish, centerPoint, _angleWidth, (_angleOffset * 25.4));
                        // Bolt center bolt
                        distanceToCenter = Math.Sqrt(Math.Pow((centerPoint.X - firstPoint.X), 2) + Math.Pow(centerPoint.Y - firstPoint.Y, 2));
                        centerBolt.BoltAngle(firstAngleStart, firstAngleFinish, 0.0, distanceToCenter, (-1 * _boltDy), firstAngle.getBeam());
                        ///////////////////////////////////////////////////
                        ///////////////////////////////////////////////////
                    }

                    // Bolt angles to plates
                    firstAngleBolts1.BoltAngle(firstAngleStart, firstAngleFinish, _boltSpacing, _boltDX, (-1 * _boltDy), firstAngle.getBeam(), _plate1);
                    firstAngleBolts2.BoltAngle(firstAngleFinish, firstAngleStart, _boltSpacing, _boltDX, _boltDy, firstAngle.getBeam(), _plate3);
                    secondAngleBolts1.BoltAngle(secondAngleStart, secondAngleFinish, _boltSpacing, _boltDX, _boltDy, secondAngle.getBeam(), _plate4);
                    secondAngleBolts2.BoltAngle(secondAngleFinish, secondAngleStart, _boltSpacing, _boltDX, (-1 * _boltDy), secondAngle.getBeam(), _plate2);

                }
                else if (_angleBracingType == 1)
                {
                    // REMOVE THIS MESSAGE WHEN DOUBLE ANGLE BRACING IS IMPLEMENTED!!!
                    MessageBox.Show("Double angle bracing not implemented yet");
                }
                else
                {
                    // REMOVE THIS MESSAGE WHEN DOUBLE ANGLE BRACING IS IMPLEMENTED!!!
                    MessageBox.Show("Invalid Angle Bracing Type");
                }

            }
            catch (Exception Ex)
            {
               
                throw;
            }
            finally
            {
                // Set workplane back to what user had before
                _classModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(_originalPlane);
            }

            return true;
        }


    }
}
