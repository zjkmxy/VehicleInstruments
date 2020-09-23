using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class sharpKirsch
    {
        public sharpKirsch()
        {
        }
        public myPicture doSharp(myPicture input)
        {
            Bitmap ret = new Bitmap(input.width, input.height);
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    int val1 = -5*input.getGrayDegree(i - 1, j - 1) + 3*input.getGrayDegree(i - 1, j) + 3*input.getGrayDegree(i - 1, j + 1) - 5*input.getGrayDegree(i, j - 1) + 3*input.getGrayDegree(i, j + 1) - 5*input.getGrayDegree(i + 1, j - 1) + 3*input.getGrayDegree(i + 1, j) + 3*input.getGrayDegree(i + 1, j + 1);
                    int val2 = +3*input.getGrayDegree(i - 1, j - 1) + 3*input.getGrayDegree(i - 1, j) + 3*input.getGrayDegree(i - 1, j + 1) - 5*input.getGrayDegree(i, j - 1) + 3*input.getGrayDegree(i, j + 1) - 5*input.getGrayDegree(i + 1, j - 1) - 5*input.getGrayDegree(i + 1, j) + 3*input.getGrayDegree(i + 1, j + 1);
                    int val3 = +3*input.getGrayDegree(i - 1, j - 1) + 3*input.getGrayDegree(i - 1, j) + 3*input.getGrayDegree(i - 1, j + 1) + 3*input.getGrayDegree(i, j - 1) + 3*input.getGrayDegree(i, j + 1) - 5*input.getGrayDegree(i + 1, j - 1) - 5*input.getGrayDegree(i + 1, j) - 5*input.getGrayDegree(i + 1, j + 1);
                    int val4 = +3*input.getGrayDegree(i - 1, j - 1) + 3*input.getGrayDegree(i - 1, j) + 3*input.getGrayDegree(i - 1, j + 1) + 3*input.getGrayDegree(i, j - 1) - 5*input.getGrayDegree(i, j + 1) + 3*input.getGrayDegree(i + 1, j - 1) - 5*input.getGrayDegree(i + 1, j) - 5*input.getGrayDegree(i + 1, j + 1);
                    int val5 = +3*input.getGrayDegree(i - 1, j - 1) + 3*input.getGrayDegree(i - 1, j) - 5*input.getGrayDegree(i - 1, j + 1) + 3*input.getGrayDegree(i, j - 1) - 5*input.getGrayDegree(i, j + 1) + 3*input.getGrayDegree(i + 1, j - 1) + 3*input.getGrayDegree(i + 1, j) - 5*input.getGrayDegree(i + 1, j + 1);
                    int val6 = +3*input.getGrayDegree(i - 1, j - 1) - 5*input.getGrayDegree(i - 1, j) - 5*input.getGrayDegree(i - 1, j + 1) + 3*input.getGrayDegree(i, j - 1) - 5*input.getGrayDegree(i, j + 1) + 3*input.getGrayDegree(i + 1, j - 1) + 3*input.getGrayDegree(i + 1, j) + 3*input.getGrayDegree(i + 1, j + 1);
                    int val7 = -5*input.getGrayDegree(i - 1, j - 1) - 5*input.getGrayDegree(i - 1, j) - 5*input.getGrayDegree(i - 1, j + 1) + 3*input.getGrayDegree(i, j - 1) + 3*input.getGrayDegree(i, j + 1) + 3*input.getGrayDegree(i + 1, j - 1) + 3*input.getGrayDegree(i + 1, j) + 3*input.getGrayDegree(i + 1, j + 1);
                    int val8 = -5*input.getGrayDegree(i - 1, j - 1) - 5*input.getGrayDegree(i - 1, j) + 3*input.getGrayDegree(i - 1, j + 1) - 5*input.getGrayDegree(i, j - 1) + 3*input.getGrayDegree(i, j + 1) + 3*input.getGrayDegree(i + 1, j - 1) + 3*input.getGrayDegree(i + 1, j) + 3*input.getGrayDegree(i + 1, j + 1);
                    int val = 0;
                    if (val1 < 0) val1 = -val1;
                    if (val2 < 0) val2 = -val2;
                    if (val3 < 0) val3 = -val3;
                    if (val4 < 0) val4 = -val4;
                    if (val5 < 0) val5 = -val5;
                    if (val6 < 0) val6 = -val6;
                    if (val7 < 0) val7 = -val7;
                    if (val8 < 0) val8 = -val8;
                    if (val1 > val) val = val1;
                    if (val2 > val) val = val2;
                    if (val3 > val) val = val3;
                    if (val4 > val) val = val4;
                    if (val5 > val) val = val5;
                    if (val6 > val) val = val6;
                    if (val7 > val) val = val7;
                    if (val8 > val) val = val8;
                    if (val > 255) val = 255;
                    ret.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }
            return new myPicture(ret, input.path);
        }
    }
}
