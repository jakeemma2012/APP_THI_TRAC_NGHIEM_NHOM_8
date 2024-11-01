using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_THI_TRAC_NGHIEM.StudentFormExam
{
    public partial class frmEnd : Form
    {
        public frmEnd(string Name,int numQ,int NumRight,float point,int TotalNum)
        {
            InitializeComponent();
            txtName.Text += Name;
            txtNumQ.Text += numQ + "/" + TotalNum;
            txtNumRight.Text += NumRight + "/" + TotalNum;
            txtPoint.Text += point.ToString("0.000");
        }

        private void frmEnd_Load(object sender, EventArgs e)
        {

        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmEnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
