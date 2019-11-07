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

namespace AngleBracingPlugin
{
    class AngleModelingUtil
    {
        // Fields for AngleModelingUtil class
        T3D.Point startPoint;
        T3D.Point endPoint;
        double xStart;
        double yStart;
        double zStart;
        double xFinish;
        double yFinish;
        double zFinish;
        double deltaX;
        double deltaY;
        double deltaZ;
        double angleHyp;
        double angleSin;
        double angleCos;
        double angleTan;



        public AngleModelingUtil()
        {

        }

        public List<T3D.Point>TrimPoints(T3D.Point startPoint, double startOffset, T3D.Point endPoint, double endOffset)
        {
            // List for returning points
            List<T3D.Point> trimmedPoints = new List<T3D.Point>();
            // first point
            yStart = startPoint.X;
            xStart = startPoint.Y;
            zStart = startPoint.Z = 0;
            double startHyp = startOffset;
            // second point
            yFinish = endPoint.X;
            xFinish = endPoint.Y;
            zFinish = endPoint.Z = 0;
            double endHyp = endOffset;
            // fields for calculation
            deltaX = Math.Abs((xFinish - xStart));
            deltaY = Math.Abs((yFinish - yStart));
            angleHyp = Math.Sqrt((Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));
            angleSin = (deltaY / angleHyp);
            angleCos = (deltaX / angleHyp);
            angleTan = (deltaY / deltaX);
            bool startIsBottom;
            bool startIsLeft;

            // iS START Y LESS THAN FINISH?
            if (yStart < yFinish)
            {
                startIsBottom = true;
            }
            else
            {
                startIsBottom = false;
            }

            // IS START X LESS THAN FINISH?
            if (xStart < xFinish)
            {
                startIsLeft = true;
            }
            else
            {
                startIsLeft = false;
            }

            if (startIsBottom)
            {
                if (startIsLeft)
                {
                    // adjust start
                    // BOTTOM LEFT TO TOP RIGHT
                    yStart += (angleSin * startOffset);
                    xStart += (angleCos * startOffset);
                    
                    // adjust end
                    yFinish -= (angleSin * endOffset);
                    xFinish -= (angleCos * endOffset);
                 
                }
                else
                {
                    // adjust start
                    // BOTTOM RIGHT TO TOP LEFT
                    yStart += (angleSin * startOffset);
                    xStart -= (angleCos * startOffset);
                    
                    // adjust end
                    yFinish -= (angleSin * endOffset);
                    xFinish += (angleCos * endOffset);
                   
                }
            }
            else
            {
                if (startIsLeft)
                {
                    // adjust start
                    // TOP LEFT TO BOTTOM RIGHT
                    yStart -= (angleSin * startOffset);
                    xStart += (angleCos * startOffset);

                    // adjust end
                    yFinish += (angleSin * endOffset);
                    xFinish -= (angleCos * endOffset);

                }
                else
                {
                    // adjust start
                    // TOP RIGHT TO BOTTOM LEFT
                    yStart -= (angleSin * startOffset);
                    xStart -= (angleCos * startOffset);
                    
                    // adjust end
                    yFinish += (angleSin * endOffset);
                    xFinish += (angleCos * endOffset);
                    
                }
            }

            // Add coordinates back to T3D Points
            startPoint.Y = xStart;
            startPoint.X = yStart;
            startPoint.Z = zStart;
            endPoint.Y = xFinish;
            endPoint.X = yFinish;
            endPoint.Z = zFinish;

            // Add T3D Points to list and return. 
            trimmedPoints.Add(startPoint);
            trimmedPoints.Add(endPoint);            
            return trimmedPoints;
        }
    }
}
