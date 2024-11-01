using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_THI_TRAC_NGHIEM.StudentFormExam
{
    public partial class frmThi : Form
    {
        private Model1 context = Services.getInstance().context;
        string Name;
        public frmThi(Exam ex)
        {
            InitializeComponent();
            this.exam = ex;
        }

        int phut = 0;
        int giay = 0;


        private void frmThi_Load(object sender, EventArgs e)
        {
            listExam = context.Questions.Where(p => p.SubjectID == exam.SubjectID).AsEnumerable()
                  .OrderBy(p => Guid.NewGuid())
                  .Take(exam.NumQuestion)
                  .ToArray();

            POS = 0;

            bindQuestionByPOS();

            QUESTIONS_COUNT = exam.NumQuestion;

            phut = exam.Duration - 1;
            giay = 60;
            this.timer1.Enabled = true;
            hienThiGio();
            init();

            Student std = ThiSinhServices.gI().getThiSinhByUserId(Services.getInstance().account.UserID);
            Name = std.StudentName;
            if (std != null)
            {
                string imagepath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images", std.Image);
                picIMG.Image = System.Drawing.Image.FromFile(imagepath);

                txtName.Text = std.StudentName;
                txtNgaySinh.Text = std.Birt.ToString("dd/MM/yyyy");
                txtMonThi.Text = exam.Subject.SubjectName;
                txtLop.Text = std.Class;

                txtSoCau.Text = exam.NumQuestion + " câu";
                txtThoiGian.Text = exam.Duration + " phút";
            }
        }

        void bindQuestionByPOS()
        {
            List<string> answerList = ParseAnswers(listExam[POS].AnswerOptions);

            txtQuest.Text = (POS + 1) + " - " +listExam[POS].QuestionText;

            if (answerList.Count > 0) txtA.Text = answerList.Count > 0 ? answerList[0] : "";
            if (answerList.Count > 1) txtB.Text = answerList.Count > 1 ? answerList[1] : "";
            if (answerList.Count > 2) txtC.Text = answerList.Count > 2 ? answerList[2] : "";
            if (answerList.Count > 3) txtD.Text = answerList.Count > 3 ? answerList[3] : "";
        }


        private List<string> ParseAnswers(string answerOptions)
        {
            List<string> answers = new List<string>();

            string[] parts = answerOptions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string trimmedPart = part.Trim();

                int dotIndex = trimmedPart.IndexOf('.');

                if (dotIndex != -1)
                {
                    string answerText = trimmedPart.Substring(dotIndex + 1).Trim();
                    answers.Add(answerText);
                }
                else
                {
                    answers.Add(trimmedPart);
                }
            }

            return answers;
        }


        private const int OPTIONS_COUNT = 4;
        private GroupBox[] questionGroups;
        private RadioButton[,] optionButtons;
        private Question[] listExam;
        private Exam exam;
        private int QUESTIONS_COUNT = 40;

        private int POS;
        private void init()
        {
            

             Panel mainPanel = panel2;
            mainPanel.AutoScroll = true;

            questionGroups = new GroupBox[QUESTIONS_COUNT];
            optionButtons = new RadioButton[QUESTIONS_COUNT, OPTIONS_COUNT];

            int questionWidth = 50;
            int questionHeight = 150;
            int spacing = 5;
            int radioSize = 25;

            for (int q = 0; q < QUESTIONS_COUNT; q++)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = (q + 1).ToString();
                groupBox.Size = new Size(questionWidth, questionHeight);
                groupBox.Location = new Point((questionWidth + spacing) * q + spacing, spacing);
                for (int opt = 0; opt < OPTIONS_COUNT; opt++)
                {
                    RadioButton radio = new RadioButton();
                    radio.Text = ((char)('A' + opt)).ToString();
                    radio.Size = new Size(radioSize, radioSize);
                    radio.Location = new Point(
                        (questionWidth - radioSize) / 2,
                        20 + (radioSize + spacing) * opt
                    );

                    optionButtons[q, opt] = radio;
                    groupBox.Controls.Add(radio);
                }

                questionGroups[q] = groupBox;
                mainPanel.Controls.Add(groupBox);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (POS < listExam.Length-1)
            {
                POS += 1;
            } else
            {
                POS = listExam.Length-1;
            }
            bindQuestionByPOS();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (POS > 0)
            {
                POS -= 1;
            } else
            {
                POS = 0;
            }
            bindQuestionByPOS();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            POS = listExam.Length -1;
            bindQuestionByPOS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            POS = 0;
            bindQuestionByPOS();
        }

        void hienThiGio()
        {
            string Sphut = "";
            string SGIay = "";

            if (phut < 10)
            {
                Sphut = "0" + phut.ToString();
            } else
            {
                Sphut = phut.ToString();
            }
            if (giay < 10)
            {
                SGIay = "0" + giay.ToString();  
            } else
            {
                SGIay = giay.ToString();
            }
            this.txtTime.Text = Sphut + ":" + SGIay;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();

            giay--;
            if (giay <= 0)
            {
                if (phut > 0)
                {
                    giay = 60;
                    phut--;
                } else
                {
                    cacuLaPointAndEnd(0);
                }

                
            } else
            {
                hienThiGio();
            }

        }

        void cacuLaPointAndEnd(int type)
        {
            Attempt t = AttempsServices.gI().getAtempByUserIdAndExamID(exam.ExamID,Services.getInstance().account.UserID);
            if (t != null)
            {
                switch (type)
                {
                    case 0:
                        this.Close();
                        MessageBox.Show("Đã kết thúc thời gian làm bài !", "Thông báo !", MessageBoxButtons.OK);
                        break;
                    case 1:
                        this.Close();
                        break;
                }
                int numQ = getNumQuesthasAnswer();
                int numRight = getNumRight();
                float point = ((float)numRight / exam.NumQuestion) * 10;

                Result rs = new Result();
                rs.ExamID = exam.ExamID;
                rs.UserID = Services.getInstance().account.UserID;
                rs.Score = point;
                rs.SubmittedAt = DateTime.Now;

                context.Results.Add(rs);
                context.SaveChanges();

                t.Status = "Complete";
                t.IdResult = rs.ResultID;

                context.Attempts.AddOrUpdate();
                context.SaveChanges();

                frmEnd frm = new frmEnd(Name, numQ, numRight, point, exam.NumQuestion);
                frm.Show();

            } else
            {
                MessageBox.Show("Quá trình bạn làm bài không tồn tại trong hệ thống !");
            }
        }
        private void btEnd_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn kết thúc bài thi ngay không?","Thông báo !"
                ,MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                cacuLaPointAndEnd(1);
            }
        }

        int getNumRight()
        {
            int count = 0;
            for (int q = 0; q < QUESTIONS_COUNT; q++)
            {
                Question ex = listExam[q];
                for (int opt = 0; opt < OPTIONS_COUNT; opt++)
                {
                    if (optionButtons[q, opt].Checked)
                    {
                        if (opt == (ex.Answer - 1))
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            return count;
        }

        int getNumQuesthasAnswer()
        {
            int num = 0;
            for (int q = 0; q < QUESTIONS_COUNT; q++)
            {
                for (int opt = 0; opt < OPTIONS_COUNT; opt++)
                {
                    if (optionButtons[q, opt].Checked)
                    {
                        num++;
                        break;
                    }
                 
                }
            }
            return num;
        }

        private void checkNotAnswerQuestion()
        {
            string results = "";
            for (int q = 0; q < QUESTIONS_COUNT; q++)
            {
                bool answered = false;
                for (int opt = 0; opt < OPTIONS_COUNT; opt++)
                {
                    if (optionButtons[q, opt].Checked)
                    {
                        answered = true;
                        break;
                    }
                }
                if (!answered) results += $"Câu {q + 1}: " + "Chưa trả lời\n";
            }
            MessageBox.Show(results, "Kết quả");
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            checkNotAnswerQuestion();
        }

    }
}
