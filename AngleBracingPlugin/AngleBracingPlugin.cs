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


        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public AngleBracingPlugin(StructuresData data)
        {
            TSM.Model model = new TSM.Model();
            Data = data;
        }


        public override List<InputDefinition> DefineInput()
        {
            Operation.DisplayPrompt("You are now in List<InputDefinition> Define Input()");

            return null;
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
