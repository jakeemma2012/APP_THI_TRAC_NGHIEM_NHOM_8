using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_THI_TRAC_NGHIEM.StudentFormExam
{
    public partial class frmLobby : Form
    {

        public Model1 context = Services.getInstance().context;
        public frmLobby()
        {
            InitializeComponent();
        }

        private void btThoat_CLick(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc không muốn thi ?", "Lưu ý !", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                Environment.Exit(0);
            }

        }

        private void frmLobby_Load(object sender, EventArgs e)
        {
            Student std = ThiSinhServices.gI().
                getThiSinhByUserId(Services.getInstance().account.UserID);



            if (std != null)
            {
                txtHoTen.Text = std.StudentName;
                txtNgaySinh.Text = std.Birt.ToString("dd/MM/yyyy");
                txtLop.Text = std.Class;

                if (std.Image != null)
                {
                    string imagepath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images", std.Image);

                    picIMG.Image = System.Drawing.Image.FromFile(imagepath);
                }
                bindSubJect();

            }
            else
            {
                MessageBox.Show("Hệ thống xảy ra lỗi khi truy xuất thí sinh,vui lòng báo lại cho bộ phận " +
                    "hộ trợ !");
                Environment.Exit(0);
            }



        }

        void bindSubJect()
        {
            List<Subject> sj = Services.getInstance().getAllSubjects();

            txtMonThi.DataSource = sj;
            txtMonThi.DisplayMember = "SubjectName";
            txtMonThi.ValueMember = "SubjectID";
            txtMonThi.SelectedIndex = 1;
        }

        private void txtMonThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMonThi.SelectedValue.ToString(), out int idSubject))
            {
                List<Exam> exams = ExamServices.getInstance().getExamByIDSubjectAndOrderByDate(idSubject);
                if (exams.Count > 0)
                {
                    txtMaCaThi.DataSource = exams;
                    txtMaCaThi.DisplayMember = "ExamName";
                    txtMaCaThi.ValueMember = "ExamID";
                }
                else
                {
                    txtMaCaThi.DataSource = null;
                }

            }
        }

        private void txtMaCaThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMaCaThi.DataSource != null)
            {
                if (int.TryParse(txtMaCaThi.SelectedValue.ToString(), out int idExams))
                {
                    Exam exams = ExamServices.getInstance().getExamByExamID(idExams);
                    if (exams != null)
                    {
                        txtTGLamBai.Text = exams.Duration.ToString() + " phút";
                        txtSoCau.Text = exams.NumQuestion.ToString() + " câu ";

                        txtTGLamBai.Visible = true;
                        txtSoCau.Visible = true;
                    }
                    else
                    {
                        txtTGLamBai.Visible = false;
                        txtSoCau.Visible = false;
                    }
                }
                else
                {
                    txtTGLamBai.Visible = false;
                    txtSoCau.Visible = false;
                }
            }
            else
            {
                txtTGLamBai.Visible = false;
                txtSoCau.Visible = false;
            }


        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaCaThi.SelectedValue.ToString(), out int idSubject))
            {
              

                if (txtMaCaThi.Text.Trim() != "")
                {
                    Exam exams = ExamServices.getInstance().getExamByExamID(int.Parse(txtMaCaThi.SelectedValue.ToString()));
                   
                    Attempt apt = AttempsServices.gI().getAtempByUserIdAndExamID(exams.ExamID,Services.getInstance().account.UserID);
                    if (apt== null)
                    {

                        Attempt t = new Attempt();
                        t.ExamID = exams.ExamID;
                        t.UserID = Services.getInstance().account.UserID;
                        t.AttemptDate = DateTime.Now;
                        t.Status = "Inprogess";

                        context.Attempts.Add(t);
                        context.SaveChanges();

                        frmThi frm = new frmThi(exams);
                        frm.Font = new Font("Microsoft Sans Serif", 10);
                        this.Hide();
                        frm.Show(this);
                    } else
                    {
                        MessageBox.Show("Mỗi thí sinh chỉ thi được 1 lần mỗi môn !","Thông báo !",
                            MessageBoxButtons.OK);
                    }
                } else
                {
                    MessageBox.Show("Hãy lựa chọn ca thi trước khi bắt đầu làm bài !");
                }
            } else
            {
                MessageBox.Show("Hãy lựa chọn môn thi trước khi bắt đầu làm bài !");
            }
           
        }

        private void frmLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
