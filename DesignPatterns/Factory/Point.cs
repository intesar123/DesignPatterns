using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Point
    {
        private double x, y;

        //Now what happens here I realized later need to initialize this point with polar co-ordinate
        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }


    }
}
