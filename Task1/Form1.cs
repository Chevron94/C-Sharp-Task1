using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int CellWidth = 70;
            StudentsWatcher.ColumnCount = 5;
            StudentsWatcher.RowHeadersWidth = CellWidth;
            StudentsWatcher.Columns[0].HeaderText = "ФИО";
            StudentsWatcher.Columns[1].HeaderText = "Курс";
            StudentsWatcher.Columns[2].HeaderText = "Группа";
            StudentsWatcher.Columns[3].HeaderText = "Форма обучения";
            StudentsWatcher.Columns[4].HeaderText = "Оценки";
            Students = new Students();
            Students.AddDGV(ref StudentsWatcher);
        }
        Students Students;
        public enum States { None, TextFile, BinaryFile, XMLFile }
        States State = States.None;
        string FileName;

        public bool GetSaveFileName(States State)
        {
            switch (State)
            {
                case States.BinaryFile:
                    {
                        saveFileDialog1.Filter = "Бинарный файл (*.dat)|*.dat";
                        break;
                    }
                case States.XMLFile:
                    {
                        saveFileDialog1.Filter = "XML файл (*.xml)|*.xml";
                        break;
                    }
                case States.TextFile:
                    {
                        saveFileDialog1.Filter = "Текстовый файл (*.txt)|*.txt";
                        break;
                    }
            }
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = saveFileDialog1.FileName;
                return true;
            }
            else return false;
        }

        public bool GetOpenFileName(States State) 
        {
            switch (State)
            {
                case States.BinaryFile:
                    {
                        openFileDialog1.Filter = "Бинарный файл (*.dat)|*.dat";
                        break;
                    }
                case States.XMLFile:
                    {
                        openFileDialog1.Filter = "XML-файл (*.xml)|*.xml";
                        break;
                    }
                case States.TextFile:
                    {
                        openFileDialog1.Filter = "Текстовый файл (*.txt)|*.txt";
                        break;
                    }
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;
                return true;
            }
            else return false; 
        }

        void MyIdle(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = State != States.None;
        }

        private void xMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetOpenFileName(States.XMLFile))
            {
                FileStream reader = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                XmlSerializer desirealizer = new XmlSerializer(typeof(Students));
                Students.Clear();
                Students = (Students)desirealizer.Deserialize(reader);
                State = States.XMLFile;
                reader.Close();
                Students.AddDGV(ref StudentsWatcher);
            }
        }

        private void binaryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetOpenFileName(States.BinaryFile))
            {
                FileStream reader = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter desiralizer = new BinaryFormatter();
                Students.Clear();
                Students = (Students)desiralizer.Deserialize(reader);
                State = States.BinaryFile;
                reader.Close();
                Students.AddDGV(ref StudentsWatcher);
            }
        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetOpenFileName(States.TextFile))
            {
                if (!Students.LoadFromTextFile(FileName))
                    MessageBox.Show("Данные повреждены");
                State = States.TextFile;
            }
        }

        private void xMLFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GetSaveFileName(States.XMLFile))
            {
                StreamWriter writer = new StreamWriter(FileName);//new FileStream("test.xml", FileMode.Open, FileAccess.Write);
                XmlSerializer serializer = new XmlSerializer(typeof(Students));
                serializer.Serialize(writer, Students);
                State = States.XMLFile;
                writer.Close();
            }
        }

        private void textFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GetSaveFileName(States.TextFile))
            {
                Students.SaveToTextFile(FileName);
            }
        }

        private void binaryFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GetSaveFileName(States.BinaryFile))
            {
                FileStream Writer = File.Create(FileName);
                BinaryFormatter Serializer = new BinaryFormatter();
                Serializer.Serialize(Writer, Students);
				State = States.BinaryFile;
                Writer.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (State)
            {
                case States.BinaryFile:
                    {
                        binaryFileToolStripMenuItem1.PerformClick();
                        break;
                    }
                case States.None:
                case States.TextFile:
                    {
                        textFileToolStripMenuItem1.PerformClick();
                        break;
                    }
                case States.XMLFile:
                    {
                        xMLFileToolStripMenuItem1.PerformClick();
                        break;
                    }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor_And_Watcher_Form AddForm = new Editor_And_Watcher_Form();
            AddForm.Mode = Form_Modes.Add;
            AddForm.ShowDialog();
            if (AddForm.Result)
                Students.Add(AddForm.Student);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input Input = new Input();
            Input.Form_Field("ФИО:", true);
            Input.ShowDialog();
            if (Input.Result)
            {
                Editor_And_Watcher_Form ShowForm = new Editor_And_Watcher_Form();
                ShowForm.Mode = Form_Modes.Watch;
                Student tmp = new Student();
                if (Students.Find(Input.TextValue, ref tmp))
                {
                    ShowForm.Student = tmp;
                    ShowForm.ShowDialog();
                }
                else MessageBox.Show("Студент не найден!");
            }
        }
    /*    private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor_And_Watcher_Form FindForm = new Editor_And_Watcher_Form();
            FindForm.Mode = Form_Modes.Find;
            FindForm.ShowDialog();
            if (FindForm.Result)
            {
                Student tmp = new Student();
                if (Students.Find(FindForm.Student, ref tmp))
                {
                    FindForm.Student = tmp;
                    FindForm.ShowDialog();
                }
                else MessageBox.Show("Студент не найден!");
            }
        }
        */
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Students = new Students();
            Students.AddDGV(ref StudentsWatcher);
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input Input = new Input();
            Input.Form_Field("ФИО:", true);
            Input.ShowDialog();
            if (Input.Result)
            {
                Editor_And_Watcher_Form EditForm = new Editor_And_Watcher_Form();
                EditForm.Mode = Form_Modes.Add;
                Student tmp = new Student();
                if (Students.Find(Input.TextValue, ref tmp))
                {
                    EditForm.Student = tmp;
                    EditForm.ShowDialog();
                    if (EditForm.Result)
                    {
                        Students.Delete(Input.TextValue);
                        Students.Add(EditForm.Student);
                    }
                }
                else MessageBox.Show("Студент не найден!");
            }
        }

     /*   private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor_And_Watcher_Form EditForm = new Editor_And_Watcher_Form();
            EditForm.Mode = Form_Modes.Find;
            EditForm.ShowDialog();
            if (EditForm.Result)
            {
                Student tmp = new Student();
                if (Students.Find(EditForm.Student, ref tmp))
                {
                    EditForm.Student = tmp;
                    EditForm.Mode = Form_Modes.Add;
                    EditForm.ShowDialog();
                    if (EditForm.Result)
                    {
                        Students.Delete(tmp);
                        Students.Add(EditForm.Student);
                    }
                }
                else MessageBox.Show("Студент не найден!");
            }
        }*/

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input Input = new Input();
            Input.Form_Field("ФИО:", true);
            Input.ShowDialog();
            if (Input.Result)
            {
                if (!Students.Delete(Input.TextValue))
                    MessageBox.Show("Студент не найден");
            }
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input Input = new Input();
            Input.Form_Field("Предмет:", true, "Курс:",true);
            Input.ShowDialog();
            if (Input.Result)
            {
                double tmp = Students.Count_Marks(Input.TextValue, Input.IntValue);
                if (tmp == 0)
                    MessageBox.Show("У данного курса введенного предмета не было");
                else MessageBox.Show("Средний балл по предмету "+Input.TextValue + " = " + Math.Round(tmp, 4).ToString());
            }
        }

        private void StudentsWatcher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Student tmp = new Student();
                tmp.FIO = StudentsWatcher.Rows[e.RowIndex].Cells[0].Value.ToString();
                tmp.Course =(int)StudentsWatcher.Rows[e.RowIndex].Cells[1].Value;
                tmp.Group = StudentsWatcher.Rows[e.RowIndex].Cells[2].Value.ToString();
               // Students.Find(StudentsWatcher.Rows[e.RowIndex].Cells[0].Value.ToString(), ref tmp);
                Students.Find(tmp, ref tmp);
                Editor_And_Watcher_Form ShowForm = new Editor_And_Watcher_Form();
                ShowForm.Mode = Form_Modes.Watch;
                ShowForm.Student = tmp;
                ShowForm.ShowDialog();
            }
        }
    }
}
