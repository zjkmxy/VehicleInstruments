using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class smoothTemplate
    {
        public smoothTemplate()
        {
        }
        public myPicture doSmooth(myPicture input, matrix mat)
        {
            Bitmap ret = new Bitmap(input.width, input.height);

            int r = mat.n / 2, s = mat.m / 2;
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    double tmp = 0;
                    for (int p = -r; p <= r; ++p)
                    {
                        for (int q = -s; q <= s; ++q)
                        {
                            tmp += 1.0 * input.getGrayDegree(i - p, j - q) * mat.a[p+r, q+s];
                        }
                    }
                    int val = (int)tmp;
                    if (val < 0) val = 0;
                    if (val > 255) val = 255;
                    ret.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }

            return new myPicture(ret, input.path);
        }
    }
}
