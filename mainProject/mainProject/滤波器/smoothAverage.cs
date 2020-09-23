using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class smoothAverage
    {
        static int[] dx = { -1, 0, 1 };
        static int[] dy = { -1, 0, 1 };
        public smoothAverage()
        {
        }
        public myPicture doSmooth(myPicture input)
        {
            Bitmap ret = new Bitmap(input.width, input.height);

            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    int cnt = 0;
                    int sum = 0;
                    for (int ii = 0; ii < 3; ++ii)
                    {
                        for (int jj = 0; jj < 3; ++jj)
                        {
                            int ni = i + dx[ii];
                            int nj = j + dy[jj];
                            if (ni == i && nj == j) continue;
                            if (ni < 0 || ni >= input.width) continue;
                            if (nj < 0 || nj >= input.height) continue;
                            ++cnt;
                            sum += input.grayDegree[ni, nj];
                        }
                    }
                    sum /= cnt;
                    ret.SetPixel(i, j, Color.FromArgb(sum, sum, sum));
                }
            }

            return new myPicture(ret, input.path);
        }
    }
}
