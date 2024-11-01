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
    public partial class frmCauHoi : Form
    {
        public frmCauHoi()
        {
            InitializeComponent();
        }

        List<Question> listQuest = new List<Question>();
        public Model1 context = Services.getInstance().context;

        private void frmCauHoi_Load(object sender, EventArgs e)
        {
            load();
        }

        void load()
        {
            dgvCauHoi.Rows.Clear();
            listQuest = QuestionServices.gI().getAllquest();
            foreach (var item in listQuest)
            {
                int rowsIndex = dgvCauHoi.Rows.Add();
                dgvCauHoi.Rows[rowsIndex].Cells[0].Value = item.QuestionID;
                dgvCauHoi.Rows[rowsIndex].Cells[1].Value = item.QuestionText;
                dgvCauHoi.Rows[rowsIndex].Cells[2].Value = item.Subject.SubjectCode;
                dgvCauHoi.Rows[rowsIndex].Cells[3].Value = item.DateCreate.ToString("dd/MM/yyyy");
                dgvCauHoi.Rows[rowsIndex].Cells[4].Value = item.TeacherID;
                dgvCauHoi.Rows[rowsIndex].Cells[5].Value = item.AnswerOptions;
            }

            List<Subject> subs = new List<Subject>();
            if (Services.getInstance().account.Role == 1)
            {
                Teacher t = QuanLyServices.gI().getTeachByUserId(Services.getInstance().account.UserID);

                subs = Services.getInstance().getSubjectById(t.TeacherSubjectsID);
            }
            else if (Services.getInstance().account.Role == 2)
            {
                subs = Services.getInstance().getAllSubjects();
            }

            txtMonHoc.DataSource = subs;
            txtMonHoc.DisplayMember = "SubjectName";
            txtMonHoc.ValueMember = "SubjectID";
            txtMonHoc.Text = string.Empty;

            LoadQuestBySubjectID(-1);

            if (subs.Count == 1)
            {
                LoadQuestBySubjectID(int.Parse(txtMonHoc.SelectedValue.ToString()));
            }

        }

        void clear()
        {
            txtCauHoi.Text = string.Empty;
            txtCauA.Text = string.Empty;
            txtCauB.Text = string.Empty;
            txtCauC.Text = string.Empty;    
            txtCauD.Text = string.Empty;
            txtDapAn.Text = string.Empty;
            txtDapAn.Items.Clear();
        }
        private void txtMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSubject = -1;
            if (int.TryParse(txtMonHoc.SelectedValue.ToString(), out idSubject))
            {
                LoadQuestBySubjectID(idSubject);
            }
            else
            {
                load();
            }
        }

        void LoadQuestBySubjectID(int id)
        {
            dgvCauHoi.Rows.Clear();
            if (id == -1)
            {
                listQuest = QuestionServices.gI().getAllquest();
            }
            else
            {
                listQuest = QuestionServices.gI().getQuesTionBySubjecID(id);
            }
            if (listQuest.Count > 0)
            {
                foreach (var item in listQuest)
                {
                    int rowsIndex = dgvCauHoi.Rows.Add();
                    dgvCauHoi.Rows[rowsIndex].Cells[0].Value = item.QuestionID;
                    dgvCauHoi.Rows[rowsIndex].Cells[1].Value = item.QuestionText;
                    dgvCauHoi.Rows[rowsIndex].Cells[2].Value = item.Subject.SubjectCode;
                    dgvCauHoi.Rows[rowsIndex].Cells[3].Value = item.DateCreate.ToString("dd/MM/yyyy");
                    dgvCauHoi.Rows[rowsIndex].Cells[4].Value = item.TeacherID;
                    dgvCauHoi.Rows[rowsIndex].Cells[5].Value = item.AnswerOptions;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            load();
            checkBox1.Checked = false;
        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
                && dgvCauHoi.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int RowIndex = e.RowIndex;
                int idQ = int.Parse(dgvCauHoi.Rows[RowIndex].Cells[0].Value.ToString());
                Question q = listQuest.FirstOrDefault(p => p.QuestionID == idQ);
                if (q != null)
                {
                    txtCauHoi.Text = q.QuestionText;

                    string processedInput = Regex.Replace(q.AnswerOptions, @"\d+\.\s*", "");
                    string[] answer = processedInput.Split(',');

                    txtCauA.Text = answer[0];
                    txtCauB.Text = answer[1];
                    txtCauC.Text = answer[2];
                    txtCauD.Text = answer[3];

                    txtDapAn.Items.Clear();

                    foreach (string aws in answer)
                    {
                        txtDapAn.Items.Add(aws);
                    }
                    txtDapAn.Text = string.Empty;

                    txtDapAn.SelectedIndex = q.Answer - 1;
                }
            }
        }


        bool checkAddVaSua()
        {
            if (txtCauHoi.Text.Trim() != ""
                && txtCauA.Text.Trim() != ""
                && txtCauB.Text.Trim() != ""
                && txtCauC.Text.Trim() != ""
                && txtCauD.Text.Trim() != "")
            {
                if (txtDapAn.Text.Trim() == "")
                {
                    MessageBox.Show("Hãy lựa chọn ít nhất 1 đáp án đúng !");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đẩy đủ câu hỏi và các câu trả lời cần thiết !",
                    "Thông báo !", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (checkAddVaSua())
            {
                Teacher t = QuanLyServices.gI().getTeachByUserId(Services.getInstance().account.UserID);
                Question q = new Question();
                q.QuestionText = txtCauHoi.Text;
                q.SubjectID = int.Parse(txtMonHoc.SelectedValue.ToString());
                q.QuestionType = "One choice";
                q.AnswerOptions = "1." + txtCauA.Text + ",2." + txtCauB.Text
                    + ",3." + txtCauC.Text + ",4." + txtCauD.Text;
                q.Answer = txtDapAn.SelectedIndex + 1;
                q.DateCreate = DateTime.Now;
                q.TeacherID = t.TeacherID;

                context.Questions.Add(q);
                context.SaveChanges();

                MessageBox.Show("Thêm thành công câu hỏi !");
                load();
                clear();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvCauHoi.SelectedRows.Count > 0
                && dgvCauHoi.SelectedRows[0].Cells[0].Value != null)
            {
                if (checkAddVaSua())
                {
                    
                    Question q = QuestionServices.gI().getQuestionById(
                       int.Parse(dgvCauHoi.SelectedRows[0].Cells[0].Value.ToString()));
                    Teacher t = QuanLyServices.gI().getTeachByUserId(Services.getInstance().account.UserID);

                    if (q != null)
                    {
                        q.QuestionText = txtCauHoi.Text;
                        q.SubjectID = int.Parse(txtMonHoc.SelectedValue.ToString());
                        q.AnswerOptions = "1." + txtCauA.Text + ",2." + txtCauB.Text
                            + ",3." + txtCauC.Text + ",4." + txtCauD.Text;
                        q.Answer = txtDapAn.SelectedIndex + 1;
                        q.DateCreate = DateTime.Now;
                      
                        q.TeacherID = t.TeacherID;

                        context.Questions.AddOrUpdate(q);
                        context.SaveChanges();

                        MessageBox.Show("Sửa thành công ID : " + q.QuestionID);
                        load();
                        clear();
                    }
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 đối tượng trước khi Sửa câu hỏi !",
                    "Thông báo !",MessageBoxButtons.OK);
            }
           
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvCauHoi.SelectedRows.Count > 0
                && dgvCauHoi.SelectedRows[0].Cells[0].Value != null)
            {
                Question q = QuestionServices.gI().getQuestionById(
                       int.Parse(dgvCauHoi.SelectedRows[0].Cells[0].Value.ToString()));

                if(q != null)
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi ID : " + q.QuestionID ,"Thông báo !",MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        context.Questions.Remove(q);
                        context.SaveChanges() ;

                        MessageBox.Show("Xóa thành công câu hỏi ID : " + q.QuestionID);

                        load();
                        clear();

                    }
                } else
                {
                    MessageBox.Show("Câu hỏi không còn tồn tại trên hệ thống !");
                }
            } else
            {
                MessageBox.Show("Hãy chọn 1 dòng Câu hỏi cần xóa trước !");
            }
        }

        private void btCLear_Click(object sender, EventArgs e)
        {
            clear();
        }

        
    }
}
