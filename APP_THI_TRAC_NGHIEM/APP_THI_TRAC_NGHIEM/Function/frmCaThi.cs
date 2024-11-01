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
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace APP_THI_TRAC_NGHIEM.Function
{
    public partial class frmCaThi : Form
    {

        public Model1 context = Services.getInstance().context;
        public frmCaThi()
        {
            InitializeComponent();
        }

        private void frmCaThi_Load(object sender, EventArgs e)
        {
            load();
        }

        void clear()
        {
            txtTenCaThi.Text = string.Empty;
            txtChuThich.Text = string.Empty;
            txtRules.Text = string.Empty;
            txtThoiGianLamBai.Text = string.Empty;
        }

        void load()
        {
            dgvCathi.Rows.Clear();

            List<Exam> ex = ExamServices.getInstance().getAllExams();
            foreach (var item in ex)
            {
                int rowIndex = dgvCathi.Rows.Add();
                dgvCathi.Rows[rowIndex].Cells[0].Value = item.ExamID;
                dgvCathi.Rows[rowIndex].Cells[1].Value = item.ExamName;
                dgvCathi.Rows[rowIndex].Cells[2].Value = item.Description;
                dgvCathi.Rows[rowIndex].Cells[3].Value = item.Subject.SubjectCode;
                dgvCathi.Rows[rowIndex].Cells[4].Value = item.NumQuestion;
                dgvCathi.Rows[rowIndex].Cells[5].Value = item.StartTime;
                dgvCathi.Rows[rowIndex].Cells[6].Value = item.EndTime;
                dgvCathi.Rows[rowIndex].Cells[7].Value = item.Duration;
                dgvCathi.Rows[rowIndex].Cells[8].Value = item.Rules;
            }

            List<Subject> sj = Services.getInstance().getAllSubjects();
            txtMaMonThi.DataSource = sj;
            txtMaMonThi.DisplayMember = "SubjectCode";
            txtMaMonThi.ValueMember = "SubjectID";
            txtMaMonThi.Text = string.Empty;
        }

        private void dgvCathi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
                && dgvCathi.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int rowIndex = e.RowIndex;
                txtTenCaThi.Text = dgvCathi.Rows[rowIndex].Cells[1].Value.ToString();
                txtChuThich.Text = dgvCathi.Rows[rowIndex].Cells[2].Value.ToString();
                txtMaMonThi.Text = dgvCathi.Rows[rowIndex].Cells[3].Value.ToString();
                txtNumQuest.Text = dgvCathi.Rows[rowIndex].Cells[4].Value.ToString();
                txtTGBatDau.Text = dgvCathi.Rows[rowIndex].Cells[5].Value.ToString();
                txtTGKetTHuc.Text = dgvCathi.Rows[rowIndex].Cells[6].Value.ToString();
                txtThoiGianLamBai.Text = dgvCathi.Rows[rowIndex].Cells[7].Value.ToString();
                txtRules.Text = dgvCathi.Rows[rowIndex].Cells[8].Value.ToString();

            }
        }

        bool CheckThemCaThi()
        {

            if (txtTenCaThi.Text.Trim() != ""
                && txtChuThich.Text.Trim() != "" && txtRules.Text.Trim() != ""
                && txtRules.Text.Trim() != "" & txtThoiGianLamBai.Text.Trim() != "")
            {
                if (txtTGBatDau.Value > txtTGKetTHuc.Value)
                {
                    MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc !"
                        , "Thông báo !", MessageBoxButtons.OK);
                    return false;
                }

                if (!txtThoiGianLamBai.Text.All(char.IsDigit))
                {
                    if (int.Parse(txtThoiGianLamBai.Text.Trim()) <= 0 )
                    {
                        MessageBox.Show("Thời gian làm bài phải lớn hơn 0");
                        return false;
                    }
                    MessageBox.Show("Thời gian làm bài phải là con số !", "Thông báo !", MessageBoxButtons.OK);
                    return false;
                }
                if (!txtNumQuest.Text.All(char.IsDigit)) {
                    if (int.Parse(txtNumQuest.Text.ToString()) <= 0)
                    {
                        MessageBox.Show("Số câu hỏi phải lớn hơn 0 !");
                        return false;
                    }
                    MessageBox.Show("Số câu hỏi phải là con số !", "Thông báo !", MessageBoxButtons.OK);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đẩy đủ các thông tin trước khi thực hiện thêm Ca thi !",
                    "Thông báo !", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (CheckThemCaThi())
            {
                Exam ex = new Exam();
                ex.ExamName = txtTenCaThi.Text;
                ex.Description = txtChuThich.Text;
                ex.StartTime = txtTGBatDau.Value;
                ex.EndTime = txtTGKetTHuc.Value;
                ex.Duration = int.Parse(txtThoiGianLamBai.Text.Trim());
                ex.Rules = txtRules.Text;
                ex.SubjectID = int.Parse(txtMaMonThi.SelectedValue.ToString());
                ex.CreatedBy = Services.getInstance().account.UserID;
                ex.NumQuestion = int.Parse(txtNumQuest.Text.ToString());

                context.Exams.Add(ex);
                context.SaveChanges();

                MessageBox.Show("Thêm thành công Ca thi !");

                load();
                clear();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvCathi.SelectedRows.Count > 0
                && dgvCathi.SelectedRows[0].Cells[0].Value != null)
            {
                if (CheckThemCaThi())
                {
                    int rowIndex = dgvCathi.SelectedRows[0].Index;
                    int id = int.Parse(dgvCathi.Rows[rowIndex].Cells[0].Value.ToString());

                    List<Result> resultList = ResultServices.getInstance().getResultByExamID(id);

                    if (resultList.Count > 0)
                    {
                        MessageBox.Show("Không thể sửa ca thi này vì đã có thí sinh dự thi ca này !",
                            "Thông báo !", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Exam ex = ExamServices.getInstance().getExamByExamID(id);

                        if (ex != null)
                        {
                            ex.ExamName = txtTenCaThi.Text;
                            ex.Description = txtChuThich.Text;
                            ex.StartTime = txtTGBatDau.Value;
                            ex.EndTime = txtTGKetTHuc.Value;
                            ex.Duration = int.Parse(txtThoiGianLamBai.Text.Trim());
                            ex.Rules = txtRules.Text;
                            ex.SubjectID = int.Parse(txtMaMonThi.SelectedValue.ToString());
                            ex.CreatedBy = Services.getInstance().account.UserID;
                            ex.NumQuestion = int.Parse(txtNumQuest.Text.ToString());

                            context.Exams.AddOrUpdate(ex);
                            context.SaveChanges();

                            MessageBox.Show("Sửa thành công Ca thi ID : " + ex.ExamID);
                            load();
                            clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 dòng Ca thi trước khi thực hiện sửa !");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvCathi.SelectedRows.Count > 0
            && dgvCathi.SelectedRows[0].Cells[0].Value != null)
            {
                int rowIndex = dgvCathi.SelectedRows[0].Index;
                int id = int.Parse(dgvCathi.Rows[rowIndex].Cells[0].Value.ToString());

                List<Result> resultList = ResultServices.getInstance().getResultByExamID(id);

                if (resultList.Count > 0)
                {
                    MessageBox.Show("Không thể xóa ca thi này vì đã có thí sinh dự thi ca này !",
                        "Thông báo !",MessageBoxButtons.OK);
                } else
                {
                    Exam ex = ExamServices.getInstance().getExamByExamID(id);
                    if (ex != null)
                    {
                        DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa Ca thi Mã : " + ex.ExamID,
                            "Thông báo !", MessageBoxButtons.YesNo);
                        if (rs == DialogResult.Yes)
                        {
                            context.Exams.Remove(ex);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công ca thi mã : " + ex.ExamID);
                            clear();
                            load();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ca thi đã không còn tồn tại trên hệ thống !", "Thông báo !", MessageBoxButtons.OK);
                    }
                }
              
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng Ca thi trước khi thực hiện xóa !");
            }
        }

        private void btCLear_Click(object sender, EventArgs e)
        {
            clear();
        }

    }
}
