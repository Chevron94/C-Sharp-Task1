using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public enum Form_Modes { Add, Find, Edit, Watch }
    public partial class Editor_And_Watcher_Form : Form
    {
        public Editor_And_Watcher_Form()
        {
            InitializeComponent();
            Sessions.RowCount = 4;
            Sessions.ColumnCount = 5;
            int CellWidth = 70;
            Sessions.RowHeadersWidth = 2 * CellWidth;
            PrintHeaders();
        }
        Student student;
        Form_Modes mode;
        bool result = false;
        private void PrintHeaders()
        {
            int CellWidth = 70;
            for (int i = 0; i < 5; i++)
            {
                Sessions.Columns[i].Width = CellWidth;
                Sessions.Columns[i].HeaderText = (i + 1).ToString();
            }
            for (int i = 0; i < Sessions.RowCount; i++)
            {
                if (i % 2 == 0)
                    Sessions.Rows[i].HeaderCell.Value = (i / 2 + 1).ToString() + " семестр(Предмет)";
                else Sessions.Rows[i].HeaderCell.Value = (i / 2 + 1).ToString() + " семестр(Оценка)";
            }
        }

        private void Course_ValueChanged(object sender, EventArgs e)
        {
            Sessions.RowCount = 4*(int)Course.Value;
            PrintHeaders();
        }
        public Student Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                FIO.Text = value.FIO;
                Course.Value = value.Course;
                Group.Text = value.Group;
                Status.Text = value.Status;
                for (int i = 0; i < value.Session.Length; i++)
                    value.Session[i].PrintToGrid(Sessions.Rows[2 * i], Sessions.Rows[2 * i + 1]);
            }
        }
        public Form_Modes Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                switch (mode)
                {
                    case Form_Modes.Add:
                        {
                            Text = "Добавление";
                            FIO.ReadOnly = false;
                            Course.ReadOnly = true;
                            Course.Enabled = true;
                            Group.ReadOnly = false;
                            Status.ReadOnly = false;
                            Sessions.ReadOnly = false;
                            Cancel.Visible = true;
                            break;
                        }
                    case Form_Modes.Watch:
                        {
                            Text = "Просмотр";
                            FIO.ReadOnly = true;
                            Course.ReadOnly = true;
                            Course.Enabled = false;
                            Group.ReadOnly = true;
                            Status.ReadOnly = true;
                            Sessions.ReadOnly = true;
                            Cancel.Visible = false;
                            break;
                        }
                    case Form_Modes.Find:
                        {
                            Text = "Поиск";
                            FIO.ReadOnly = false;
                            Course.ReadOnly = true;
                            Course.Enabled = true;
                            Group.ReadOnly = false;
                            Status.ReadOnly = true;
                            Sessions.ReadOnly = true;
                            Cancel.Visible = true;
                            break;
                        }
                }
            }
        }
        private bool IsEmptySession()
        {
            for (int i = 0; i < Sessions.RowCount; i++)
                for (int j = 0; j < Sessions.ColumnCount; j++)
                    if (Sessions.Rows[i].Cells[j].Value == null || Sessions.Rows[i].Cells[j].Value.ToString().Trim() == "")
                        return true;
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == Form_Modes.Add)
            {
                if (FIO.Text.Trim() == "" || Group.Text.Trim() == "" ||
                    Status.Text.Trim() == "" || IsEmptySession())
                    MessageBox.Show("Форма заполнена не полностью!");
                else
                {
                    student = new Student();
                    student.FIO = FIO.Text;
                    student.Course = (int)Course.Value;
                    student.Group = Group.Text;
                    Student.Status = Status.Text;
                    for (int i = 0; i < Sessions.RowCount - 1; i += 2)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            student.Session[i / 2].Subjet[j] = Sessions.Rows[i].Cells[j].Value.ToString();
                            student.Session[i / 2].Mark[j] = Convert.ToInt32(Sessions.Rows[i + 1].Cells[j].Value);
                        }

                    }
                    result = true;
                    this.Close();
                }
            }
            else
                if (mode == Form_Modes.Find)
                {
                    if (FIO.Text.Trim() == "" || Group.Text.Trim() == "")
                        MessageBox.Show("Форма заполнена не полностью!");
                    else
                    {
                        student = new Student();
                        student.FIO = FIO.Text;
                        student.Course = (int)Course.Value;
                        student.Group = Group.Text;
                        result = true;
                        this.Close();
                    }
                }
                else this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = false;
            this.Close();
        }

        public bool Result
        {
            get
            {
                return result;
            }
        }

        private void Sessions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex % 2 == 1 && (mode == Form_Modes.Add))
            {
                string tmp = e.FormattedValue.ToString();
                int mark;
                if (!Int32.TryParse(tmp, out mark) || mark < 2 || mark > 5)
                {
                    MessageBox.Show("Неверная оценка");
                    e.Cancel = true;
                }

            }
        }

    }
}
