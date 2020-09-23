using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class sharpLaplacian
    {
        public sharpLaplacian()
        {
        }
        public myPicture doSharp(myPicture input)
        {
            matrix mat = new matrix(3, 3);
            mat.a[0, 1] = -1;
            mat.a[1, 0] = -1;
            mat.a[1, 1] = 4;
            mat.a[1, 2] = -1;
            mat.a[2, 1] = -1;
            smoothTemplate smooth = new smoothTemplate();
            return smooth.doSmooth(input, mat);
        }
    }
}
