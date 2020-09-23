using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mainProject
{
    public class smoothMinSD
    {
        class square
        {
            public double SD;
            public double average;
            public square()
            {
            }
            public square(List<int> input)
            {
                double sum = 0;
                foreach (int val in input)
                {
                    sum += val;
                }
                average = sum / (1.0 * input.Capacity);
                SD = 0;
                foreach (int val in input)
                {
                    SD += 1.0 * (val - average) * (val - average);
                }
                SD /= 1.0 * input.Capacity;
            }
        }
        class squareCmp : IComparer<square>
        {
            public int Compare(square a, square b)
            {
                return a.SD.CompareTo(b.SD);
            }
        }
        public smoothMinSD()
        {
        }
        public myPicture doSmooth(myPicture input)
        {
            Bitmap ret = new Bitmap(input.width, input.height);
            for (int i = 2; i + 2 < input.width; ++i)
            {
                for (int j = 2; j + 2 < input.height; ++j)
                {
                    List<int> part0 = new List<int> { input.grayDegree[i-1, j-2], input.grayDegree[i, j-2], input.grayDegree[i+1, j-2], input.grayDegree[i-1, j-1], input.grayDegree[i, j-1], input.grayDegree[i+1, j-1], input.grayDegree[i, j]};
                    List<int> part1 = new List<int> { input.grayDegree[i-1, j+2], input.grayDegree[i, j+2], input.grayDegree[i+1, j+2], input.grayDegree[i-1, j+1], input.grayDegree[i, j+1], input.grayDegree[i+1, j+1], input.grayDegree[i, j]};
                    List<int> part2 = new List<int> { input.grayDegree[i-2, j-1], input.grayDegree[i-2, j], input.grayDegree[i-2, j+1], input.grayDegree[i-1, j-1], input.grayDegree[i-1, j], input.grayDegree[i-1, j+1], input.grayDegree[i, j]};
                    List<int> part3 = new List<int> { input.grayDegree[i+2, j-1], input.grayDegree[i+2, j], input.grayDegree[i+2, j+1], input.grayDegree[i+1, j-1], input.grayDegree[i+1, j], input.grayDegree[i+1, j+1], input.grayDegree[i, j]};
                    List<int> part4 = new List<int> { input.grayDegree[i-2, j-2], input.grayDegree[i-2, j-1], input.grayDegree[i-1, j-2], input.grayDegree[i-1, j-1], input.grayDegree[i-1, j], input.grayDegree[i, j-1], input.grayDegree[i, j]};
                    List<int> part5 = new List<int> { input.grayDegree[i+2, j-2], input.grayDegree[i+2, j-1], input.grayDegree[i+1, j-2], input.grayDegree[i+1, j-1], input.grayDegree[i+1, j], input.grayDegree[i, j-1], input.grayDegree[i, j]};
                    List<int> part6 = new List<int> { input.grayDegree[i+2, j+2], input.grayDegree[i+2, j+1], input.grayDegree[i+1, j+2], input.grayDegree[i+1, j+1], input.grayDegree[i+1, j], input.grayDegree[i, j+1], input.grayDegree[i, j]};
                    List<int> part7 = new List<int> { input.grayDegree[i-2, j+2], input.grayDegree[i-2, j+1], input.grayDegree[i-1, j+2], input.grayDegree[i-1, j+1], input.grayDegree[i-1, j], input.grayDegree[i, j+1], input.grayDegree[i, j]};
                    List<int> part8 = new List<int> { input.grayDegree[i-1, j-1], input.grayDegree[i-1, j], input.grayDegree[i-1, j+1], input.grayDegree[i, j-1], input.grayDegree[i, j], input.grayDegree[i, j+1], input.grayDegree[i+1, j-1], input.grayDegree[i+1, j], input.grayDegree[i+1, j+1]};
                    List<square> tmp = new List<square>();
                    tmp.Add(new square(part0));
                    tmp.Add(new square(part1));
                    tmp.Add(new square(part2));
                    tmp.Add(new square(part3));
                    tmp.Add(new square(part4));
                    tmp.Add(new square(part5));
                    tmp.Add(new square(part6));
                    tmp.Add(new square(part7));
                    tmp.Add(new square(part8));
                    tmp.Sort(new squareCmp());
                    int val = (int)tmp[0].average;
                    ret.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }
            return new myPicture(ret, input.path);
        }
    }
}
