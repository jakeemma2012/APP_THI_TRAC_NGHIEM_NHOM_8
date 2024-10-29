using APP_THI_TRAC_NGHIEM_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace App_Thi_Trac_Nghiem_BUS
{
    public class Services
    {
        public Model1 context = new Model1();

        public static Services instance;

        public Account account;

        public static Services getInstance()
        {
            if (instance == null)
            {
                instance = new Services();
            }
            return instance;
        }


        public List<Status> getAllStatus()
        {
            return context.Status.ToList();
        }

        public List<Subject> getAllSubjects()
        {
            return context.Subjects.ToList();   
        }

        public List<Subject> getSubjectById(int id)
        {
            return context.Subjects.Where(p=>p.SubjectID == id).ToList();
        }


        public void SetAccountLogin(Account acc)
        {
            if (acc != null)
            {
                this.account = acc;
            } else
            {
                MessageBox.Show("Xảy ra sự cố đăng nhập, vui lòng liên hệ lại bộ phận phát triển !");
                Environment.Exit(0);
            }

        }
        

    }
}
