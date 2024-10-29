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
using APP_THI_TRAC_NGHIEM.Function;
using APP_THI_TRAC_NGHIEM.StudentFormExam;

namespace APP_THI_TRAC_NGHIEM.Login_Regis
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (isValidLogin())
            {
                Account acc = AccountServices.gI().getAccountLogin(txtUsername.Text);

                if (acc != null)
                {
                    if (txtPassword.Text.CompareTo(acc.Password) == 0)
                    {
                        MessageBox.Show("Đăng nhập thành công !", "Thông báo !", MessageBoxButtons.OK);
                        this.Hide();

                        Services.getInstance().SetAccountLogin(acc);

                        if (acc.Role > 0)
                        {
                            frmHome frm = new frmHome();
                            frm.Font = new Font("Microsoft Sans Serif", 10);
                            frm.Show(this);
                        }
                        else
                        {
                            frmLobby frm = new frmLobby();
                            frm.Font = new Font("Microsoft Sans Serif", 10);
                            frm.Show(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác !", "Thông báo !"
                            , MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !", "Thông báo !"
                            , MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Hãy điền tài khoản và mật khẩu để đăng nhập !"
                    , "Thông báo", MessageBoxButtons.OK);
            }
        }

        bool isValidLogin()
        {
            return txtUsername.Text.Trim() != ""
                && txtPassword.Text.Trim() != "";
        }

        private void btHidePass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = btHidePass.Checked ? '\0' : '*';
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister(this);
            frm.Show();
            this.Hide();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
