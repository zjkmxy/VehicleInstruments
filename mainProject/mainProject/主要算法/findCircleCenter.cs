using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class findCircleCenter
    {
        matrix A, AT, B;

        //计算3元线性方程组的解, 输入mat为3*4的矩阵，将方程组的解转为圆的(x,y,r)三元组输出
        circle cal(matrix mat)
        {
            //gauss消元
            for (int i = 0; i < 2; ++ i)
            {
                if (mat.a[i, i] == 0)
                {
                    int r = i;
                    for (int j = i + 1; j < 3; ++j)
                    {
                        if (mat.a[j, j] != 0)
                        {
                            r = j;
                            break;
                        }
                    }
                    for (int j = i; j < 4; ++j)
                    {
                        double tmp = mat.a[i, j];
                        mat.a[i, j] = mat.a[r, j];
                        mat.a[r, j] = tmp;
                    }
                }
                for (int j = i + 1; j < 3; ++j)
                {
                    double f = mat.a[j, i] / mat.a[i, i];
                    for (int k = i; k < 4; ++k)
                    {
                        mat.a[j, k] -= f * mat.a[i, k];
                    }
                }
            }

            //计算解并生成circle实例
            double l = mat.a[2, 3] / mat.a[2, 2];
            double n = (mat.a[1, 3] - mat.a[1, 2] * l) / mat.a[1, 1];
            double m = (mat.a[0, 3] - mat.a[0, 2] * l - mat.a[0, 1] * n) / mat.a[0, 0];
            double X = m / 2.0;
            double Y = n / 2.0;
            double R = Math.Sqrt(l + X * X + Y * Y);
            return new circle(X, Y, R);
        }

        //计算圆的圆心，输入为自定义图片类input，输出为三元组(x,y,r)
        //对input的限制：只包含单圆环
        public circle doFind(myPicture input)
        {
            
            //从圆周上对称取10组点
            int cnt = 0;

            LinkedList<myPair> arr = new LinkedList<myPair>();

            for (int i = 2; i < input.width; i += 8)
            {
                for (int j = 5; j < input.height; ++j)
                {
                    if (input.grayDegree[i, j] == 255)
                    {
                        cnt++;
                        arr.AddLast(new myPair(i, j));
                        for (int k = input.height - 5; k >= 0; --k)
                        {
                            if (input.grayDegree[i, k] == 255)
                            {
                                arr.AddLast(new myPair(i, k));
                                break;
                            }
                        }
                        break;
                    }
                }
                if (cnt == 10) break;
            }

            //最小二乘法求解圆心
            A = new matrix(2 * cnt, 3);
            AT = new matrix(3, 2 * cnt);
            B = new matrix(2 * cnt, 1);

            int cur = 0;
            foreach (myPair p in arr)
            {
                int x = p.x;
                int y = p.y;
                A.a[cur, 0] = x;
                A.a[cur, 1] = y;
                A.a[cur, 2] = 1;
                AT.a[0, cur] = x;
                AT.a[1, cur] = y;
                AT.a[2, cur] = 1;
                B.a[cur, 0] = 1.0 * x * x + 1.0 * y * y;
                cur++;
            }

            matrix coef = AT.doMul(A);
            matrix b = AT.doMul(B);

            matrix mat = new matrix(3, 4);

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    mat.a[i, j] = coef.a[i, j];
                }
            }

            mat.a[0, 3] = b.a[0, 0];
            mat.a[1, 3] = b.a[1, 0];
            mat.a[2, 3] = b.a[2, 0];

            return cal(mat);
        }
    }
}
