using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tekla Structures Namespaces
using TSM = Tekla.Structures.Model;
using TSD = Tekla.Structures.Dialog;
using TSDT = Tekla.Structures.Datatype;
using T3D = Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Tekla.Structures.Model.Operations;

namespace AngleBracingPlugin.Modeler_Classes.Abstract_Classes
{


    public abstract class BoltModeler
    {

        /// <summary>
        /// Fields for BoltModeler class
        /// </summary>
        protected TSM.BoltArray newBoltArray;
        protected T3D.Point startPoint;
        protected TSM.Model boltModel;
        protected T3D.Point endPoint;
        protected int boltQuantity;
        protected double boltSize;
        protected double boltSpaceX;
        protected double boltSpaceY;
        protected double startOffsetX;
        protected double startOffsetY;
        protected double startOffsetZ;
        protected double finishOffsetX;
        protected double finishOffsetY;
        protected double finishOffsetZ;
        protected double cutLength;
        protected string boltStandard;

        /// <summary>
        /// Constructor for BoltModeler class
        /// </summary>
        public BoltModeler()
        {
            
        }

        /// <summary>
        /// Sets the start point for the bolt array
        /// </summary>
        /// <param name="startPoint"></param>
        public void setStartPoint(T3D.Point startPoint)
        {
            try
            {
                this.newBoltArray.FirstPosition = startPoint;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid start point was entered!");
            }
        }

