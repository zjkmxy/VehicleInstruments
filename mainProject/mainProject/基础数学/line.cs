using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProject
{
    public class line
    {
        //Ax + By + C = 0 
        public double A, B, C;
        public line(double _A, double _B, double _C)
        {
            A = _A;
            B = _B;
            C = _C;
        }
        //根据直线的两个端点P，Q进行初始化
        public line(myPair P, myPair Q)
        {
            if (P.x == Q.x)
            {
                A = 1;
                B = 0;
                C = -P.x;
                return;
            }

            if (P.y == Q.y)
            {
                A = 0;
                B = 1;
                C = -P.y;
                return;
            }

            B = 1;
            A = 1.0 * (Q.y - P.y) / (P.x - Q.x);
            C = -(A * P.x + B * P.y);
        }
        //计算该直线到点P的距离
        public double distance(myPair P)
        {
            return Math.Abs(A * P.x + B * P.y + C) / Math.Sqrt(A * A + B * B);
        }
    }
}
