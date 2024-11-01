using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_THI_TRAC_NGHIEM.Function
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            setButtonFollowRole();
        }

        private void btThiSinh_Click(object sender, EventArgs e)
        {
            frmThiSinh frm = new frmThiSinh();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            hideChild();
            frm.Show();
        }


        void hideChild()
        {
            this.SuspendLayout();
            foreach (Form mdiChild in this.MdiChildren)
            {
                mdiChild.Hide();
            }
            this.ResumeLayout();
        }

        private void btThiSinh_Click_1(object sender, EventArgs e)
        {
            frmQuanLy frm = new frmQuanLy();
            frm.MdiParent = this;
            frm.WindowState= FormWindowState.Maximized; 
            hideChild();
            frm.Show();
        }

        private void btCauHoi_Click(object sender, EventArgs e)
        {
            frmCauHoi frm = new frmCauHoi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            hideChild();
            frm.Show();
        }

        private void btKetQua_CLick(object sender, EventArgs e)
        {
            frmKetQua frm = new frmKetQua();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            hideChild();
            frm.Show();
        }

        private void btCaTHi_Click(object sender, EventArgs e)
        {
            frmCaThi frm = new frmCaThi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            hideChild(); 
            frm.Show();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        void setButtonFollowRole()
        {
            Account a = Services.getInstance().account;
            switch (a.Role)
            {
                case 0:
                    break;
                case 1:
                    setbutton(false);
                    break;
                case 2:
                    setbutton(true);
                    break;
            }
        }

        void setbutton(bool status)
        {
            btThiSinh.Enabled = status;
            btQuanly.Enabled = status;
            btCaTHi.Enabled = status;
        }
    }
}
