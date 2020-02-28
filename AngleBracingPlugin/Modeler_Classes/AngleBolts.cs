using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleBracingPlugin.Modeler_Classes.Abstract_Classes;

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
    class AngleBolts : BoltModeler
    {

        public AngleBolts(TSM.Model boltModel)
            : this(boltModel, 25.4, 1, "A325N", 250)
        {

        }

        public AngleBolts(TSM.Model boltModel, double boltSize)
            : this(boltModel, boltSize, 1, "A325N", 250)
        {

        }

 
        public AngleBolts(TSM.Model boltModel, double boltSize, int boltQuantity)
            : this(boltModel, boltSize, boltQuantity, "A325N", 250)
        {

        }


        public AngleBolts(TSM.Model boltModel, double boltSize, int boltQuantity, string boltStandard)
            : this(boltModel, boltSize, boltQuantity, boltStandard, 250)
        {

        }

        /// <summary>
        /// Chained constructor for AngleBolts class
        /// </summary>
        /// <param name="boltModel"></param>
        /// <param name="boltSize"></param>
        /// <param name="boltQuantity"></param>
        /// <param name="boltStandard"></param>
        /// <param name="cutLength"></param>
        public AngleBolts(TSM.Model boltModel, double boltSize, int boltQuantity, string boltStandard, double cutLength)
        {
            // Assign values to fields of base class
            base.boltModel = boltModel;
            base.SetBoltSize(boltSize);
            base.SetBoltQuantity(boltQuantity);
            base.SetBoltStandard(boltStandard);
            base.SetCutLength(cutLength);            
        }

        /// <summary>
        /// Method for bolting a single angle to a connection plate
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="boltSpacing"></param>
        /// <param name="boltDx"></param>
        /// <param name="firstUserAngle"></param>
        /// <param name="firstUserPlate"></param>
        public void BoltAngle(T3D.Point startPoint, T3D.Point endPoint, double boltSpacing, double boltDx, double boltDy, TSM.Beam firstUserAngle, TSM.ContourPlate firstUserPlate)
        {
            try
            {

                // Only one row of bolts
                base.newBoltArray.AddBoltDistY(0);
                if (base.boltQuantity == 1)
                {
                    base.newBoltArray.AddBoltDistX(0);
                }
                else
                {
                    // For each bolt, add spacing between bolts along X axis
                    for (int i = 0; i < (base.boltQuantity - 1); i++)
                    {
                        base.newBoltArray.AddBoltDistX(boltSpacing);
                    }
                }
                // Set start point and end point for bolts
                base.setStartPoint(startPoint);
                base.setEndPoint(endPoint);

                // Add Dx and Dy bolt offset dimension to bolt array
                base.SetStartOffsetX(boltDx);
                base.SetStartOffsetY(boltDy);
                base.SetFinishOffsetY(boltDy);

                // Bolt connection plate to angle
                base.newBoltArray.PartToBoltTo = firstUserAngle;
                base.newBoltArray.PartToBeBolted = firstUserPlate;
                base.SetOnPlanePosition(0);
                base.SetRotationPosition(0);
                base.SetDepthPosition(0);

                // Set bolt type to site
                base.newBoltArray.BoltType = TSM.BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;

                // Insert bolts and update model
                base.InsertBolts();
                base.UpdateModel();
            }
            catch (Exception)
            {
                MessageBox.Show("Bolting connection failed!");
            }           

        }

        /// <summary>
        /// Method for bolting two angles to a connection plate
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="boltSpacing"></param>
        /// <param name="boltDx"></param>
        /// <param name="firstUserAngle"></param>
        /// <param name="secondUserAngle"></param>
        /// <param name="firstUserPlate"></param>
        public void BoltAngle(T3D.Point startPoint, T3D.Point endPoint, double boltSpacing, double boltDx, double boltDy, TSM.Beam firstUserAngle, TSM.Beam secondUserAngle, TSM.ContourPlate firstUserPlate)
        {
            try
            {

                // Only one row of bolts
                base.newBoltArray.AddBoltDistY(0);
                if (base.boltQuantity == 1)
                {
                    base.newBoltArray.AddBoltDistX(0);
                }
                else
                {
                    // For each bolt, add spacing between bolts along X axis
                    for (int i = 0; i < (base.boltQuantity - 1); i++)
                    {
                        base.newBoltArray.AddBoltDistX(boltSpacing);
                    }
                }               

                // Set start point and end point for bolts               
                base.setStartPoint(startPoint);
                base.setEndPoint(endPoint);

                // Set bolt type to site
                base.newBoltArray.BoltType = TSM.BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;

                // Add Dx and Dy bolt offset dimension to bolt array
                base.SetStartOffsetX(boltDx);
                base.SetStartOffsetY(boltDy);
                base.SetFinishOffsetY(boltDy);

                // Bolt connection plate to angle
                base.newBoltArray.PartToBoltTo = firstUserAngle;
                base.newBoltArray.PartToBeBolted = firstUserPlate;
                base.newBoltArray.PartToBeBolted = secondUserAngle;
                base.SetOnPlanePosition(0);
                base.SetRotationPosition(0);
                base.SetDepthPosition(0);

                // Insert bolts and update model
                base.InsertBolts();
                base.UpdateModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bolting connection failed!");
            }

        }

        /// <summary>
        /// Method for bolting angles together.
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="boltSpacing"></param>
        /// <param name="boltDx"></param>
        /// <param name="boltDy"></param>
        /// <param name="firstUserAngle"></param>
        /// <param name="secondUserAngle"></param>
        public void BoltAngle(T3D.Point startPoint, T3D.Point endPoint, double boltSpacing, double boltDx, double boltDy, TSM.Beam firstUserAngle)
        {
            try
            {

                // Only one row of bolts
                base.newBoltArray.AddBoltDistY(0);
                if (base.boltQuantity == 1)
                {
                    base.newBoltArray.AddBoltDistX(0);
                }
                else
                {
                    // For each bolt, add spacing between bolts along X axis
                    for (int i = 0; i < (base.boltQuantity - 1); i++)
                    {
                        base.newBoltArray.AddBoltDistX(boltSpacing);
                    }
                }

                // Set start point and end point for bolts
                base.setStartPoint(startPoint);
                base.setEndPoint(endPoint);

                // Add Dx and Dy bolt offset dimension to bolt array
                base.SetStartOffsetX(boltDx);
                base.SetStartOffsetY(boltDy);
                base.SetFinishOffsetY(boltDy);

                // Bolt connection plate to angle
                base.newBoltArray.PartToBoltTo = firstUserAngle;
                base.newBoltArray.PartToBeBolted = firstUserAngle;
                base.SetOnPlanePosition(0);
                base.SetRotationPosition(0);
                base.SetDepthPosition(0);

                // Set bolt type to site
                base.newBoltArray.BoltType = TSM.BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;

                // Insert bolts and update model
                base.InsertBolts();
                base.UpdateModel();
            }
            catch (Exception)
            {
                MessageBox.Show("Bolting connection failed!");
            }

        }
    }
}
