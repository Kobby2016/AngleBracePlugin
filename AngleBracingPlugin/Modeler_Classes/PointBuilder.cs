using System;
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

namespace AngleBracingPlugin.Modeler_Classes
{
    class PointBuilder
    {
        // Fields for class
        T3D.Point firstPoint;
        T3D.Point secondPoint;
        T3D.Point returnPoint = new T3D.Point(0, 0, 0); // Default to zero
        TSM.ContourPlate connectionPlate;
        TSM.Model currentModel;
        bool isLower;
        double offset;


        // Constructor
        public PointBuilder(T3D.Point firstPoint, T3D.Point secondPoint, TSM.Model currentModel)
        {
            // Assign firstPoint and secondPoint to fields
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.currentModel = currentModel;
            
        }

        // Method to build first point
        public T3D.Point BuildFirstPoint(TSM.ContourPlate connectionPlate, double offset)
        {
            // set isLower to true for lower point
            isLower = true;
            this.connectionPlate = connectionPlate;
            this.offset = offset;

            // Generate new point
            return buildPoint(this.firstPoint, this.secondPoint, this.connectionPlate, this.offset, this.isLower);
        }

        // Method to buld second point
        public T3D.Point BuildSecondPoint(TSM.ContourPlate connectionPlate, double offset)
        {
            // set isLower to true for lower point
            isLower = false;            
            this.connectionPlate = connectionPlate;
            this.offset = offset;

            // Generate new point
            return buildPoint(this.secondPoint, this.firstPoint, this.connectionPlate, this.offset, this.isLower);
        }

        // Method to generate points for BuildFirstPoint and BuildSecondPoint methods
       internal T3D.Point buildPoint(T3D.Point originPoint, T3D.Point directionPoint, TSM.ContourPlate connectionPlate, double offset, bool isLower)
        {
            int xDirection;
            int zDirection;
            double xVector = directionPoint.X - originPoint.X;
            double zVector = directionPoint.Z - originPoint.Z;
            double hypotenuse = Math.Sqrt(Math.Pow(xVector, 2) + Math.Pow(zVector, 2));
            
            
            // If plate is lower plate, set y direction to be positive
            if(isLower)
            {
                zDirection = 1;
            }
            else
            {
                zDirection = -1;
            }

            // determine X direction for point. 
            if (directionPoint.X > originPoint.X)
            {
                xDirection = 1;
            }
            else
            {
                xDirection = -1;
            }

            

            return returnPoint;
        }

       

}
}

