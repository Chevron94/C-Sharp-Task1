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
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }
        bool result = false;
        public void Form_Field(string name1, bool state1, string name2 = "", bool state2 = false)
        {
            label1.Text = name1;
            label1.Visible = state1;
            TextField.Visible = state1;

            label2.Text = name2;
            label2.Visible = state2;
            NumField.Visible = state2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = false;
            this.Close();
        }
        public string TextValue
        {
            get
            {
                return TextField.Text;
            }
        }
        public int IntValue
        {
            get
            {
                return (int)NumField.Value;
            }
        }
        public bool Result
        {
            get
            {
                return result;
            }
        }
    }
}
