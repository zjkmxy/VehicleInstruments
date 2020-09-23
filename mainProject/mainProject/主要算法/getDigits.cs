using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace mainProject
{
    public class getDigits
    {
        string filePath, textPath;
        double ans;
        getDigits() { }

        //输入：原图
        public getDigits(myPicture input)
        {
            int width = input.width;
            int height = input.height;
            //生成图片
            Bitmap pic = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int cur = input.grayDegree[i, j];
                    pic.SetPixel(i, j, Color.FromArgb(cur, cur, cur));
                }
            }

            //获取文件路径和文件格式
            int len = input.path.Length, pos = -1;
            for (int i = len - 1; i >= 0; i--)
            {
                if (input.path[i] == '.')
                {
                    pos = i;
                }
            }
            if (pos != -1)
            {
                filePath = input.path.Substring(0, pos) + "_gray.bmp";
            }
            else
            {
                filePath = input.path + ".bmp";
            }
            System.Drawing.Imaging.ImageFormat imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
            //保存图片
            pic.Save(filePath, imgformat);

            //调用第三方软件
            Process myPro = new Process();
            myPro.StartInfo.FileName = "cmd.exe";
            myPro.StartInfo.UseShellExecute = false;
            myPro.StartInfo.RedirectStandardInput = true;
            myPro.StartInfo.RedirectStandardOutput = true;
            myPro.StartInfo.RedirectStandardError = true;
            myPro.StartInfo.CreateNoWindow = true;
            myPro.Start();
            textPath = filePath.Substring(0, filePath.Length - 4);
            string str = "tesseract " + filePath + " " + textPath + " digits";
            myPro.StandardInput.WriteLine(str);
            myPro.StandardInput.AutoFlush = true;
            myPro.Close();
        }

        //获取图像上的数字
        public double getNumber()
        {
            //获取数字
            for (int i = 0; i < 200000000; i++) ;
            StreamReader objReader = new StreamReader(textPath + ".txt"); ;
            string sLine = "";
            sLine = objReader.ReadLine();
            objReader.Close();
            if (sLine == null)
            {
                ans = 0;
                return ans;
            }
            int len = sLine.Length;
            ans = 0;
            double p = 1;
            int flag = 0;
            for (int i = 0; i < len; i++)
            {
                if (sLine[i] == ' ')
                {
                    continue;
                }
                else if (sLine[i] == '.')
                {
                    flag = 1;
                    p = 0.1;
                }
                else if (flag == 0)
                {
                    ans = ans * 10 + sLine[i] - '0';
                }
                else
                {
                    ans = ans + (sLine[i] - '0') * p;
                    p *= 0.1;
                }
            }
            return ans;
        }
    }
}
