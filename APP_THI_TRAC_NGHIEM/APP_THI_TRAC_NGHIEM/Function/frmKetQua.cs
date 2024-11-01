using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_BUS;
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
    public partial class frmKetQua : Form
    {
        public frmKetQua()
        {
            InitializeComponent();
        }

        private void frmKetQua_Load(object sender, EventArgs e)
        {
            load();
        }


        void BindGrid(List<Result> rs)
        {
            dgvKetQua.Rows.Clear();
            if (rs.Count > 0)
            {
                foreach (var item in rs)
                {
                    Student st = ThiSinhServices.gI().getThiSinhByUserId(item.UserID);
                    if (st != null)
                    {
                        int rowIndex = dgvKetQua.Rows.Add();
                        dgvKetQua.Rows[rowIndex].Cells[0].Value = st.StudentID;
                        dgvKetQua.Rows[rowIndex].Cells[1].Value = st.StudentName;
                        dgvKetQua.Rows[rowIndex].Cells[2].Value = st.Address;
                        dgvKetQua.Rows[rowIndex].Cells[3].Value = st.Birt.ToString("dd/MM/yyyy");
                        dgvKetQua.Rows[rowIndex].Cells[4].Value = st.Class;
                        dgvKetQua.Rows[rowIndex].Cells[5].Value = item.Score;
                        dgvKetQua.Rows[rowIndex].Cells[6].Value = item.Exam.Subject.SubjectName;
                    }
                }
            }
        }


        void load()
        {
            List<Result> rs = new List<Result>();
            List<Subject> sj = new List<Subject>();
            List<Exam> ex = new List<Exam>();

           
            if (Services.getInstance().account.Role == 2)
            {
                rs = ResultServices.getInstance().getAllResult();
                sj = Services.getInstance().getAllSubjects();
                ex = ExamServices.getInstance().getAllExams();
            } else if (Services.getInstance().account.Role == 1)
            {
                Teacher t = QuanLyServices.gI().getTeachByUserId(Services.getInstance().account.UserID);
                sj = Services.getInstance().getSubjectById(t.TeacherSubjectsID);
                ex = ExamServices.getInstance().getExamByIDSubject(t.TeacherSubjectsID);
                rs = ResultServices.getInstance().getResultBySubjectID(t.TeacherSubjectsID);

            }

            BindGrid(rs);


            txtMonThi.DataSource = sj;
            txtMonThi.DisplayMember = "SubjectName";
            txtMonThi.ValueMember = "SubjectID";


            txtCathi.DataSource = ex;
            txtCathi.DisplayMember = "ExamName";
            txtCathi.ValueMember = "ExamID";
        }



        private void txtMonThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSubject = -1;
            if (int.TryParse(txtMonThi.SelectedValue.ToString(), out idSubject))
            {
                List<Result> rs = ResultServices.getInstance().getResultBySubjectID(idSubject);
                BindGrid(rs);
            }
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            List<Result> rs = ResultServices.getInstance().getAllResult();
            BindGrid(rs);
        }

        private void txtCathi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCaThi = -1;
            if (int.TryParse(txtCathi.SelectedValue.ToString(), out idCaThi))
            {
                List<Result> rs = ResultServices.getInstance().getResultByExamID(idCaThi);
                BindGrid(rs);
            }
        }
    }
}
