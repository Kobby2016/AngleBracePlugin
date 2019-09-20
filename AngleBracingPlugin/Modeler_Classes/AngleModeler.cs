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
        public AngleModeler(Model classModel)
        {
            // pass model reference value into base class
            base.classModel = classModel;
        }

        public void ModelAngle(T3D.Point firstPoint, T3D.Point secondPoint, string beamProfile, bool isSecondAngle)
        {
            try
            {
                // create new beam
                Beam modelerBeam = new Beam();
                base.classBeam = modelerBeam;

                // assign start and finish point to beam
                base.classBeam.StartPoint = firstPoint;
                base.classBeam.EndPoint = secondPoint;

                // set parameters for beam
                base.setProfile(beamProfile);
                base.setName("Angle Brace");
                base.setFinish("Grey");
                base.setClass("3");
                base.setAssemblyNumPrefix("AXH");
                base.setAssemblyStartNum(100);
                base.setPartNumPrefix("P");
                base.setPartStartNum(1);
                base.setMaterialString("A992");

                // If first angle
                if (!isSecondAngle)
                {
                    // set position for beam
                    base.classBeam.Position.Depth = Position.DepthEnum.MIDDLE; // set depth to behind
                    base.classBeam.Position.Plane = Position.PlaneEnum.RIGHT; // set plane position to middle
                    base.classBeam.Position.Rotation = Position.RotationEnum.BACK; // set rotation to top
                }
                else // In case of double angle brace connection, if angle is second angle.
                {
                    // set position for beam
                    base.classBeam.Position.Depth = Position.DepthEnum.MIDDLE; // set depth to behind
                    base.classBeam.Position.Plane = Position.PlaneEnum.RIGHT; // set plane position to middle
                    base.classBeam.Position.Rotation = Position.RotationEnum.FRONT; // set rotation to top
                }
             

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
    }
}
