using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace APP_THI_TRAC_NGHIEM.Login_Regis
{
    public partial class frmRegister : Form
    {
        public Model1 context = Services.getInstance().context;
        private Form parent;

        public frmRegister(Form p)
        {
            InitializeComponent();
            this.parent = p;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void btHidePass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = btHidePass.Checked ? '\0' : '*';
        }

        private void btSigUp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != ""
              && txtPassword.Text.Trim() != "")
            {
                Account acc = AccountServices.gI().getAccountLogin(txtUsername.Text.Trim());
                if (acc == null)
                {
                    acc = new Account();

                    acc.Username = txtUsername.Text.Trim();
                    acc.Password = txtPassword.Text.Trim();

                    context.Accounts.Add(acc);
                    context.SaveChanges();

                    MessageBox.Show("Đăng ký thành công!\nHãy quay lại trang đăng nhập nhé !");
                    txtPassword.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại !");
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin để đăng ký !");
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
