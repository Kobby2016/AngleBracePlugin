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
        /// <summary>
        /// Fields for AngleModelingUtil class
        /// </summary>
        T3D.Point startPoint;
        T3D.Point endPoint;
        T3D.Point startPoint2;
        T3D.Point endPoint2;
        double xStart;
        double yStart;
        double zStart;
        double xFinish;
        double yFinish;
        double zFinish;
        double deltaX;
        double deltaY;
        double deltaZ;
        double deltaX2;
        double deltaY2;
        double deltaZ2;
        double angleHyp;
        double angleSin;
        double angleCos;
        double angleTan;
        double angleHyp2;
        double angleSin2;
        double angleCos2;
        double angleTan2;
        
        /// <summary>
        /// Constructor for AngleModelingUtil class
        /// </summary>
        public AngleModelingUtil()
        {

        }

        /// <summary>
        /// Method for determining the actual start and end points for the angle
        /// based on points selected by the user and offsets entered by the user
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="startOffset"></param>
        /// <param name="endPoint"></param>
        /// <param name="endOffset"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the center point where two lines intersect.
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <param name="fourthPoint"></param>
        /// <returns></returns>
        public T3D.Point CenterPoint(T3D.Point firstPoint, T3D.Point secondPoint, T3D.Point thirdPoint, T3D.Point fourthPoint)
        {
            // Initialize fields
            T3D.Point startPoint = firstPoint;
            T3D.Point endPoint = thirdPoint;
            T3D.Point startPoint2 = fourthPoint;
            T3D.Point endPoint2 = secondPoint;
            T3D.Point intersection = new T3D.Point();          

            // Find equation of each line using point slope form
            intersection = returnCenter(startPoint, endPoint, startPoint2, endPoint2);

            // return point of intersection
            return intersection;
        }

        /// <summary>
        /// Returns the center value for X.
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="firstYIntercept"></param>
        /// <param name="secondYIntercept"></param>
        /// <returns></returns>
        internal T3D.Point returnCenter(T3D.Point firstPoint, T3D.Point secondPoint, T3D.Point thirdPoint, T3D.Point fourthPoint)
        {
            // Initialize fields
            T3D.Point intersection = new T3D.Point();
            double _xVector;
            double _yVector;
            double _xVector2;
            double _yVector2;
            double _thirdVector;
            double _thirdVector2;
            double _determinant;
            T3D.Point firstAngleStart = firstPoint;
            T3D.Point firstAngleFinish = secondPoint;
            T3D.Point secondAngleStart = thirdPoint;
            T3D.Point secondAngleFinish = fourthPoint;

            // Calculate X for center point
            // Get vectors from first line
            _yVector = firstAngleFinish.Y - firstAngleStart.Y;
            _xVector = firstAngleStart.X - firstAngleFinish.X;
            _thirdVector = (_yVector * (firstAngleStart.X)) + (_xVector * (firstAngleStart.Y));
            // Get vectors from second line
            _yVector2 = secondAngleFinish.Y - secondAngleStart.Y;
            _xVector2 = secondAngleStart.X - secondAngleFinish.X;
            _thirdVector2 = (_yVector2 * (secondAngleStart.X)) + (_xVector2 * (secondAngleStart.Y));
            // Find determinant using vectors
            _determinant = (_xVector * _yVector2) - (_xVector2 * _yVector);

            if (_determinant == 0)
            {
                intersection.X = 0;
                intersection.Y = 0;
                intersection.Z = 0;
            }
            else
            {
                intersection.Y = ((_yVector2 * _thirdVector) - (_yVector * _thirdVector2)) / _determinant;
                intersection.X = ((_xVector * _thirdVector2) - (_xVector2 * _thirdVector)) / _determinant;
                intersection.Z = 0.0;
            }

            // return X value
            return intersection;
        }

        ///FINISH THIS METHOD!!!
        public T3D.Point OffsetCenter(T3D.Point startPoint, T3D.Point endPoint,T3D.Point startPoint2, T3D.Point endPoint2, T3D.Point centerPoint, double angleWidth, double angleOffset)
        {
                      
            T3D.Point _startPoint = startPoint;
            T3D.Point _endPoint = endPoint;
            T3D.Point _startPoint2 = startPoint2;
            T3D.Point _endPoint2 = endPoint2;
            T3D.Point _centerPoint = centerPoint;
            double _angleHyp; 
            double _currentAngleWidth = angleWidth;
            
            // Find slope perpendicular to angle slope
            double _xVector1 = (_endPoint.X - _startPoint.X);
            double _yVector1 = (_endPoint.Y - _startPoint.Y);            
            double _perpendicularSlope = -1 * (_xVector1 / _yVector1);
            double _xVector2 = (_endPoint2.X - _startPoint2.X);
            double _yVector2 = (_endPoint2.Y - _startPoint2.Y);
            double _perpendicularSlope2 = -1 * (_xVector2 / _yVector2);

            // Generate arbitrary points using perpendicular slopes so we can find sin and cos
            T3D.Point _firstAnglePoint1 = new T3D.Point(0,0,0);
            T3D.Point _firstAnglePoint2 = new T3D.Point(10, (_perpendicularSlope * 10),0);
            T3D.Point _secondAnglePoint1 = new T3D.Point(0, 0, 0);
            T3D.Point _secondAnglePoint2 = new T3D.Point(10, (_perpendicularSlope * 10), 0);

            // Find sine and cos for triangle using perpendicular slope for hypotenuse
            double _firstAngleHyp;
            double _secondAngleHyp;
           
            // Find hypotenuse using pythagorean theorem 
            _firstAngleHyp = Math.Sqrt(Math.Pow((_perpendicularSlope * 10), 2) + Math.Pow(10, 2));
            _secondAngleHyp = Math.Sqrt(Math.Pow((_perpendicularSlope2 * 10), 2) + Math.Pow(10, 2));

            // Find sin and cos
            double _angleCos = (_firstAnglePoint2.X / _firstAngleHyp);           
            double _angleSin = (_firstAnglePoint2.Y / _firstAngleHyp);
            double _angleCos2 = (_secondAnglePoint2.X / _secondAngleHyp);
            double _angleSin2 = (_secondAnglePoint2.Y / _secondAngleHyp);

            double _deltaX;
            double _deltaY;
            double _deltaX2;
            double _deltaY2;
            _angleHyp = Math.Abs(angleOffset - (_currentAngleWidth / 2));
            _deltaX = Math.Abs(_angleCos * _angleHyp);
            _deltaY = Math.Abs(_angleSin * _angleHyp);
            _deltaX2 = Math.Abs(_angleCos2 * _angleHyp);
            _deltaY2 = Math.Abs(_angleSin2 * _angleHyp);

            //_deltaY = (Math.Abs(_angleHyp - (_currentAngleWidth / 2)) / 2) * 14.8090;

            // calculate x and y for angle offset
            if (_angleHyp < (_currentAngleWidth / 2))
            {
                // Offset first angle points
                _startPoint.X += _deltaX;                
                _startPoint.Y -= _deltaY;
                _endPoint.X += _deltaX;
                _endPoint.Y -= _deltaY;
                // Offset second angle points
                _startPoint2.X -= _deltaX2;
                _startPoint2.Y -= _deltaY2;
                _endPoint2.X -= _deltaX2;
                _endPoint2.Y -= _deltaY2;
            }
            else if (_angleHyp > (_currentAngleWidth / 2))
            {
                // Offset first angle points
                _startPoint.X -= _deltaX;
                _startPoint.Y += _deltaY;
                _endPoint.X -= _deltaX;
                _endPoint.Y += _deltaY;
                // Offset second angle points
                _startPoint2.X += _deltaX2;
                _startPoint2.Y += _deltaY2;
                _endPoint2.X += _deltaX2;
                _endPoint2.Y += _deltaY2;
            }
            else // if angle offset is 0, return points without changes
            {
                return _centerPoint;
            }

            return this.returnCenter(_startPoint, _endPoint, _startPoint2, _endPoint2);
        }        
    }
}
