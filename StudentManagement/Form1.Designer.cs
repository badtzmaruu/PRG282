/*  Jonathan Joubert 578085
    Zirong Luo 600287
    Keenan Lombard 578278
    Xander Minnie 600949*/
namespace StudentManagement
{
    partial class StudentManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            label6 = new Label();
            btnSummaryReport = new Button();
            btnAddStudent = new Button();
            cmbCourse = new ComboBox();
            label4 = new Label();
            numAge = new NumericUpDown();
            label3 = new Label();
            txtName = new TextBox();
            txtStudentID = new TextBox();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            btnEditStudent = new Button();
            button3 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            label5 = new Label();
            panel4 = new Panel();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnSummaryReport);
            panel1.Controls.Add(btnAddStudent);
            panel1.Controls.Add(cmbCourse);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(numAge);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtStudentID);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(352, 569);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.MenuHighlight;
            label6.Location = new Point(22, 13);
            label6.Name = "label6";
            label6.Size = new Size(247, 45);
            label6.TabIndex = 2;
            label6.Text = "Student Details";
            // 
            // btnSummaryReport
            // 
            btnSummaryReport.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSummaryReport.ForeColor = Color.DarkOrchid;
            btnSummaryReport.Location = new Point(22, 418);
            btnSummaryReport.Name = "btnSummaryReport";
            btnSummaryReport.Size = new Size(307, 62);
            btnSummaryReport.TabIndex = 12;
            btnSummaryReport.Text = "Generate Summary Report";
            btnSummaryReport.UseVisualStyleBackColor = true;
            btnSummaryReport.Click += btnSummaryReport_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddStudent.ForeColor = Color.DarkOrchid;
            btnAddStudent.Location = new Point(22, 334);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(307, 60);
            btnAddStudent.TabIndex = 11;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Items.AddRange(new object[] { "BIT", "DIT", "BComp", "DIT (Deaf Students)", "CIT (DB Dev)", "CIT (SW Dev)", "BIT (Part Time)" });
            cmbCourse.Location = new Point(22, 274);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(307, 23);
            cmbCourse.TabIndex = 10;
            cmbCourse.Text = "Choose a course";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(22, 251);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 9;
            label4.Text = "Course";
            // 
            // numAge
            // 
            numAge.Location = new Point(22, 218);
            numAge.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(307, 23);
            numAge.TabIndex = 8;
            numAge.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(22, 195);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 7;
            label3.Text = "Age";
            // 
            // txtName
            // 
            txtName.Location = new Point(22, 163);
            txtName.Name = "txtName";
            txtName.Size = new Size(307, 23);
            txtName.TabIndex = 6;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(22, 108);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(307, 23);
            txtStudentID.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 74);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 100);
            panel3.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(19, 11);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 3;
            label1.Text = "StudentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(19, 66);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 5;
            label2.Text = "Name";
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(17, 16);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(702, 334);
            dataGridView1.TabIndex = 7;
            // 
            // btnEditStudent
            // 
            btnEditStudent.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditStudent.ForeColor = Color.Crimson;
            btnEditStudent.Location = new Point(266, 410);
            btnEditStudent.Name = "btnEditStudent";
            btnEditStudent.Size = new Size(206, 53);
            btnEditStudent.TabIndex = 4;
            btnEditStudent.Text = "Edit";
            btnEditStudent.UseVisualStyleBackColor = true;
            btnEditStudent.Click += btnEditStudent_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Crimson;
            button3.Location = new Point(17, 410);
            button3.Name = "button3";
            button3.Size = new Size(206, 53);
            button3.TabIndex = 5;
            button3.Text = "Prev";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Crimson;
            button1.Location = new Point(513, 410);
            button1.Name = "button1";
            button1.Size = new Size(206, 53);
            button1.TabIndex = 8;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(btnEditStudent);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(372, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(736, 477);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(356, 32);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDarkDark;
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(372, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(736, 77);
            panel4.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.MenuHighlight;
            label7.Location = new Point(158, 13);
            label7.Name = "label7";
            label7.Size = new Size(458, 45);
            label7.TabIndex = 1;
            label7.Text = "Student Management System";
            // 
            // StudentManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1120, 593);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "StudentManagement";
            Text = "Student Management";
            Load += StudentManagement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnAddStudent;
        private ComboBox cmbCourse;
        private Label label4;
        private NumericUpDown numAge;
        private Label label3;
        private TextBox txtName;
        private TextBox txtStudentID;
        private Button btnSummaryReport;

        #endregion

        private Label label6;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button btnEditStudent;
        private Button button3;
        private Button button1;
        private Panel panel2;
        private Label label5;
        private Panel panel4;
        private Label label7;
    }
}
