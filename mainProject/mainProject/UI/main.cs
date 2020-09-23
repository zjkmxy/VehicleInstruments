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
    public partial class main : Form
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
        public main()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileName = new OpenFileDialog();
            fileName.InitialDirectory = "c:\\";
            fileName.FilterIndex = 2;
            fileName.RestoreDirectory = true;
            if (fileName.ShowDialog() == DialogResult.OK)
            {
                Image pic = Image.FromFile(fileName.FileName);
                Pic = new myPicture((Bitmap)pic, fileName.FileName);
                this.rawPictureDisplay.Image = Pic.picture;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isSave = true;
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "图片保存";
            saveImageDialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif|png|*.png";

            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName.ToString();

                if (fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();

                    System.Drawing.Imaging.ImageFormat imgformat = null;

                    if (fileExtName != "")
                    {
                        switch (fileExtName)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "gif":
                                imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                MessageBox.Show("只能存取为: jpg,bmp,gif,png 格式");
                                isSave = false;
                                break;
                        }

                    }

                    //默认保存为JPG格式  
                    if (imgformat == null)
                    {
                        imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }

                    if (isSave)
                    {
                        try
                        {
                            Pic.picture.Save(fileName, imgformat);
                        }
                        catch
                        {
                            MessageBox.Show("保存失败,请再次尝试!");
                        }
                    }
                }

            }
        }

        private void 指针式仪表盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (Pic != null) {
				Form newForm = new inPut(Pic);
				newForm.ShowDialog();
				newForm.Dispose();
			}
        }

        private void 数字式仪表盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (Pic != null)
			{
				getDigits getnum = new getDigits(Pic);
				double ans = getnum.getNumber();
				Form newForm = new ans(ans);
				newForm.ShowDialog();
				newForm.Dispose();
			}
        }

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
    }
}
