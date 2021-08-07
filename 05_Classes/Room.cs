using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Room
    {
        /*
        -Create a Room class that has three properties: one each for the length, width, and height.
        -Create a method that calculates total square footage.
        -We also would like to include some constants that the define a minimum and maximum length, width, and height.
        -When setting the properties, make sure to compare the values to the min/max and only set them if the value is valid.

        Bonus:
        -Create a method that calculates total lateral surface area.
        -Only allow the properties to be set from inside the class itself
        Throw an exception if the given value is outside the permitted range.
        Test the code like we did with the Vehicle tests. */

        public Room() { }
        public Room(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double _length;
        private double _width;
        private double _height;

        public double Length
        {
            get { return _length; }
            set
            {
                if (value < MinLength || value > MaxLength)
                {
                    //Don't store it
                    throw new ArgumentException($"The length needs to be between {MinLength} and {MaxLength}");
                }
                _length = value;
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
              if (value < MinWidth || value > MaxWidth)
              {
                    //Don't store it
                    throw new ArgumentException($"The length needs to be between {MinWidth} and {MaxWidth}");
              }
               _width = value;
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value < MinHeight || value > MaxHeight)
                {
                    //Don't store it
                    throw new ArgumentException($"The length needs to be between {MinHeight} and {MaxHeight}");
                }
                _height = value;
            }
        }

        private const double MaxLength = 40;
        private const double MinLength = 5;

        private const double MaxWidth = 50;
        private const double MinWidth = 3;

        private const double MaxHeight = 15;
        private const double MinHeight = 5;

        public double CalculateSquareFootage()
        {
            double squareFootage = Length * Width;
            return squareFootage;
        }

        public double CalcualateLaterSA()
        {
            double latSurfArea = 2 * Height * (Width + Length);
            return latSurfArea;
        }
    }
}
