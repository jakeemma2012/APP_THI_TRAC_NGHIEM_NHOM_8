using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_THI_TRAC_NGHIEM_BUS
{
    public class QuestionServices
    {
        public Model1 context = Services.getInstance().context;

        public static QuestionServices instance;

        public static QuestionServices gI()
        {
            if (instance == null)
            {
                instance = new QuestionServices();
            }
            return instance;
        }

      public List<Question> getAllquest()
        {
            return context.Questions.ToList();
        }

        public List<Question> getQuesTionBySubjecID(int id)
        {
            return context.Questions.Where(p => p.SubjectID == id).ToList();
        }

        public Question getQuestionById(int id)
        {
            return context.Questions.FirstOrDefault(p => p.QuestionID == id);
        }

    }
}
