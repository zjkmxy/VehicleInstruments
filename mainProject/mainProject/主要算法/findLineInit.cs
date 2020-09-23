using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class findLineInit
    {
        public findLineInit() { }
        //输入：原图和圆心信息(圆心位置和半径)，输出：直线所在区域（包含较少噪声的圆环）
        public myPicture doFind(myPicture input, circle cir)
        {
            int width = input.width, height = input.height;
            Bitmap res = new Bitmap(width, height);
            int x = (int)cir.x, y = (int)cir.y;
            //截取圆环为0.15*半径——0.5*半径
            int maxr = (int)(0.5 * cir.r), minr = (int)(0.15 * cir.r);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    res.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            //将0.15*半径——0.5*半径区域赋值成原图像内容
            for (int i = - maxr; i <= maxr; i++)
            {
                int pos1 = -1;
                for (int j = 0; j < height; j++)
                {
                    if (i * i + j * j <= maxr * maxr)
                    {
                        pos1 = j;
                        break;
                    }
                }
                int pos2 = -1;
                for (int j = height - 1; j >= 0; j--)
                {
                    if (i * i + j * j <= maxr * maxr)
                    {
                        pos2 = j;
                        break;
                    }
                }
                if (pos1 == -1)
                {
                    continue;
                }
                for (int j = pos1; j <= pos2; j++)
                {
                    if (i * i + j * j < minr * minr)
                    {
                        continue;
                    }
                    res.SetPixel(x + i, y + j, input.picture.GetPixel(x + i,y + j));
                    res.SetPixel(x + i, y - j, input.picture.GetPixel(x + i, y - j));
                }
            }
            return new myPicture(res);
        }
    }
}
