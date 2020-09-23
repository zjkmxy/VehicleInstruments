using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class OTSU
    {
        public OTSU()
        {
        }

        //利用OTSU算法实现二值化
        //输入：input为灰度图像
        //输出：res为二值图像
        //选取的阈值使分割出的两类像素，类间方差最大，类内方差最小
        public myPicture doOTSU(myPicture input)
        {
            Bitmap res = new Bitmap(input.width, input.height);
            int [,,] count = new int[40, 40, 256];
            int MAGIC = 300;
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    count[i / MAGIC, j / MAGIC, input.grayDegree[i, j]]++;
                }
            }

            for (int i = 0; i < input.width; i += MAGIC)
            {
                for (int j = 0; j < input.height; j += MAGIC)
                {
                    int ii = i / MAGIC;
                    int jj = j / MAGIC;
                    double n1, n2, n, sum1, sum2, sum;
                    n1 = 0;
                    n = 0;
                    sum1 = 0;
                    sum = 0;
                    for (int t = 0; t < 256; ++t)
                    {
                        int val = count[ii, jj, t];
                        sum += 1.0 * t * val;
                        n += val;
                    }
                    double maxVal = -1.0;
                    int threshold = -1;
                    for (int t = 0; t < 256; ++t)
                    {
                        int val = count[ii, jj, t];
                        n1 += val;
                        if (n1 == 0) continue;
                        n2 = n - n1;
                        if (n2 == 0) break;
                        sum1 += 1.0 * t * val;
                        sum2 = sum - sum1;
                        double m1 = sum1 / n1;
                        double m2 = sum2 / n2;
                        double tmp = n1 * n2 * (m1 - m2) * (m1 - m2);
                        if (tmp > maxVal)
                        {
                            maxVal = tmp;
                            threshold = t;
                        }
                    }
                    for (int p = i; p < Math.Min(i + MAGIC, input.width); ++p)
                    {
                        for (int q = 0; q < Math.Min(j + MAGIC, input.height); ++q)
                        {
                            if (input.grayDegree[p, q] <= threshold)
                            {
                                res.SetPixel(p, q, Color.FromArgb(0, 0, 0));
                            }
                            else
                            {
                                res.SetPixel(p, q, Color.FromArgb(255, 255, 255));
                            }
                        }
                    }
                }
            }

            return new myPicture(res);
        }
    }
}
