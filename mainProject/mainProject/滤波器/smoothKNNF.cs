using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class smoothKNNF
    {
        class pair
        {
            public int x, y;
            pair()
            {
            }
            public pair(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }
        class pairCmp : IComparer<pair>
        {
            public int Compare(pair a, pair b)
            {
                return a.x.CompareTo(b.x);
            }
        }
        static int[] dx = { -2, -1, 0, 1, 2 };
        static int[] dy = { -2, -1, 0, 1, 2 };

        public smoothKNNF()
        {
        }
        public myPicture doSmooth(myPicture input)
        {
            Bitmap ret = new Bitmap(input.width, input.height);

            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    List<pair> tmp = new List<pair>();
                    for (int ii = 0; ii < 5; ++ii)
                    {
                        for (int jj = 0; jj < 5; ++jj)
                        {
                            int ni = i + dx[ii];
                            int nj = j + dy[jj];
                            if (ni == i && nj == j) continue;
                            if (ni < 0 || ni >= input.width) continue;
                            if (nj < 0 || nj >= input.height) continue;
                            int d = input.grayDegree[ni, nj] - input.grayDegree[i, j];
                            if (d < 0)  d = -d;
                            tmp.Add(new pair(d, input.grayDegree[ni, nj]));
                        }
                    }
                    tmp.Sort(new pairCmp());
                    int sum = 0;
                    for (int k = 0; k < 5; ++k) sum += tmp[k].y;
                    sum /= 5;
                    ret.SetPixel(i, j, Color.FromArgb(sum, sum, sum));
                }
            }
            return new myPicture(ret, input.path);
        }
    }
}
