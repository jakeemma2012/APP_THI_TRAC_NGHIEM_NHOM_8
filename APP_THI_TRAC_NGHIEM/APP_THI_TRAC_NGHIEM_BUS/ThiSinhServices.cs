using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Thi_Trac_Nghiem_BUS
{
    public class ThiSinhServices
    {

        public Model1 context = Services.getInstance().context;

        public static ThiSinhServices instance;

        public static ThiSinhServices gI()
        {
            if (instance == null)
            {
                instance = new ThiSinhServices();
            }
            return instance;
        }


        public Student getThiSinhByMS(string MS)
        {
            return context.Students.FirstOrDefault(p => p.StudentID.CompareTo(MS) == 0);
        }

        public Student getThiSinhByUserId(int idUser)
        {
            return context.Students.FirstOrDefault(p => p.UserID == idUser);
        }

        public Student getThiSinhByMsAndIgnoreUserId(string MS,int idUser)
        {
            return context.Students.Where(p => p.StudentID.CompareTo(MS) == 0
            && p.UserID != idUser).FirstOrDefault();
        }

    }
}
