using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainProject
{
    public partial class inPut : Form
    {
        sharpKirsch sharp1 = new sharpKirsch();
        sharpLaplacian sharp2 = new sharpLaplacian();
        sharpRoberts sharp3 = new sharpRoberts();
        sharpSobel sharp4 = new sharpSobel();

        smoothAverage smooth1 = new smoothAverage();
        smoothKNNF smooth2 = new smoothKNNF();
        smoothMedian smooth3 = new smoothMedian();
        smoothMinSD smooth4 = new smoothMinSD();

        myPicture Pic;

        public inPut(myPicture _Pic)
        {
            Pic = _Pic;
            InitializeComponent();
        }

        private double angle(myPair left, myPair right, circle o)
        {
            return Math.Acos(((left.x * right.x - o.x * (left.x + right.x) + o.x * o.x) + (left.y * right.y - o.y * (left.y + right.y) + o.y * o.y)) / (Math.Sqrt((left.x - o.x) * (left.x - o.x) + (left.y - o.y) * (left.y - o.y)) * Math.Sqrt((right.x - o.x) * (right.x - o.x) + (right.y - o.y) * (right.y - o.y))));
        }

        //函数功能：对main.cs传入的图像进行处理，并将结果传递到ans.cs显示
        public void domain()
        {
			//处理输入
			double low = 0.0;
			double high = 1.0;
			try
			{
				low = Convert.ToDouble(smallInput.Text);
				high = Convert.ToDouble(largeInput.Text);
			}
			catch
			{
				return;
			}
			

            OTSU B = new OTSU();
            //锐化、二值化
            myPicture ret = B.doOTSU(sharp4.doSharp(Pic));
            myPicture res = ret;
            //找圆心之前的预处理
            findCircleInit circle = new findCircleInit();
            ret = circle.init(ret);
            ret = sharp4.doSharp(ret);
            ret = circle.doHough(ret);

            //找圆心
            circle o = new findCircleCenter().doFind(ret);
            
            //找指针
            ret = new findLineInit().doFind(Pic, o);
            myPicture tmp = sharp1.doSharp(ret);
            tmp = smooth2.doSmooth(tmp);
            tmp = B.doOTSU(tmp);
            RANSAC R = new RANSAC();
            myPair L = R.doFind(smooth2.doSmooth(B.doOTSU(sharp4.doSharp(Pic))), R.doRANSAC(tmp, new myPair((int)o.x, (int)o.y)), o);


            //找刻度线的预处理
            eraseCircleElement ECE = new eraseCircleElement(res, (int)o.r, (int)o.x, (int)o.y);
            int r = ECE.solve();
            res = ECE.erase(r - 1);

            //找到左右两端的刻度线
            findTick ticks = new findTick(res, r - 1, (int)o.x, (int)o.y);
            myPair left = ticks.FindLeft(), right = ticks.FindRight();

            //求角度
            double thta = 2 * Math.PI - angle(left, right, o);
            double alpha;
            if (L.x <= o.x)
            {
                alpha = angle(left, L, o);
            }
            else
            {
                alpha = thta - angle(L, right, o);
            }
            double ans = low + (high - low) * (alpha + Math.PI / 180) / thta;

            Form newForm = new ans(ans);
            newForm.ShowDialog();
			newForm.Dispose();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            domain();
        }

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
    }
}
