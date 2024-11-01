using App_Thi_Trac_Nghiem_BUS;
using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_THI_TRAC_NGHIEM_BUS
{
    public class QuanLyServices
    {
        public Model1 context = Services.getInstance().context;
        public static QuanLyServices instance;
        public static QuanLyServices gI()
        {
            if (instance == null)
            {
                instance = new QuanLyServices();
            }
            return instance;
        }


        public List<Teacher> getAllTeacher()
        {
            return context.Teachers.ToList();   
        }

        public List<PerMission> getAllPerMis()
        {
            return context.PerMissions.ToList();    
        }

        public Teacher getTeacherByID(string idTeach)
        {
            return context.Teachers.FirstOrDefault(p => p.TeacherID.CompareTo(idTeach) == 0);
        }

        public Teacher getTeachByUserId(int id)
        {
            return context.Teachers.FirstOrDefault(p => p.UserID == id);
        }
        public Teacher getTeacherByIdAndIgnoreUserID(string MS, int idUser)
        {
            return context.Teachers.Where(p => p.TeacherID.CompareTo(MS) == 0
            && p.UserID != idUser).FirstOrDefault();
        }


       

    }
}