        /// <summary>
        /// Method to retrieve start point from bolt array
        /// </summary>
        /// <returns></returns>
        public T3D.Point getStartPoint()
        {
            try
            {
                return newBoltArray.FirstPosition;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set end point for bolt array
        /// </summary>
        /// <param name="endPoint"></param>
        public void setEndPoint(T3D.Point endPoint)
        {
            try
            {
                this.newBoltArray.SecondPosition = endPoint;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid end point was entered!");
            }
        }

        /// <summary>
        /// Method to retrieve end point from bolt array
        /// </summary>
        /// <returns></returns>
        public T3D.Point getEndPoint()
        {
            try
            {
                return newBoltArray.FirstPosition;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set the number of bolts in the bolt array
        /// </summary>
        /// <param name="boltQuantity"></param>
        public void SetBoltQuantity(int boltQuantity)
        {
            try
            {
                this.boltQuantity = boltQuantity;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt quantity was entered!");
            }
        }

        /// <summary>
        /// Method to retrieve the number of bolts in the bolt array
        /// </summary>
        /// <returns></returns>
        public int GetBoltQuantity()
        {
            try
            {
                return this.boltQuantity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Sets the size of bolts in the bolt array
        /// </summary>
        /// <param name="boltSize"></param>
        public void SetBoltSize(double boltSize)
        {
            try
            {
                this.boltSize = boltSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt size was entered!");
            }
        }

        /// <summary>
        /// Method to retrieve the size of bolts in the bolt array
        /// </summary>
        /// <returns></returns>
        public double GetBoltSize()
        {
            try
            {
                return this.boltSize;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set bolt space X 
        /// (Distance between bolts X direction)
        /// </summary>
        /// <param name="boltSpaceX"></param>
        public void SetBoltSpaceX(double boltSpaceX)
        {
            try
            {
                this.boltSpaceX = boltSpaceX;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get bolt space X 
        /// (Distance between bolts X direction)
        /// </summary>
        /// <returns></returns>
        public double GetBoltSpaceX()
        {
            try
            {
                return this.boltSpaceX;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set bolt space Y
        /// (Distance between bolts Y direction)
        /// </summary>
        /// <param name="boltSpaceY"></param>
        public void SetBoltSpaceY(double boltSpaceY)
        {
            try
            {
                this.boltSpaceY = boltSpaceY;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get bolt space Y
        /// (Distance between bolts Y direction)
        /// </summary>
        /// <returns></returns>
        public double GetBoltSpaceY()
        {
            try
            {
                return this.boltSpaceY;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set start offset dimension Dx
        /// </summary>
        /// <param name="startOffsetX"></param>
        public void SetStartOffsetX(double startOffsetX)
        {
            try
            {
                this.startOffsetX = startOffsetX;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get start offset dimension Dx
        /// </summary>
        /// <returns></returns>
        public double GetStartOffsetX()
        {
            try
            {
                return this.startOffsetX;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set start offset dimension Dy
        /// </summary>
        /// <param name="startOffsetY"></param>
        public void SetStartOffsetY(double startOffsetY)
        {
            try
            {
                this.startOffsetY = startOffsetY;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get start offset dimension Dy
        /// </summary>
        /// <returns></returns>
        public double GetStartOffsetY()
        {
            try
            {
                return this.startOffsetY;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set start offset dimension Dz
        /// </summary>
        /// <param name="startOffsetZ"></param>
        public void SetStartOffsetZ(double startOffsetZ)
        {
            try
            {
                this.startOffsetZ = startOffsetZ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get start offset dimension Dz
        /// </summary>
        /// <returns></returns>
        public double GetStartOffsetZ()
        {
            try
            {
                return this.startOffsetZ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set finish offset dimension Dx
        /// </summary>
        /// <param name="finishOffsetX"></param>
        public void SetFinishOffsetX(double finishOffsetX)
        {
            try
            {
                this.finishOffsetX = finishOffsetX;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get finish offset dimension Dx
        /// </summary>
        /// <returns></returns>
        public double GetFinishOffsetX()
        {
            try
            {
                return this.finishOffsetX;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set finish offset dimension Dy
        /// </summary>
        /// <param name="finishOffsetY"></param>
        public void SetFinishOffsetY(double finishOffsetY)
        {
            try
            {
                this.finishOffsetY = finishOffsetY;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get finish offset dimension Dy
        /// </summary>
        /// <returns></returns>
        public double GetFinishOffsetY()
        {
            try
            {
                return this.finishOffsetY;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set finish offset dimension Dz
        /// </summary>
        /// <param name="finishOffsetZ"></param>
        public void SetFinishOffsetZ(double finishOffsetZ)
        {
            try
            {
                this.finishOffsetZ = finishOffsetZ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt spacing was entered!");
            }
        }

        /// <summary>
        /// Method to get finish offset dimension Dz
        /// </summary>
        /// <returns></returns>
        public double GetFinishOffsetZ()
        {
            try
            {
                return this.finishOffsetZ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method for setting cut length of the bolt array
        /// </summary>
        /// <param name="cutLength"></param>
        public void SetCutLength(double cutLength)
        {
            try
            {
                this.cutLength = cutLength;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid cut length was entered!");
            }
        }

        /// <summary>
        /// Method for getting the cut length of the bolt array
        /// </summary>
        /// <returns></returns>
        public double GetCutLength()
        {
            try
            {
                return this.cutLength;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method for setting bolt standard
        /// </summary>
        /// <param name="boltStandard"></param>
        public void SetBoltStandard(string boltStandard)
        {
            try
            {
                this.boltStandard = boltStandard;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid bolt standard was entered!");
            }
        }

        /// <summary>
        /// Method for getting bolt standard
        /// </summary>
        /// <returns></returns>
        public string GetBoltStandard()
        {
            try
            {
                return this.boltStandard;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set "On Plane" position for bolts
        /// 0 = MIDDLE
        /// 1 = RIGHT
        /// 2 = LEFT
        /// Defaults to 0
        /// </summary>
        /// <param name="position"></param>
        public void SetOnPlanePosition(int position)
        {
            switch (position)
            {
                case 0:
                    this.newBoltArray.Position.Plane = TSM.Position.PlaneEnum.MIDDLE;
                    break;                            
                case 1:                               
                    this.newBoltArray.Position.Plane = TSM.Position.PlaneEnum.RIGHT;
                    break;                            
                case 2:                               
                    this.newBoltArray.Position.Plane = TSM.Position.PlaneEnum.LEFT;
                    break;                           
                default:                             
                    this.newBoltArray.Position.Plane = TSM.Position.PlaneEnum.MIDDLE;
                    break;
            }
        }

        /// <summary>
        /// Method to set plane offset for bolts
        /// </summary>
        /// <param name="offset"></param>
        public void SetOnPlaneOffset(double offset)
        {
            this.newBoltArray.Position.PlaneOffset = offset;
        }

        /// <summary>
        /// Method to get plane offset for bolts
        /// </summary>
        /// <returns></returns>
        public double getPlaneOffset()
        {
            try
            {
                return newBoltArray.Position.PlaneOffset;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to set "Rotation" position
        /// 0 = FRONT
        /// 1 = TOP
        /// 2 = BACK
        /// 3 = BELOW
        /// Defaults to 0
        /// </summary>
        /// <param name="position"></param>
        public void SetRotationPosition(int position)
        {
            switch (position)
            {
                case 0:
                    this.newBoltArray.Position.Rotation = TSM.Position.RotationEnum.FRONT;
                    break;
                case 1:
                    this.newBoltArray.Position.Rotation = TSM.Position.RotationEnum.TOP;
                    break;
                case 2:
                    this.newBoltArray.Position.Rotation = TSM.Position.RotationEnum.BACK;
                    break;
                case 3:
                    this.newBoltArray.Position.Rotation = TSM.Position.RotationEnum.BELOW;
                    break;
                default:
                    this.newBoltArray.Position.Rotation = TSM.Position.RotationEnum.FRONT;
                    break;
            }
        }

        /// <summary>
        /// Method to set rotation offset for bolts
        /// </summary>
        /// <param name="offset"></param>
        public void SetRotationOffset(double offset)
        {
            this.newBoltArray.Position.RotationOffset = offset;
        }

        /// <summary>
        /// Method to get rotation offset for bolts
        /// </summary>
        /// <returns></returns>
        public double getRotationOffset()
        {
            try
            {
                return newBoltArray.Position.RotationOffset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Method to set "Depth" position
        /// 0 = MIDDLE
        /// 1 = FRONT
        /// 2 = BEHIND
        /// DEFAULTS TO 0
        /// </summary>
        /// <param name="position"></param>
        public void SetDepthPosition(int position)
        {
            switch (position)
            {
                case 0:
                    this.newBoltArray.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
                    break;
                case 1:
                    this.newBoltArray.Position.Depth = TSM.Position.DepthEnum.FRONT;
                    break;
                case 2:
                    this.newBoltArray.Position.Depth = TSM.Position.DepthEnum.BEHIND;
                    break;
                default:
                    this.newBoltArray.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
                    break;
            }
        }

        /// <summary>
        /// Method to set depth offset for bolts
        /// </summary>
        /// <param name="offset"></param>
        public void SetDepthOffset(double offset)
        {
            this.newBoltArray.Position.DepthOffset = offset;
        }

        /// <summary>
        /// Method to get depth offset for bolts
        /// </summary>
        /// <returns></returns>
        public double getDepthOffset()
        {
            try
            {
                return newBoltArray.Position.DepthOffset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Method for inserting bolt array
        /// </summary>
        public void InsertBolts()
        {
            this.newBoltArray.Insert();
        }

        /// <summary>
        /// Method for updating model
        /// </summary>
        public void UpdateModel()
        {
            this.boltModel.CommitChanges();
        }
    }
}
