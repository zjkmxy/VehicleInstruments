using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProject
{
    public class findTick
    {
        int[,] gray;
        int radius, width, height;
        int circle_x, circle_y;
        //输入：锐化和二值化后的图像，r是擦除时使用的半径长度，x，y是圆心位置
        public findTick(myPicture Pic, int r, int x, int y)
        {
            width = Pic.width;
            height = Pic.height;
            gray = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gray[i, j] = Pic.grayDegree[i, j];
                }
            }
            radius = r;
            circle_x = x;
            circle_y = y;
        }

        //输出找到的最小刻度线的点
        public myPair FindLeft()
        {
            myPair ret = new myPair(-1, -1);
            int max1 = 0;
            for (int i = height - 1; i * 3 >= 2 * height; i--)
            {
                int sum = 0;
                for (int j = 0; j < 100; j++)
                {
                    if (gray[j, i] == 255)
                    {
                        if (gray[j + 1, i - 1] == 255 && gray[j + 2, i - 2] == 255 && gray[j + 3, i - 3] == 255 && gray[j + 4, i - 4] == 255)
                        {
                            //return new node(circle_x - (int)Math.Sqrt(radius * radius - (circle_y - i) * (circle_y - i)),i);
                            sum = (j - circle_x) * (j - circle_x) + (i - circle_y) * (i - circle_y);
                            if (Math.Sqrt(max1) + 10 < Math.Sqrt(sum))
                            {
                                ret.x = j;
                                ret.y = i;
                                max1 = sum;
                            }
                            break;
                        }
                        else if (gray[j + 1, i] == 255 && gray[j + 2, i - 1] == 255 && gray[j + 3, i - 2] == 255 && gray[j + 4, i - 3] == 255)
                        {
                            sum = (j - circle_x) * (j - circle_x) + (i - circle_y) * (i - circle_y);
                            if (Math.Sqrt(max1) + 10 < Math.Sqrt(sum))
                            {
                                ret.x = j;
                                ret.y = i;
                                max1 = sum;
                            }
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        //输出找到的最大刻度线的点
        public myPair FindRight()
        {
            myPair ret = new myPair(0, 0);
            int max1 = 0;
            for (int i = height - 1; i * 3 >= 2 * height; i--)
            {
                int sum = 0;
                for (int j = width - 1, k = 0; k < 100; k++, j --)
                {
                    if (gray[j, i] == 255)
                    {
                        if (gray[j - 1, i - 1] == 255 && gray[j - 2, i - 2] == 255 && gray[j - 3, i - 3] == 255 && gray[j - 4, i - 4] == 255)
                        {
                            sum = (j - circle_x) * (j - circle_x) + (i - circle_y) * (i - circle_y);
                            if (Math.Sqrt(max1) + 10 < Math.Sqrt(sum))
                            {
                                ret.x = j;
                                ret.y = i;
                                max1 = sum;
                            }
                            break;
                        }
                        else if (gray[j - 1, i] == 255 && gray[j - 2, i - 1] == 255 && gray[j - 3, i - 2] == 255 && gray[j - 4, i - 3] == 255)
                        {
                            sum = (j - circle_x) * (j - circle_x) + (i - circle_y) * (i - circle_y);
                            if (Math.Sqrt(max1) + 10 < Math.Sqrt(sum))
                            {
                                ret.x = j;
                                ret.y = i;
                                max1 = sum;
                            }
                            break;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
