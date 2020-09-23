using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class RANSAC
    {
        public RANSAC()
        {
        }

        //程序功能：利用最小二乘法拟合直线
        //输入：二维点
        //输出：拟合直线
        line calLine(LinkedList<myPair> input)
        {
            matrix A = new matrix(input.Count, 2);
            matrix AT = new matrix(2, input.Count);
            matrix B = new matrix(input.Count, 1);

            for (int i = 0; i < input.Count; ++i)
            {
                myPair cur = input.ElementAt(i);
                A.a[i, 0] = cur.x;
                A.a[i, 1] = cur.y;
                AT.a[0, i] = cur.x;
                AT.a[1, i] = cur.y;
                B.a[i, 0] = 100;
            }

            matrix coef = AT.doMul(A);
            matrix b = AT.doMul(B);
            matrix mat = new matrix(2, 3);

            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    mat.a[i, j] = coef.a[i, j];
                }
            }
            mat.a[0, 2] = b.a[0, 0];
            mat.a[1, 2] = b.a[1, 0];

            double BB = (mat.a[0, 0] * mat.a[1, 2] - mat.a[1, 0] * mat.a[0, 2]) / (mat.a[1, 1] * mat.a[0, 0] - mat.a[0, 1] * mat.a[1, 0]);
            double AA = (mat.a[0, 2] - mat.a[0, 1] * BB) / mat.a[0, 0];
            return new line(AA, BB, -100);
        }

        //函数功能：利用RANSAC算法从图像中提取直线，RANSAC对噪声敏感度小
        //输入：二值化图像input，目标直线的一个端点center
        //输出：目标直线方程
        public line doRANSAC(myPicture input, myPair center)
        {
            LinkedList<myPair> arr = new LinkedList<myPair>();
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    if (input.grayDegree[i, j] == 255)
                    {
                        arr.AddLast(new myPair(i, j));
                    }
                }
            }

            Random rd = new Random(13);
            line ret = new line(0, 0, 0);
            double besterror = 1000000000000;
            int bound = (int)(0.07 * arr.Count); 

            for (int iter = 0; iter < 100; ++iter)
            {
                int sampleIndex = rd.Next() % arr.Count;
                myPair sample = arr.ElementAt(sampleIndex);
                line cur = new line(center, sample);
                LinkedList<myPair> alsoinliers = new LinkedList<myPair>();
                foreach (myPair p in arr)
                {
                    double d = cur.distance(p);
                    if (d <= 4)
                    {
                        alsoinliers.AddLast(p);
                    }
                }

                if (alsoinliers.Count >= bound)
                {
                    alsoinliers.AddLast(sample);
                    line better = calLine(alsoinliers);
                    double thiserror = 0;
                    foreach (myPair p in alsoinliers)
                    {
                        double dis = better.distance(p);
                        thiserror += dis * dis;
                    }
                    thiserror /= alsoinliers.Count;
                    if (thiserror < besterror)
                    {
                        besterror = thiserror;
                        ret = better;
                    }
                }
            }

            return ret;

            /*
            for (int i = 0; i < input.width; ++i)
            {
                for (int j = 0; j < input.height; ++j)
                {
                    double val = Math.Abs(ret.A * i + ret.B * j + ret.C);
                    if (val <= 1)
                    {
                        input.picture.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                    }
                }
            }
            */
            //return input;
        }

        //函数功能：确定仪表盘指针的方向向量
        //输入：二值图像input，直线方程ret，仪表盘中心o
        //输出：仪表盘指针上的某一个点
        public myPair doFind(myPicture input, line ret, circle o)
        {
            if (Math.Abs(ret.B) < 0.000001)
            {
                return new myPair((int)o.x, 0);
            }

            int MAGIC = (int)(input.width * 0.18);
            int cnt1 = 0, cnt2 = 0;
            double K = -ret.A / ret.B;
            double B = -ret.C / ret.B;

            for (int dx = 1; dx <= MAGIC; ++dx)
            {
                double x = o.x + dx;
                double y = K * x + B;
                int xx = (int)x;
                int yy = (int)y;
                if (xx + 2 >= input.width || xx - 2 < 0)  break;
                if (yy + 2 >= input.height || yy - 2 < 0) break;
                for (int i = -2; i <= 2; ++i)
                {
                    for (int j = -2; j <= 2; ++j)
                    {
                        if (input.grayDegree[(int)(x + i), (int)(y + j)] == 255)
                        {
                            cnt1++;
                        }
                    }
                }
            }

            for (int dx = 1; dx <= MAGIC; ++dx)
            {
                double x = o.x - dx;
                double y = K * x + B;
                int xx = (int)x;
                int yy = (int)y;
                if (xx + 2 >= input.width || xx - 2 < 0) break;
                if (yy + 2 >= input.height || yy - 2 < 0) break;
                for (int i = -2; i <= 2; ++i)
                {
                    for (int j = -2; j <= 2; ++j)
                    {
                        if (input.grayDegree[(int)(x + i), (int)(y + j)] == 255)
                        {
                            cnt2++;
                        }
                    }
                }
            }

            if (cnt1 > cnt2)
            {
                double x = o.x + MAGIC;
                double y = K * x + B;
                return new myPair((int)x, (int)y);
            }
            else
            {
                double x = o.x - MAGIC;
                double y = K * x + B;
                return new myPair((int)x, (int)y);
            }
        }
    }
}
