using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Task1
{
    [Serializable]
    public class Session
    {
        string[] subject = new string[5];
        int[] mark = new int[5];
        public Session() 
        {

        }
        public void PrintToGrid(DataGridViewRow Subjects, DataGridViewRow Marks)
        {
            for (int i = 0; i < 5; i++)
            {
                Subjects.Cells[i].Value = subject[i];
                Marks.Cells[i].Value = mark[i];
            }
        }
        public int Find_Mark_by_Subject(string asubject)
        {
            for (int i = 0; i < 5; i++)
            {
                if (subject[i] == asubject)
                    return mark[i];
            }
            return 0;
        }

        public void Print_Session(ref StreamWriter TextFile)
        {
            for (int i = 0; i < 5; i++)
            {
                TextFile.WriteLine("Предмет: " + subject[i]);
                TextFile.WriteLine("Оценка: " + mark[i].ToString());
            }
        }

        public string[] Subjet
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public int[] Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
    }
    
    [Serializable]
    public class Student
    {
        string fio;
        int course;
        string group;
        string status;
        Session[] session;
        public Student()
        {
 
        }
        public Student(string afio,int acourse, string agroup, string astatus, Session[] asession)
        {
            fio = afio;
            course = acourse;
            group = agroup;
            status = astatus;
            session = new Session[2 * course];
            Array.Copy(asession, session, 2*course);
        }
        protected string GetValue(string str, string sep)
        {
            int p;
            p = str.IndexOf(sep);
            if (p == -1)
                return "";
            else return (str.Substring(p + sep.Length, str.Length - p - sep.Length)).Trim();
        }
        protected bool GetValueFromFile(ref StreamReader TextFile, string sep, ref string val)
        {
            string str;
            if (TextFile.EndOfStream)
                return false;
            str = TextFile.ReadLine();
            val = GetValue(str, sep);
            if (val == "")
                return false;
            else return true;
        }

        public void SaveToTextFile(ref StreamWriter TextFile)
        {
            TextFile.WriteLine("ФИО: "+fio);
            TextFile.WriteLine("Курс: " + course.ToString());
            TextFile.WriteLine("Группа: " + group.ToString());
            TextFile.WriteLine("Форма обучения: " + status);
            for (int i = 0; i < session.Length; i++)
                session[i].Print_Session(ref TextFile);
        }

        public bool LoadFromTextFile(ref StreamReader TextFile)
        {
            string tmp="";
            bool tmpres = GetValueFromFile(ref TextFile, ":", ref fio) &&
                          GetValueFromFile(ref TextFile, ":", ref tmp) && Int32.TryParse(tmp, out course) &&
                          GetValueFromFile(ref TextFile, ":", ref group) && GetValueFromFile(ref TextFile, ":", ref status);
            if (!tmpres)
                return false;
            session = new Session[2 * course];
            for (int i = 0; i < 2 * Course; i++)
                session[i] = new Session();
            for (int i = 0; i < 2 * course && tmpres; i++)
                for (int j = 0; j < 5 && tmpres; j++)
                    tmpres = GetValueFromFile(ref TextFile, ":", ref session[i].Subjet[j]) &&
                             GetValueFromFile(ref TextFile, ":", ref tmp) && Int32.TryParse(tmp, out session[i].Mark[j]);
            return tmpres;
        }

        public void PrintToGrid(DataGridViewRow str)
        {
            str.Cells[0].Value = FIO;
            str.Cells[1].Value = Course;
            str.Cells[2].Value = Group;
            str.Cells[3].Value = Status;
            str.Cells[4].Value = "Просмотреть";
        }

        public double Middle(string ASubject)
        {
                int result = 0;
                int count = 0;
                for (int i = 0; i < session.Length; i++)
                {
                    int tmp = session[i].Find_Mark_by_Subject(ASubject);
                    if (tmp != 0)
                    {
                        count++;
                        result += tmp;
                    }
                }
                if (count > 0)
                    return (double)result / (double)count;
                else return 0;
        }
        public string FIO
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
            }
        }
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
                session = new Session[2 * course];
                for (int i = 0; i < 2 * Course; i++)
                    session[i] = new Session();
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public Session[] Session 
        {
            get
            {
                return session;
            }
            set
            {
                session = value;
            }
        }
    }
}
