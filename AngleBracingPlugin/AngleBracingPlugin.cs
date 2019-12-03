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
        private double _boltSpacing = 76.2;
        private double _angleOffset;
        private double _firstOffset;
        private double _secondOffset;
        private double _thirdOffset;
        private double _fourthOffset;
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
        TSM.TransformationPlane originalPlane;
        


        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public AngleBracingPlugin(StructuresData data)
        {
            TSM.Model _model = _classModel = new TSM.Model();
            Data = data;

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
                originalPlane = _classModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();

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
                PlateList.Add(_plate1);
                PlateList.Add(_plate2);
                PlateList.Add(_plate3);
                PlateList.Add(_plate4);

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

            }
            catch (Exception ex)
            {
                throw;
            }                                  

            return InputList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            List<T3D.Point> firstAnglePoints;
            List<T3D.Point> secondAnglePoints;
            List<T3D.Point> thirdAnglePoints;
            List<T3D.Point> fourthAnglePoints;

            try
            {                            

                // Get T3D Points from Input
                T3D.Point firstPoint = (T3D.Point)Input.ElementAt(0).GetInput();
                T3D.Point secondPoint = (T3D.Point)Input.ElementAt(1).GetInput();
                T3D.Point thirdPoint = (T3D.Point)Input.ElementAt(2).GetInput();
                T3D.Point fourthPoint = (T3D.Point)Input.ElementAt(3).GetInput();
                ArrayList PlateLIst = (ArrayList)Input.ElementAt(4).GetInput();

                // Get plates from plate list
                TSM.ContourPlate firstPlate = (TSM.ContourPlate)PlateLIst[0];
                TSM.ContourPlate secondPlate = (TSM.ContourPlate)PlateLIst[1];
                TSM.ContourPlate thirdPlate = (TSM.ContourPlate)PlateLIst[2];
                TSM.ContourPlate fourthPlate = (TSM.ContourPlate)PlateLIst[3];

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
                    double width = firstAngle.GetAngleWidth();
                    // Adjust angle offset
                    if (_anglePosition == 0)
                    { 
                        firstAngle.SetOnPlaneOffset((width / 2) * -1);
                    }
                    else
                    {
                        firstAngle.SetOnPlaneOffset((width - (_angleOffset * 25.4)));
                    }

                    // Second angle
                    AngleModeler secondAngle = new AngleModeler(_classModel);
                    secondAngle.SetOnPlanePosition(1);
                    secondAngle.SetRotationPosition(0);
                    secondAngle.SetDepthPosition(1);
                    secondAngle.SetRotationOffset(180);
                    double width2 = secondAngle.GetAngleWidth();
                    // Adjust angle offset
                    if (_anglePosition == 0)
                    {
                        secondAngle.SetOnPlaneOffset((width2 / 2) * -1);
                    }
                    else
                    {
                        secondAngle.SetOnPlaneOffset((width2 - (_angleOffset * 25.4)) * -1);
                    }

                    // Model angles
                    firstAngle.ModelAngle(firstAnglePoints.ElementAt(0), firstAnglePoints.ElementAt(1), _angleProfile, false);
                    secondAngle.ModelAngle(secondAnglePoints.ElementAt(0), secondAnglePoints.ElementAt(1), _angleProfile, false);
                    // Generate bolts
                    AngleBolts firstAngleBolts1 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts firstAngleBolts2 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts secondAngleBolts1 = new AngleBolts(_classModel, _boltSize, _boltQty);
                    AngleBolts secondAngleBolts2 = new AngleBolts(_classModel, _boltSize, _boltQty);

                    // Bolt angles to plates
                    firstAngleBolts1.BoltAngle(firstAnglePoints.ElementAt(0), firstAnglePoints.ElementAt(1),_boltSpacing, _boltDX, firstAngle.getBeam(), firstPlate);
                    firstAngleBolts2.BoltAngle(firstAnglePoints.ElementAt(1), firstAnglePoints.ElementAt(0), _boltSpacing, _boltDX, firstAngle.getBeam(), thirdPlate);
                    secondAngleBolts1.BoltAngle(secondAnglePoints.ElementAt(0), secondAnglePoints.ElementAt(1), _boltSpacing, _boltDX, secondAngle.getBeam(), fourthPlate);
                    secondAngleBolts2.BoltAngle(secondAnglePoints.ElementAt(1), secondAnglePoints.ElementAt(0), _boltSpacing, _boltDX, secondAngle.getBeam(), secondPlate);
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
                _classModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(originalPlane);
            }

            return true;
        }


    }
}
