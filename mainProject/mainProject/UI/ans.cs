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
    public partial class ans : Form
    {
        public ans()
        {
            InitializeComponent();
        }

        public ans(double res)
        {
            InitializeComponent();
            label1.Text = "该仪表盘识别结果为" + Convert.ToString(res) + ".";
        }
    }
}
