using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_THI_TRAC_NGHIEM_BUS
{
    public class ResultServices
    {
        public Model1 context = Services.getInstance().context;
        public static ResultServices instance;

        public static ResultServices getInstance()
        {
            if (instance == null)
            {
                instance = new ResultServices();
            }
            return instance;
        }

        public List<Result> getAllResult()
        {
            return context.Results.ToList();
        }

        public List<Result> getResultBySubjectID(int id)
        {
            return context.Results.Where(p => p.Exam.SubjectID == id).ToList();
        }

        public List<Result> getResultByExamID(int id)
        {
            return context.Results.Where(p => p.Exam.ExamID == id).ToList();
        }


    }
}
