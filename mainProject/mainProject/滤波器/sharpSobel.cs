using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class sharpSobel
    {
        public sharpSobel()
        {
        }
        public myPicture doSharp(myPicture input)
        {
            Bitmap ret = new Bitmap(input.width, input.height);
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    int dx = (input.getGrayDegree(i-1, j-1) + 2*input.getGrayDegree(i-1, j) + input.getGrayDegree(i-1, j+1)) - (input.getGrayDegree(i+1, j-1) + 2*input.getGrayDegree(i+1, j) + input.getGrayDegree(i+1, j+1));
                    int dy = (input.getGrayDegree(i-1, j+1) + 2*input.getGrayDegree(i, j+1) + input.getGrayDegree(i+1, j+1)) - (input.getGrayDegree(i-1, j-1) + 2*input.getGrayDegree(i, j-1) + input.getGrayDegree(i+1, j-1));
                    if (dx < 0) dx = -dx;
                    if (dy < 0) dy = -dy;
                    int d = Math.Max(dx, dy);
                    if (d > 255) d = 255;
                    ret.SetPixel(i, j, Color.FromArgb(d, d, d));
                }
            }
            return new myPicture(ret, input.path);
        }
    }
}
