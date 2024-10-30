namespace StudentManagement
{
    partial class StudentManagement
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnAddStudent = new Button();
            cmbCourse = new ComboBox();
            label4 = new Label();
            numAge = new NumericUpDown();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtStudentID = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            panel4 = new Panel();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(btnAddStudent);
            panel1.Controls.Add(cmbCourse);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(numAge);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtStudentID);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(352, 569);
            panel1.TabIndex = 0;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(19, 248);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(307, 52);
            btnAddStudent.TabIndex = 11;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Items.AddRange(new object[] { "Course1", "Course2", "Course3", "Course4" });
            cmbCourse.Location = new Point(19, 200);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(307, 23);
            cmbCourse.TabIndex = 10;
            cmbCourse.Text = "Choose a course";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 182);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Course";
            // 
            // numAge
            // 
            numAge.Location = new Point(19, 144);
            numAge.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(307, 23);
            numAge.TabIndex = 8;
            numAge.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 126);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 7;
            label3.Text = "Age";
            // 
            // txtName
            // 
            txtName.Location = new Point(19, 89);
            txtName.Name = "txtName";
            txtName.Size = new Size(307, 23);
            txtName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 71);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Name";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(19, 34);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(307, 23);
            txtStudentID.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 16);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "StudentID";
            // 
            // panel3
            // 
            panel3.Location = new Point(687, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(336, 301);
            panel3.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(372, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(736, 477);
            panel2.TabIndex = 1;
            // 
            // button3
            // 
            button3.Location = new Point(17, 410);
            button3.Name = "button3";
            button3.Size = new Size(206, 53);
            button3.TabIndex = 5;
            button3.Text = "Focus";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(266, 410);
            button2.Name = "button2";
            button2.Size = new Size(206, 53);
            button2.TabIndex = 4;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(515, 410);
            button4.Name = "button4";
            button4.Size = new Size(206, 53);
            button4.TabIndex = 3;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 16);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(704, 378);
            dataGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDarkDark;
            panel4.Controls.Add(label5);
            panel4.Location = new Point(372, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(736, 86);
            panel4.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(209, 25);
            label5.Name = "label5";
            label5.Size = new Size(347, 32);
            label5.TabIndex = 0;
            label5.Text = "Student Management System";
            // 
            // StudentManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1120, 596);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StudentManagement";
            Text = "Form1";
            Load += StudentManagement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Label label1;
        private Button btnAddStudent;
        private ComboBox cmbCourse;
        private Label label4;
        private NumericUpDown numAge;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtStudentID;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button2;
        private Button button4;
        private Label label5;
    }
}