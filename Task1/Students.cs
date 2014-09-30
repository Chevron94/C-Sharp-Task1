using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Task1
{
    [Serializable]
    public class Students
    {
        List<Student> allstudents = new List<Student>();
        int count = 0;
        [NonSerialized]DataGridView dgv;
        public Students() 
        {
        }

        public void AddDGV(ref DataGridView adgv)
        {
            dgv = adgv;
            PrintToDGV();
        }
        public void PrintToDGV()
        {
            dgv.RowCount = allstudents.Count;
            int i = 0;
            allstudents.ForEach(delegate(Student student)
            {
                student.PrintToGrid(dgv.Rows[i]);
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
                i++;
            });
        }

        public void Clear()
        {
            allstudents.Clear();
            count = 0;
        }

        public bool LoadFromTextFile(string FileName)
        {
            Clear();
            StreamReader TextFile = new StreamReader(FileName);
            while (!TextFile.EndOfStream)
            {
                Student tmp = new Student();
                if (tmp.LoadFromTextFile(ref TextFile))
                {
                    allstudents.Add(tmp);
                    count++;
                }
                else
                {
                    TextFile.Close();
                    PrintToDGV();
                    return false;
                }
            }
            TextFile.Close();
            PrintToDGV();
            return true;
        }
        public void SaveToTextFile(string FileName)
        {
            StreamWriter TextFile = new StreamWriter(FileName);
            allstudents.ForEach(delegate(Student student)
            {
                student.SaveToTextFile(ref TextFile);
            });
            TextFile.Close();
        }
        public void Add(Student astudent)
        {
            allstudents.Add(astudent);
            count++;
            PrintToDGV();
        }

        public bool Find(string FIO, ref Student aStudent) // Поиск только по фамилии
        {
            aStudent = allstudents.Find(x => x.FIO == FIO);
            if (aStudent == null)
                return false;
            else return true;
        }

        public bool Find(Student search, ref Student aStudent) // Поиск по фамилии + курс + группа
        {
            aStudent = allstudents.Find(x => x.FIO == search.FIO && x.Course == search.Course && x.Group == search.Group);
            if (aStudent == null)
                return false;
            else return true;
        }

        public bool Delete(string FIO)
        {
            Student tmp = allstudents.Find(x => x.FIO == FIO);
            if (tmp != null)
            {
                allstudents.Remove(tmp);
                count--;
                PrintToDGV();
                return true;
            }
            return false;
        }

        public bool Delete(Student search)
        {
            Student tmp  = allstudents.Find(x => x.FIO == search.FIO && x.Course == search.Course && x.Group == search.Group);
            if (tmp != null)
            {
                allstudents.Remove(tmp);
                count--;
                PrintToDGV();
                return true;
            }
            return false;
        }

        public double Count_Marks(string ASubject, int Course)
        {
            double result_score = 0;
            int count = 0;

            allstudents.ForEach(delegate(Student student)
            {
                if (student.Course == Course)
                {
                    double tmp = student.Middle(ASubject);
                    if (tmp != 0)
                    {
                        count++;
                        result_score += tmp;
                    }
                }
            });
            if (count > 0)
                return result_score / count;
            else return 0;
        }
        public List<Student> AllStudents
        {
            get
            {
                return allstudents;
            }
            set
            {
                allstudents = value;
            }
        }
    }
}
