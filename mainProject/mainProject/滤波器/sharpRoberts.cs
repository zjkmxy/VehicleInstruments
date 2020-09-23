using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class sharpRoberts
    {
        public sharpRoberts()
        {
        }
        public myPicture doSharp(myPicture input)
        {
            Bitmap ret = new Bitmap(input.width, input.height);
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    int d1 = input.getGrayDegree(i, j) - input.getGrayDegree(i - 1, j - 1);
                    int d2 = input.getGrayDegree(i, j) - input.getGrayDegree(i + 1, j - 1);
                    if (d1 < 0) d1 = -d1;
                    if (d2 < 0) d2 = -d2;
                    int d = Math.Max(d1, d2);
                    ret.SetPixel(i, j, Color.FromArgb(d, d, d));
                }
            }
            return new myPicture(ret, input.path);
        }
    }
}
