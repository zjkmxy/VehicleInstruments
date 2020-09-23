using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class myPicture
    {
        public int width, height;
        public int[,] grayDegree;
        public Bitmap picture;
        public int[] count;
        public int all, pixelCount;
        public double median, average, SD;
        public string path;
        myPicture() { }
        public myPicture(Bitmap input, string fileName = null)
        {
            path = fileName;
            picture = input;
            width = input.Width;
            height = input.Height;
            grayDegree = new int[width, height];
            count = new int[256];
            //load picture to cache, speed up
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Color curPixel = input.GetPixel(i, j);
                    grayDegree[i, j] = (curPixel.R * 77 + curPixel.G * 150 + curPixel.B * 29 + 128) >> 8;
                }
            }
            //calculate count array, pixelCount, median, average, SD
            all = 0;
            int size = width * height;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    int val = grayDegree[i, j];
                    count[val]++;
                    all += val;
                }
            }
            average = 1.0 * all / size;
            int preSum = 0;
            int maxVal = 0;
            int middle_pos = size % 2 == 0 ? size / 2 : size / 2 + 1;
            for (int i = 0; i < 256; ++i)
            {
                SD += 1.0 * count[i] * (i - average) * (i - average);
                if (count[i] > maxVal) maxVal = count[i];
                if (count[i] != 0) ++pixelCount;
                if (count[i] != 0)
                {
                    if (preSum < middle_pos && preSum + count[i] >= middle_pos)
                    {
                        if (preSum + count[i] > middle_pos)
                        {
                            median = i;
                        }
                        else
                        {
                            median = 1.0 * (i + i + 1) / 2.0;
                        }
                    }
                }
                preSum += count[i];
            }
            SD /= size;
            SD = Math.Sqrt(SD);
            average = 1.0 * ((int)(average * 1000000.0)) / 1000000.0;
            SD = 1.0 * ((int)(SD * 1000000.0)) / 1000000.0;
        }

        public myPicture to01Pic()
        {
            myPicture ret = this;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    int val = grayDegree[i, j];
                    ret.picture.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }
            return ret;
        }

        public int getGrayDegree(int x, int y)
        {
            if (x < 0 || x >= width) return 0;
            if (y < 0 || y >= height) return 0;
            return grayDegree[x, y];
        }

        public int calByNearest(double x, double y)
        {
            if (x < 0 || x >= width) return 0;
            if (y < 0 || y >= height) return 0;
            int tx = (int)(10.0 * x);
            int ty = (int)(10.0 * y);
            int x0 = tx / 10;
            int x1 = x0 + 1;
            int y0 = ty / 10;
            int y1 = y0 + 1;
            int sx, sy;
            if (tx % 10 >= 5) sx = x1;
            else sx = x0;
            if (ty % 10 >= 5) sy = y1;
            else sy = y0;
            return getGrayDegree(sx, sy);
        }

        public int calByLinerInsert(double x, double y)
        {
            if (x < 0 || x >= width) return 0;
            if (y < 0 || y >= height) return 0;
            int tx = (int)(10.0 * x);
            int ty = (int)(10.0 * y);
            int x0 = tx / 10;
            int x1 = x0 + 1;
            int y0 = ty / 10;
            int y1 = y0 + 1;
            int f00 = getGrayDegree(x0, y0);
            int f01 = getGrayDegree(x0, y1);
            int f10 = getGrayDegree(x1, y0);
            int f11 = getGrayDegree(x1, y1);
            double dx = x - x0;
            double dy = y - y0;
            double val = 1.0 * (f10 - f00) * dx + 1.0 * (f01 - f00) * dy + 1.0 * (f11 + f00 - f01 - f10) * dx * dy + f00;
            return (int)val;
        }
    }
}
