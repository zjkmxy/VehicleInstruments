using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace mainProject
{
    public class findCircleInit
    {
        int[,] gray;//灰度
        int[,] vis;//dfs标记
        int[,] dir = new int[4, 2] { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1 } };
        int width, height, cnt;//图片宽和高，记录连通块包含像素大小
        public findCircleInit() { }

        //标记每个点属于的连通块
        void dfs(int x, int y, int no)
        {
            cnt++;
            vis[x, y] = no;
            for (int i = 0; i < 4; i++)
            {
                int xx = x + dir[i, 0];
                int yy = y + dir[i, 1];
                if (xx >= 0 && xx < width && yy >= 0 && yy < height && vis[xx, yy] == 0 && gray[xx, yy] == 255)
                {
                    dfs(xx, yy, no);
                }
            }
        }

        //输入：锐化和二值化后的图像，输出：找到的最大连通块，即最外层圆
        public myPicture init(myPicture input)
        {
            width = input.width;
            height = input.height;
            gray = new int[width, height];
            vis = new int[width, height];
            //获取灰度值
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gray[i, j] = input.picture.GetPixel(i, j).B;
                    vis[i, j] = 0;
                }
            }

            //找到最大连通块
            int cou = 0, no = 1, ans = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (vis[i, j] == 0 && gray[i, j] == 255)
                    {
                        cnt = 0;
                        dfs(i, j, no);
                        if (cou < cnt)
                        {
                            cou = cnt;
                            ans = no;
                        }
                        no++;
                    }
                }
            }
            //将最大连通块变为白色，其他区域变为黑色
            Bitmap res = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (vis[i, j] == ans)
                    {
                        res.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        res.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            return new myPicture(res);
        }

        //输入：对最大连通块锐化后的图像，即变成两个同心圆，输出：内层圆
        public myPicture doHough(myPicture input)
        {
            int width = input.width, height = input.height;
            Bitmap res = new Bitmap(width, height);
            int sx = width / 2, sy = height / 2;
            //找到内层圆上的一个像素点
            for (int i = sx; i >= 0; i--)
            {
                if (input.grayDegree[i, sy] == 255)
                {
                    sx = i;
                    break;
                }
            }
            //初始化
            gray = new int[width, height];
            vis = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gray[i, j] = input.grayDegree[i, j];
                    vis[i, j] = 0;
                }
            }
            //dfs找内层圆
            dfs(sx, sy, 1);
            //修改图像
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (vis[i, j] == 1)
                    {
                        res.SetPixel(i, j, Color.FromArgb(255, 255, 255));
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
