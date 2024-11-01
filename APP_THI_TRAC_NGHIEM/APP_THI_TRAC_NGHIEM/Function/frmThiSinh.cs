using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace APP_THI_TRAC_NGHIEM.Function
{
    public partial class frmThiSinh : Form
    {

        public Model1 context = Services.getInstance().context;
        List<Student> studens = new List<Student>();

        public frmThiSinh()
        {
            InitializeComponent();
        }

        private void frmThiSinh_Load(object sender, EventArgs e)
        {
            load();
        }

        void clear()
        {
            txtMaTS.Text = string.Empty;
            txtTenTS.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtLop.Text = string.Empty;
            txtSchool.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtnote.Text = string.Empty;
            txtUserID.Text = string.Empty;
        }

        void load()
        {
            studens = StudentServices.gI().getAllStudent();
            dgvThiSinh.Rows.Clear();

            foreach (var item in studens)
            {
                int rowsindex = dgvThiSinh.Rows.Add();
                dgvThiSinh.Rows[rowsindex].Cells[0].Value = item.StudentID;
                dgvThiSinh.Rows[rowsindex].Cells[1].Value = item.UserID;
                dgvThiSinh.Rows[rowsindex].Cells[2].Value = item.StudentName;
                dgvThiSinh.Rows[rowsindex].Cells[3].Value = item.Address;
                dgvThiSinh.Rows[rowsindex].Cells[4].Value = item.Birt.ToString("dd/MM/yyyy");
                dgvThiSinh.Rows[rowsindex].Cells[5].Value = item.School;
                dgvThiSinh.Rows[rowsindex].Cells[6].Value = item.Class;
                dgvThiSinh.Rows[rowsindex].Cells[7].Value = item.Account.Status.StatusName;


                if (item.Account.Note != null)
                {
                    dgvThiSinh.Rows[rowsindex].Cells[8].Value = item.Account.Note;
                }
                else
                {
                    dgvThiSinh.Rows[rowsindex].Cells[8].Value = "";
                }

                dgvThiSinh.Rows[rowsindex].Cells[9].Value = item.DateStart.ToString("dd/MM/yyyy");

                dgvThiSinh.Rows[rowsindex].Cells[10].Value = item.DateEnd?.ToString("dd/MM/yyyy") ?? "";

                if(item.Image != null)
                {
                    dgvThiSinh.Rows[rowsindex].Cells[11].Value = item.Image;
                }
            }


            List<Account> ac = AccountServices.gI().getAllAccountStudent();
            txtUserID.DataSource = ac;
            txtUserID.DisplayMember = "UserID";
            txtUserID.ValueMember = "UserID";
            txtUserID.Text = string.Empty;


            List<Status> stt = Services.getInstance().getAllStatus();
            txtStatus.DataSource = stt;
            txtStatus.DisplayMember = "StatusName";
            txtStatus.ValueMember = "StatusID";
            txtStatus.Text = string.Empty;

        }



        bool CheckAddThiSinh()
        {
            if (txtMaTS.Text.Trim() != ""
                && txtUserID.Text.Trim() != ""
                && txtTenTS.Text.Trim() != ""
                && txtNgaySinh.Text.Trim() != ""
                && txtDiaChi.Text.Trim() != ""
                && txtSchool.Text.Trim() != ""
                && txtLop.Text.Trim() != ""
                && txtStatus.Text.Trim() != ""
                && txtNhaphoc.Text.Trim() != "")
            {
                if (!txtUserID.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("User Id chỉ có thể là số !", "Lỗi !", MessageBoxButtons.OK);
                    return false;
                }
                if (!txtMaTS.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("Mã số Thí sinh chỉ có thể là số !", "Lỗi !", MessageBoxButtons.OK);
                    return false;
                }
                Student us = ThiSinhServices.gI().getThiSinhByUserId(int.Parse(txtUserID.Text.Trim()));
                if (us != null)
                {
                    MessageBox.Show("Đã tồn tại thi sinh với ID User : " + txtUserID.Text.Trim());
                    return false;
                }
                if (int.Parse(txtStatus.SelectedValue.ToString()) == 0)
                {
                    if (txtRoiDi.Text.Trim() == "")
                    {
                        MessageBox.Show("Thí sinh vắng phải có thời điểm rời đi cụ thể !",
                            "Thông báo !", MessageBoxButtons.OK);
                        return false;

                    }
                    if (txtnote.Text.Trim() == "")
                    {
                        MessageBox.Show("Thí sinh phải có lý do báo vắng !");
                        return false;
                    }

                    if (txtNhaphoc.Value.Date > txtRoiDi.Value.Date)
                    {
                        MessageBox.Show("Ngày rời trường phải lớn hơn ngày nhập học !"
                            , "Thông báo !", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Phải điền đủ thông tin các trường cần thiết !");
                return false;
            }
            return true;
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            if (CheckAddThiSinh())
            {
                Student std = ThiSinhServices.gI().getThiSinhByMS(txtMaTS.Text);
                Account acc = AccountServices.gI().getAccountByIDUSer(int.Parse(txtUserID.Text.Trim()));

                if (acc != null)
                {
                    if (std == null)
                    {
                        std = new Student();

                        std.StudentID = txtMaTS.Text.Trim();
                        std.UserID = int.Parse(txtUserID.Text.Trim());
                        std.StudentName = txtTenTS.Text;
                        std.Address = txtDiaChi.Text;
                        std.Birt = txtNgaySinh.Value;
                        std.School = txtSchool.Text;
                        std.Class = txtLop.Text;

                        std.DateStart = txtNhaphoc.Value;
                        if (int.Parse(txtStatus.SelectedValue.ToString()) == 0)
                        {
                            std.DateEnd = txtRoiDi.Value;
                        }
                        else
                        {
                            std.DateEnd = null;
                        }

                        if (FileName.Trim() != "")
                        {
                            std.Image = FileName;
                            FileName = string.Empty;
                        }

                        acc.StatusID = int.Parse(txtStatus.SelectedValue.ToString());

                        acc.Note = txtnote.Text;



                        context.Students.Add(std);
                        context.Accounts.AddOrUpdate();

                        context.SaveChanges();

                        MessageBox.Show("Thêm thành công Thí sinh Mã số : " + txtMaTS.Text.Trim()
                            + " User Id : " + txtUserID.Text.Trim());

                        load();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Thí sinh đã tồn tại trong hệ thống ",
                            "Thông báo !", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại trong hệ thống");
                }
            }
        }

        private void dgvThiSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
               && dgvThiSinh.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int rowindex = e.RowIndex;
                txtMaTS.Text = dgvThiSinh.Rows[rowindex].Cells[0].Value.ToString();
                txtUserID.Text = dgvThiSinh.Rows[rowindex].Cells[1].Value.ToString();
                txtTenTS.Text = dgvThiSinh.Rows[rowindex].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvThiSinh.Rows[rowindex].Cells[3].Value.ToString();
                txtNgaySinh.Value = DateTime.ParseExact(dgvThiSinh.Rows[rowindex].Cells[4].Value.ToString(), "dd/MM/yyyy", null);
                txtSchool.Text = dgvThiSinh.Rows[rowindex].Cells[5].Value.ToString();
                txtLop.Text = dgvThiSinh.Rows[rowindex].Cells[6].Value.ToString();
                txtStatus.Text = dgvThiSinh.Rows[rowindex].Cells[7].Value.ToString();
                txtnote.Text = dgvThiSinh.Rows[rowindex].Cells[8].Value.ToString();
                txtNhaphoc.Value = DateTime.ParseExact(dgvThiSinh.Rows[rowindex].Cells[9].Value.ToString(), "dd/MM/yyyy", null);

                txtRoiDi.Value = DateTime.TryParseExact(dgvThiSinh.Rows[rowindex].Cells[10].Value?.ToString(), "dd/MM/yyyy",
                    null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate)
                    ? parsedDate
                     : DateTime.Now;

                if (dgvThiSinh.Rows[rowindex].Cells[11].Value != null
                    && dgvThiSinh.Rows[rowindex].Cells[11].Value.ToString().Trim() != "")
                {
                    string imagepath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images", dgvThiSinh.Rows[rowindex].Cells[11].Value.ToString());
                    picIMG.Image = System.Drawing.Image.FromFile(imagepath);
                } else
                {
                    picIMG.Image = null;
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (CheckSuaThiSinh())
            {
                Student sv = ThiSinhServices.gI().getThiSinhByMS(txtMaTS.Text.Trim());
                Account acc = AccountServices.gI().getAccountByIDUSer(int.Parse(txtUserID.Text.Trim()));

                if (acc != null)
                {
                    if (sv != null)
                    {
                        sv.StudentID = txtMaTS.Text.Trim();
                        sv.StudentName = txtTenTS.Text;
                        sv.Address = txtDiaChi.Text;
                        sv.Birt = txtNgaySinh.Value;
                        sv.School = txtSchool.Text;
                        sv.Class = txtLop.Text;

                        sv.DateStart = txtNhaphoc.Value;
                        if (int.Parse(txtStatus.SelectedValue.ToString()) == 0)
                        {
                            sv.DateEnd = txtRoiDi.Value;
                        }
                        else
                        {
                            sv.DateEnd = null;
                        }
                        if (FileName.Trim() != "")
                        {
                            sv.Image = FileName;
                        }
                        acc.StatusID = int.Parse(txtStatus.SelectedValue.ToString());
                        acc.Note = txtnote.Text;



                        context.Accounts.AddOrUpdate();
                        context.Students.AddOrUpdate();
                        context.SaveChanges();

                        MessageBox.Show("Sửa thành công Thí sinh mã : " + txtMaTS.Text);

                        load();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Thí sinh không còn tồn tại trong Hệ thống !", "Thông báo !", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không còn tồn tại trên Hệ thống !", "Thông báo !", MessageBoxButtons.OK);
                }
            }
        }
        bool CheckSuaThiSinh()
        {
            if (txtMaTS.Text.Trim() != ""
                && txtUserID.Text.Trim() != ""
                && txtTenTS.Text.Trim() != ""
                && txtNgaySinh.Text.Trim() != ""
                && txtDiaChi.Text.Trim() != ""
                && txtSchool.Text.Trim() != ""
                && txtLop.Text.Trim() != ""
                && txtStatus.Text.Trim() != ""
                 && txtNhaphoc.Text.Trim() != "")
            {

                if (!txtUserID.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("User Id chỉ có thể là số !", "Lỗi !", MessageBoxButtons.OK);
                    return false;
                }
                if (!txtMaTS.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("Mã số Thí sinh chỉ có thể là số !", "Lỗi !", MessageBoxButtons.OK);
                    return false;
                }
                if (int.Parse(txtStatus.SelectedValue.ToString()) == 0)
                {
                    if (txtRoiDi.Text.Trim() == "")
                    {
                        MessageBox.Show("Thí sinh vắng phải có thời điểm rời đi cụ thể !",
                            "Thông báo !", MessageBoxButtons.OK);
                        return false;
                    }
                    if (txtnote.Text.Trim() == "")
                    {
                        MessageBox.Show("Thí sinh phải có lý do báo vắng !");
                        return false;
                    }
                    if (txtNhaphoc.Value.Date > txtRoiDi.Value.Date)
                    {
                        MessageBox.Show("Ngày rời trường phải lớn hơn ngày nhập học !"
                            , "Thông báo !", MessageBoxButtons.OK);
                        return false;
                    }
                }
                Student sv = ThiSinhServices.gI().getThiSinhByMsAndIgnoreUserId(txtMaTS.Text.Trim(), int.Parse(txtUserID.Text.Trim()));
                if (sv != null)
                {
                    MessageBox.Show("Đã tồn tại sinh viên với Mã : " + txtMaTS.Text.Trim());
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Phải điền đủ thông tin các trường cần thiết !");
                return false;
            }
            return true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvThiSinh.SelectedRows.Count > 0
                && dgvThiSinh.SelectedRows[0].Cells[0].Value != null)
            {
                long ms = long.Parse(dgvThiSinh.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa Thí sinh mã số :"
                    + ms
                    + " không ?", "Thông báo !", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    Student sv = ThiSinhServices.gI().getThiSinhByMS(ms.ToString());
                    if (sv != null)
                    {
                        context.Students.Remove(sv);
                        context.SaveChanges();

                        MessageBox.Show("Xóa thành công Thí sinh với mã số : " + ms);
                        load();
                        clear();

                    }
                    else
                    {
                        MessageBox.Show("Thí sinh không còn tồn tại trong Hệ thống !", "Thông báo !"
                            , MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 dòng Thí sinh trước khi thực hiện xóa !");
            }
        }

        private void btCLear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                List<Student> svv = StudentServices.gI().getStudenByMSSV(txtSearch.Text.Trim());
                if (svv.Count > 0)
                {
                    dgvThiSinh.Rows.Clear();
                    foreach (var item in svv)
                    {
                        int rowsindex = dgvThiSinh.Rows.Add();
                        dgvThiSinh.Rows[rowsindex].Cells[0].Value = item.StudentID;
                        dgvThiSinh.Rows[rowsindex].Cells[1].Value = item.UserID;
                        dgvThiSinh.Rows[rowsindex].Cells[2].Value = item.StudentName;
                        dgvThiSinh.Rows[rowsindex].Cells[3].Value = item.Address;
                        dgvThiSinh.Rows[rowsindex].Cells[4].Value = item.Birt.ToString("dd/MM/yyyy");
                        dgvThiSinh.Rows[rowsindex].Cells[5].Value = item.School;
                        dgvThiSinh.Rows[rowsindex].Cells[6].Value = item.Class;
                        dgvThiSinh.Rows[rowsindex].Cells[7].Value = item.Account.Status.StatusName;
                        if (item.Account.Note != null)
                        {
                            dgvThiSinh.Rows[rowsindex].Cells[8].Value = item.Account.Note;
                        }
                        dgvThiSinh.Rows[rowsindex].Cells[9].Value = item.DateStart.ToString("dd/MM/yyyy");

                        dgvThiSinh.Rows[rowsindex].Cells[10].Value = item.DateEnd?.ToString("dd/MM/yyyy") ?? "";
                    }
                }
                else
                {
                    load();
                }
            }
            else
            {
                load();
            }
        }

        string FileName = "";

        private void btIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg, *.gif, *.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagepath = openFileDialog.FileName;

                picIMG.Image = System.Drawing.Image.FromFile(imagepath);

                string destiNationPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images");

                if (!Directory.Exists(destiNationPath))
                {
                    Directory.CreateDirectory(destiNationPath);
                }
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagepath);

                FileName = fileName;

                destiNationPath = Path.Combine(destiNationPath, fileName);

                File.Copy(imagepath, destiNationPath);

            }
        }
    }
}

