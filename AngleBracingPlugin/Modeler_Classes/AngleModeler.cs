using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleBracingPlugin.Modeler_Classes.Abstract_Classes;
// Tekla Structures Namespaces
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;

namespace AngleBracingPlugin.Modeler_Classes
{
    class AngleModeler : BeamModeler
    {
        /// <summary>
        /// Constructor for AngleModeler class
        /// </summary>
        /// <param name="classModel"></param>
        public AngleModeler(Model classModel)
        {
            // pass model reference value into base class
            base.classModel = classModel;

            // create new beam
            Beam modelerBeam = new Beam();
            base.classBeam = modelerBeam;

            // Set parameters for beam

            // set parameters for beam
            base.setProfile("L3X3X1/4");
            base.setName("Angle Brace");
            base.setFinish("Grey");
            base.setClass("3");
            base.setAssemblyNumPrefix("AXH");
            base.setAssemblyStartNum(100);
            base.setPartNumPrefix("P");
            base.setPartStartNum(1);
            base.setMaterialString("A992");

        }

        /// <summary>
        /// Method for modeling angle
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="beamProfile"></param>
        /// <param name="isSecondAngle"></param>
        public void ModelAngle(T3D.Point firstPoint, T3D.Point secondPoint, string beamProfile, bool isSecondAngle)
        {
            try
            {               

                // assign start and finish point to beam
                base.classBeam.StartPoint = firstPoint;
                base.classBeam.EndPoint = secondPoint;

                // set parameters for beam
                base.setProfile(beamProfile);
                               

                base.insertBeam(); // insert beam into model

                base.updateModel(); // commit changes to model

            }
            catch
            {
                // set pickedpoints to null
                firstPoint = null;
                secondPoint = null; 

                // read error message to user
                MessageBox.Show("No points were picked");
            }
        }

        /// <summary>
        /// Method for retrieving angle width
        /// </summary>
        /// <returns></returns>
        public double GetAngleWidth()
        {
            try
            {
                // Get angle profile and convert to string
                string angleProfile = base.getProfile().ToString();
                // Remove L from angle profile
                string angleWidth = angleProfile.Substring(1,1);

                return (Double.Parse(angleWidth) * 25.4);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
