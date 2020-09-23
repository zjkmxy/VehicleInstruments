using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProject
{
    //矩阵类，提供矩阵的基本运算
    public class matrix
    {
        public double[,] a;
        public int n, m;
        matrix()
        {
        }
        public matrix(int _n, int _m)
        {
            n = _n;
            m = _m;
            a = new double[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    a[i,j] = 0;
                }
            }
        }
        //矩阵乘法
        public matrix doMul(matrix b)
        {
            matrix ret = new matrix(this.n, b.m);
            for (int i = 0; i < this.n; ++i)
            {
                for (int j = 0; j < b.m; ++j)
                {
                    for (int k = 0; k < this.m; ++k)
                    {
                        ret.a[i,j] += this.a[i,k] * b.a[k,j]; 
                    }
                }
            }
            return ret;
        }
        //3阶矩阵求逆
        matrix calInv()
        {
            matrix ret = new matrix(this.n, this.m);
            ret.a[0, 0] = a[1, 1] * a[2, 2] - a[1, 2] * a[2, 1];
            ret.a[0, 1] = a[0, 2] * a[2, 1] - a[0, 1] * a[2, 2];
            ret.a[0, 2] = a[0, 1] * a[1, 2] - a[0, 2] * a[1, 1];

            ret.a[1, 0] = a[1, 2] * a[3, 0] - a[1, 0] * a[2, 2];
            ret.a[1, 1] = a[0, 0] * a[2, 2] - a[0, 2] * a[2, 0];
            ret.a[1, 2] = a[1, 0] * a[0, 2] - a[0, 0] * a[1, 2];
            
            ret.a[2, 0] = a[1, 0] * a[2, 1] - a[1, 1] * a[2, 0];
            ret.a[2, 1] = a[0, 1] * a[2, 0] - a[0, 0] * a[2, 1];
            ret.a[2, 2] = a[0, 0] * a[1, 1] - a[1, 0] * a[0, 1];
            return ret;
        }
    }
}
