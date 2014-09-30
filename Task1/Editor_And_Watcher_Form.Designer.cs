namespace Task1
{
    partial class Editor_And_Watcher_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.TextBox();
            this.FIO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Group = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Course = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Sessions = new System.Windows.Forms.DataGridView();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Course)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sessions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ФИО:";
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(256, 64);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(260, 20);
            this.Status.TabIndex = 17;
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(10, 25);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(506, 20);
            this.FIO.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Форма обучения";
            // 
            // Group
            // 
            this.Group.Location = new System.Drawing.Point(144, 64);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(95, 20);
            this.Group.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Курс:";
            // 
            // Course
            // 
            this.Course.Location = new System.Drawing.Point(13, 64);
            this.Course.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Course.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(107, 20);
            this.Course.TabIndex = 15;
            this.Course.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Course.ValueChanged += new System.EventHandler(this.Course_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Группа:";
            // 
            // Sessions
            // 
            this.Sessions.AllowUserToAddRows = false;
            this.Sessions.AllowUserToDeleteRows = false;
            this.Sessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Sessions.Location = new System.Drawing.Point(10, 90);
            this.Sessions.Name = "Sessions";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Sessions.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Sessions.Size = new System.Drawing.Size(509, 107);
            this.Sessions.TabIndex = 18;
            this.Sessions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Sessions_CellValidating);
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(16, 218);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 19;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(441, 218);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 20;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // Editor_And_Watcher_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 262);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Sessions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Course);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Editor_And_Watcher_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor_And_Watcher_Form";
            ((System.ComponentModel.ISupportInitialize)(this.Course)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Group;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Course;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Sessions;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;

    }
}