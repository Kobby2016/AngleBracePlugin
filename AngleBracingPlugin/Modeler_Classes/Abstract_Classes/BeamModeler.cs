using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
// Tekla Structures namespaces
using Tekla.Structures.Model;
using Tekla.Structures.Dialog.UIControls;

namespace AngleBracingPlugin.Modeler_Classes.Abstract_Classes
{
    public abstract class BeamModeler
    {
        // fields for BeamModeler class
        protected Model classModel; // tekla model we will be working in
        protected Beam classBeam; // beam we will be modeling

        // constructor for modeler class
        protected BeamModeler()
        {

        }


        // method to set profile for beam
        public void setProfile(String beamProfile)
        {
            try
            {
                this.classBeam.Profile.ProfileString = beamProfile;
            }
            catch
            {
                MessageBox.Show("Invalid profile was entered.");
            }
        }

        // method to retrieve profile for beam
        public string getProfile()
        {
            try
            {
                return classBeam.Profile.ProfileString;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // method to set name for beam
        public void setName(string beamName)
        {
            try
            {
                this.classBeam.Name = beamName;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to retrieve name for beam
        public string getName()
        {
            try
            {
                return classBeam.Name;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // method to set finish for beam
        public void setFinish(string beamFinish)
        {
            try
            {
                this.classBeam.Finish = beamFinish;
            }
            catch
            {

                MessageBox.Show("Invalid finish.");
            }
        }

        // method to get finish for beam
        public string getFinish()
        {
            try
            {
                return classBeam.Finish;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // method to set class for beam
        public void setClass(string beamClass)
        {
            try
            {
                this.classBeam.Class = beamClass;
            }
            catch
            {

                MessageBox.Show("Invalid class.");
            }
        }

        // method to get class for beam
        public string getClass()
        {
            try
            {
                return classBeam.Class;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // method to set assembly number prefix for beam
        public void setAssemblyNumPrefix(string assemblyNumPrefix)
        {
            try
            {
                this.classBeam.AssemblyNumber.Prefix = assemblyNumPrefix;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set assembly number start number
        public void setAssemblyStartNum(int assemblyStartNum)
        {
            try
            {
                this.classBeam.AssemblyNumber.StartNumber = assemblyStartNum;
            }
            catch
            {

                MessageBox.Show("Invalid start number for assembly.");
            }
        }

        // method to set assembly number prefix for beam
        public void setPartNumPrefix(string partNumPrefix)
        {
            try
            {
                this.classBeam.PartNumber.Prefix = partNumPrefix;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set assembly number prefix for beam
        public void setPartStartNum(int partStartNum)
        {
            try
            {
                this.classBeam.PartNumber.StartNumber = partStartNum;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set assembly number prefix for beam
        public void setMaterialString(string beamMaterial)
        {
            try
            {
                this.classBeam.Material.MaterialString = beamMaterial;
            }
            catch
            {

                MessageBox.Show("Invalid material.");
            }
        }

        // method to set "On plane" position for beam, defaults to middle
        public void SetOnPlanePosition(int position)
        {
            switch (position)
            {
                case 0:
                    this.classBeam.Position.Plane = Position.PlaneEnum.MIDDLE;
                    break;
                case 1:
                    this.classBeam.Position.Plane = Position.PlaneEnum.RIGHT;
                    break;
                case 2:
                    this.classBeam.Position.Plane = Position.PlaneEnum.LEFT;
                    break;
                default:
                    this.classBeam.Position.Plane = Position.PlaneEnum.MIDDLE;
                    break;
            }
        }
        
        // Method to set plane offset 
        public void SetOnPlaneOffset(double offset)
        {
            this.classBeam.Position.PlaneOffset = offset;
        }

        // Method to get plane offset 
        public double getPlaneOffset()
        {
            try
            {
                return classBeam.Position.PlaneOffset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // method to set "Rotation" position for beam, defaults to front
        public void SetRotationPosition(int position)
        {
            switch (position)
            {
                case 0:
                    this.classBeam.Position.Rotation = Position.RotationEnum.FRONT;
                    break;
                case 1:
                    this.classBeam.Position.Rotation = Position.RotationEnum.TOP;
                    break;
                case 2:
                    this.classBeam.Position.Rotation = Position.RotationEnum.BACK;
                    break;
                case 3:
                    this.classBeam.Position.Rotation = Position.RotationEnum.BELOW;
                    break;
                default:
                    this.classBeam.Position.Rotation = Position.RotationEnum.FRONT;
                    break;
            }
        }

        // Method to set rotation offset 
        public void SetRotationOffset(double offset)
        {
            this.classBeam.Position.RotationOffset = offset;
        }

        // Method to get rotation offset 
        public double getRotationOffset()
        {
            try
            {
                return classBeam.Position.RotationOffset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // method to set "At Depth" position for beam, defaults to front
        public void SetDepthPosition(int position)
        {
            switch (position)
            {
                case 0:
                    this.classBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                    break;
                case 1:
                    this.classBeam.Position.Depth = Position.DepthEnum.FRONT;
                    break;
                case 2:
                    this.classBeam.Position.Depth = Position.DepthEnum.BEHIND;
                    break;
                default:
                    this.classBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                    break;
            }
        }

        // Method to set depth offset 
        public void SetDepthOffset(double offset)
        {
            this.classBeam.Position.DepthOffset = offset;
        }

        // Method to get depth offset 
        public double getDepthOffset()
        {
            try
            {
                return classBeam.Position.DepthOffset;
            }
            catch (Exception)
            {

                throw;
            }

        }     
    


        // method to insert beam
        public void insertBeam()
        {
            this.classBeam.Insert();
        }

        // method to update model
        public void updateModel()
        {
            this.classModel.CommitChanges();
        }

    }
}
