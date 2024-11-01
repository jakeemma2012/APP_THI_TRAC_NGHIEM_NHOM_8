using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_THI_TRAC_NGHIEM.Function
{
    public partial class frmQuanLy : Form
    {
        public Model1 context = Services.getInstance().context;
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        void load()
        {
            List<Teacher> teach = QuanLyServices.gI().getAllTeacher();
            dgvQuanLy.Rows.Clear();
            foreach (var item in teach)
            {
                int rowIndex = dgvQuanLy.Rows.Add();
                dgvQuanLy.Rows[rowIndex].Cells[0].Value = item.TeacherID;
                dgvQuanLy.Rows[rowIndex].Cells[1].Value = item.UserID;
                dgvQuanLy.Rows[rowIndex].Cells[2].Value = item.TeacherName;
                dgvQuanLy.Rows[rowIndex].Cells[3].Value = item.AddRess;
                dgvQuanLy.Rows[rowIndex].Cells[4].Value = item.Phone;
                dgvQuanLy.Rows[rowIndex].Cells[5].Value = item.Birth.ToString("dd/MM/yyyy") ?? "";
                dgvQuanLy.Rows[rowIndex].Cells[6].Value = item.Email;
                dgvQuanLy.Rows[rowIndex].Cells[7].Value = item.Subject.SubjectName;
                dgvQuanLy.Rows[rowIndex].Cells[8].Value = item.PerMission.PerMisName;
            }

            List<PerMission> pers = QuanLyServices.gI().getAllPerMis();
            txtPhanQuyen.DataSource = pers;
            txtPhanQuyen.DisplayMember = "PerMisName";
            txtPhanQuyen.ValueMember = "PerMisID";
            txtPhanQuyen.Text = string.Empty;

            List<Account> ac = AccountServices.gI().getAllAccountTeacher();
            txtUserId.DataSource = ac;
            txtUserId.DisplayMember = "UserID";
            txtUserId.ValueMember = "UserID";
            txtUserId.Text = string.Empty;


            List<Subject> sj = Services.getInstance().getAllSubjects();
            txtMonHoc.DataSource = sj;
            txtMonHoc.DisplayMember = "SubjectName";
            txtMonHoc.ValueMember = "SubjectID";
            txtMonHoc.Text = string.Empty;
        }

        void clear()
        {
            txtMaGV.Text = string.Empty;
            txtUserId.Text= string.Empty;   
            txtName.Text= string.Empty;
            txtDiaChi.Text= string.Empty;
            txtSDT.Text= string.Empty;
            txtEmail.Text= string.Empty;
            txtMonHoc.Text = string.Empty;
            txtPhanQuyen.Text= string.Empty;
        }

        private void dgvQuanLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
              && dgvQuanLy.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int rowindex = e.RowIndex;
                txtMaGV.Text = dgvQuanLy.Rows[rowindex].Cells[0].Value.ToString();
                txtUserId.Text = dgvQuanLy.Rows[rowindex].Cells[1].Value.ToString();
                txtName.Text = dgvQuanLy.Rows[rowindex].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvQuanLy.Rows[rowindex].Cells[3].Value.ToString();
                txtSDT.Text = dgvQuanLy.Rows[rowindex].Cells[4].Value.ToString();
                txtNgaySinh.Value = DateTime.ParseExact(dgvQuanLy.Rows[rowindex].Cells[5].Value.ToString(), "dd/MM/yyyy", null);
                txtEmail.Text = dgvQuanLy.Rows[rowindex].Cells[6].Value.ToString();
                txtMonHoc.Text = dgvQuanLy.Rows[rowindex].Cells[7].Value.ToString();
                txtPhanQuyen.Text = dgvQuanLy.Rows[rowindex].Cells[8].Value.ToString();
            }
        }

        bool CheckAddGiangVien()
        {
            if (txtMaGV.Text.Trim() != "" && txtName.Text.Trim () != ""
                && txtDiaChi.Text.Trim() != "" && txtEmail.Text.Trim() != "")
            {
                if (!txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được nhập số !","Thông báo !",MessageBoxButtons.OK);
                    return false;
                }
                if (!isValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Chỉ hỗ trợ định dạng @gmail.com !","Thông báo !",MessageBoxButtons.OK);
                    return false;
                }
                Teacher teacherE = QuanLyServices.gI().getTeachByUserId(int.Parse(txtUserId.SelectedValue.ToString()));
                if (teacherE != null)
                {
                    MessageBox.Show("Đã tồn tại giảng viên với User ID : " + txtUserId.SelectedValue.ToString());
                    return false;
                }
            } else
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin trước khi thực hiện Thêm giảng viên !");
                return false;
            }
            return true;
          
        }

        bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (CheckAddGiangVien())
            {
                Teacher t = QuanLyServices.gI().getTeacherByID(txtMaGV.Text.Trim());
                if (t == null)
                {
                    t = new Teacher();
                    t.TeacherID = txtMaGV.Text.Trim();
                    t.UserID = int.Parse(txtUserId.SelectedValue.ToString());
                    t.TeacherName = txtName.Text;
                    t.TeacherSubjectsID = int.Parse(txtMonHoc.SelectedValue.ToString());
                    t.AddRess = txtDiaChi.Text;
                    t.Phone = txtSDT.Text.Trim();
                    t.Birth = txtNgaySinh.Value;
                    t.Email = txtEmail.Text.Trim();
                    t.PerMisID = int.Parse(txtPhanQuyen.SelectedValue.ToString());

                    context.Teachers.Add(t);    
                    context.SaveChanges();

                    MessageBox.Show($"Thêm thành công giảng viên mã {txtMaGV.Text.Trim()} với User Id {txtUserId.Text.Trim()}" );
                    load();
                    clear();
                } else
                {
                    MessageBox.Show($"Giảng viên {txtMaGV.Text.Trim()} đã tồn tại trên hệ thống !","Thông báo !",MessageBoxButtons.OK);
                }
            }
        }


        bool CheckSuaGiangVien()
        {
            if (txtMaGV.Text.Trim() != "" && txtName.Text.Trim() != ""
               && txtDiaChi.Text.Trim() != "" && txtEmail.Text.Trim() != "")
            {
                if (!txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được nhập số !", "Thông báo !", MessageBoxButtons.OK);
                    return false;
                }
                if (!isValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Chỉ hỗ trợ định dạng @gmail.com !", "Thông báo !", MessageBoxButtons.OK);
                    return false;
                }
                Teacher teacherE = QuanLyServices.gI().getTeacherByIdAndIgnoreUserID(txtMaGV.Text.Trim(),int.Parse(txtUserId.SelectedValue.ToString()));
                if (teacherE != null)
                {
                    MessageBox.Show("Đã tồn tại giảng viên với mã giảng viên : " + txtMaGV.Text.Trim());
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin trước khi thực hiện Thêm giảng viên !");
                return false;
            }
            return true;
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            if (CheckSuaGiangVien())
            {
                Teacher t = QuanLyServices.gI().getTeachByUserId(int.Parse(txtUserId.Text.Trim()));
                if (t != null)
                {
                    t.TeacherName = txtName.Text;
                    t.TeacherSubjectsID = int.Parse(txtMonHoc.SelectedValue.ToString());
                    t.AddRess = txtDiaChi.Text;
                    t.Phone = txtSDT.Text.Trim();
                    t.Birth = txtNgaySinh.Value;
                    t.Email = txtEmail.Text.Trim();
                    t.PerMisID = int.Parse(txtPhanQuyen.SelectedValue.ToString());

                    context.Teachers.AddOrUpdate();
                    context.SaveChanges();

                    MessageBox.Show("Sửa thành công dữ liệu giảng viên với User ID : " + txtUserId.Text.Trim());
                    load();
                    clear();
                } else
                {
                    MessageBox.Show("Giảng viên đã không còn tồn tại trên hệ thống !","Thông báo !",MessageBoxButtons.OK);
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvQuanLy.SelectedRows.Count > 0
                && dgvQuanLy.SelectedRows[0].Cells[0].Value != null)
            {
                Teacher t = QuanLyServices.gI().getTeachByUserId(int.Parse(txtUserId.SelectedValue.ToString()));
                if (t != null)
                {
                    DialogResult rs = MessageBox.Show($"Bạn có chắc muốn xóa Giảng viên có User ID : {txtUserId.Text.Trim()} không ?"
                        ,"Thông báo !",MessageBoxButtons.OKCancel);
                    if (rs == DialogResult.OK)
                    {
                        context.Teachers.Remove(t);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công Giảng viên với User Id : " + txtUserId.Text.Trim());
                        load();
                        clear();
                    }
                } else
                {
                    MessageBox.Show("Giảng viên không còn tồn tại trên hệ thống !","Thông báo !",MessageBoxButtons.OK);
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng giảng viên để thực hiện xóa !",
                    "Thông báo !",MessageBoxButtons.OK);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
