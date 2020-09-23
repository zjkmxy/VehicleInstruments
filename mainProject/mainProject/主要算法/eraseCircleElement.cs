using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class eraseCircleElement
    {
        Bitmap res;
        int [,] gray;
        int width, height;
        int radius, circle_x, circle_y;
        //输入：锐化和二值化后的图像，r是找到的圆环半径，x，y是圆心位置
        public eraseCircleElement(myPicture Pic, int r, int x, int y)
        {
            width = Pic.width;
            height = Pic.height;
            gray = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gray[i,j] = Pic.grayDegree[i,j];
                }
            }
            res = new Bitmap(width, height);
            radius = r;
            circle_x = x;
            circle_y = y;
        }

        //输出：应该擦除距离圆心大于r的图像去除噪声，留出刻度线
        public int solve()
        {
            for (int r = radius - 5; r < radius; r++)
            {
                int cnt = 0;
                for (int x = circle_x - r; x <= circle_x + r; x++)
                {
                    double y = Math.Sqrt((double)(r * r - (circle_x - x) * (circle_x - x)));
                    for (int k = -1; k <= 1; k++)
                    {
                        if (gray[x, (int)(y + k) + circle_y] == 255)
                        {
                            cnt++;
                        }
                        if (gray[x, circle_y - (int)(y + k)] == 255)
                        {
                            cnt++;
                        }
                    }
                }
                if (cnt * 2 >= 4 * r)
                {
                    return r;
                }
            }
            return radius;
        }

        //输入：应该擦除的r，输出：擦除后的图像
        public myPicture erase(int r)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int dis = (i - circle_x) * (i - circle_x) + (j - circle_y) * (j - circle_y);
                    if (dis < r * r)
                    {
                        res.SetPixel(i, j, Color.FromArgb(gray[i, j], gray[i, j], gray[i, j]));
                    }
                    else
                    {
                        res.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            return new myPicture(res);
        }
    }
}
