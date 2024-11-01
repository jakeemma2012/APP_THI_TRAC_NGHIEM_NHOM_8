using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_THI_TRAC_NGHIEM_BUS
{
    public class AttempsServices
    {

        public Model1 context = Services.getInstance().context;
        public static AttempsServices instance;

        public static AttempsServices gI()
        {
            if (instance == null)
            {
                instance = new AttempsServices();
            }
            return instance;
        }


        public Attempt getAtempByUserIdAndExamID(int idexam , int idUser)
        {
            return context.Attempts.FirstOrDefault(p => p.ExamID == idexam &&p.UserID == idUser);
        }

    }
}
