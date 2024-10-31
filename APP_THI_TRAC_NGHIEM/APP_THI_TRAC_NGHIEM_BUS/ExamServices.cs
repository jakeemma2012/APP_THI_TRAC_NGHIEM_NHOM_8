using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_THI_TRAC_NGHIEM_BUS
{
    public class ExamServices
    {
        public Model1 context = Services.getInstance().context;
        public static ExamServices instance;

        public static ExamServices getInstance()
        {
            if (instance == null)
            {
                instance = new ExamServices();
            }
            return instance;
        }


        public List<Exam> getAllExams()
        {
            return context.Exams.ToList();
        }


        public List<Exam> getExamByIDSubject(int id)
        {
            return context.Exams.Where(p => p.SubjectID == id).ToList();
        }

        public List<Exam> getExamByIDSubjectAndOrderByDate(int id)
        {
            DateTime now = DateTime.Now;
            return context.Exams.Where(p => p.SubjectID == id
            && p.StartTime <= now && p.EndTime >= now)
                .OrderBy(p => p.StartTime).ToList();
        }
        public Exam getExamByExamID(int idExam)
        {
            return context.Exams.FirstOrDefault(p => p.ExamID == idExam);
        }
    }
}
