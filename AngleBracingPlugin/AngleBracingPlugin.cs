using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


    [Plugin("AngleBracingPlugin")] // Mandatory field which defines that the class is a plug-in-and stores the name of the plug-in to the system.
    [PluginUserInterface("AngleBracingPlugin.AngleBraceFrm")] // Mandatory field which defines the user interface the plug-in uses - A windows form class
    class AngleBracingPlugin : PluginBase
    {

        private StructuresData Data { get; set; }

        // fields for AngleBracingPlugin class
        private string[] _angleType = { "L3X3X1/4", "L4X4X3/8", "L5X5X1/2" };
        private TSDT.Integer _angleBracingType;
        private TSDT.Integer _angleBracingProfile;
        private TSDT.Integer _anglePosition;
        private TSDT.Distance _angleOffset;
        private string _angleProfile;
        private TSM.ContourPlate _plate1;
        private TSM.ContourPlate _plate2;
        private TSM.ContourPlate _plate3;
        private TSM.ContourPlate _plate4;
        private T3D.Point _point1;
        private T3D.Point _point2;
        private T3D.Point _point3;
        private T3D.Point _point4;


        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public AngleBracingPlugin(StructuresData data)
        {
            TSM.Model model = new TSM.Model();
            Data = data;

            // pass fields from Structures Data into AngleBracingPlugin class
            _angleBracingType = data.AngleBracingType;
            _angleOffset = data.AngleOffset;
            _anglePosition = data.AnglePosition;
            _angleBracingProfile = data.AngleBracingProfile;
            // Assign profile for angle
            _angleProfile = _angleType[_angleBracingProfile];
            
        }


        public override List<InputDefinition> DefineInput()
        {
            // for debugging
            Operation.DisplayPrompt("You are now in List<InputDefinition> Define Input()");

            // create new instance of TSMUI.Picker and input definition list.
            TSMUI.Picker anglePicker = new TSMUI.Picker();
            List<InputDefinition> PointList = new List<InputDefinition>();

            // Prompt user to pick 4 plates 
            Operation.DisplayPrompt("Please pick all 4 plates for connection, clockwise, starting at bottom left.");
            _plate1 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
            _plate2 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
            _plate3 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;
            _plate4 = anglePicker.PickObject(TSMUI.Picker.PickObjectEnum.PICK_ONE_PART) as TSM.ContourPlate;

            // Prompt user to pick points
            Operation.DisplayPrompt("Please pick all 4 points for connection, clockwise, starting at bottom left.");
            _point1 = anglePicker.PickPoint() as T3D.Point;
            _point2 = anglePicker.PickPoint() as T3D.Point;
            _point3 = anglePicker.PickPoint() as T3D.Point;
            _point4 = anglePicker.PickPoint() as T3D.Point;
            
            // Create inputs to InputDefinition list.
            InputDefinition Input1 = new InputDefinition(_point1);
            InputDefinition Input2 = new InputDefinition(_point2);
            InputDefinition Input3 = new InputDefinition(_point3);
            InputDefinition Input4 = new InputDefinition(_point4);

            // Add inputs to InputDefinition list.
            PointList.Add(Input1);
            PointList.Add(Input2);
            PointList.Add(Input3);
            PointList.Add(Input4);

            return PointList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                Operation.DisplayPrompt("You are now in bool Run(List<InputDefinition> Input)");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Something went wrong!\n" + Ex);
                throw;
            }

            return true;
        }


    }
}
