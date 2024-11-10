using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class ViewStudentsForm : Form
    {
        public ViewStudentsForm()
        {
            InitializeComponent();
            DisplayStudents();
        }

        private void DisplayStudents()
        {
            dataGridViewStudents.Rows.Clear();

            if (File.Exists("students.txt"))
            {
                var studentRecords = File.ReadAllLines("students.txt");
                foreach (var record in studentRecords)
                {
                    var studentDetails = record.Split(',');
                    if (studentDetails.Length == 4)
                    {
                        dataGridViewStudents.Rows.Add(studentDetails);
                    }
                }
            }
            else
            {
                MessageBox.Show("No student records found.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete the selected student(s)?", 
                                                   "Delete Confirmation",
                                                   MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                    {
                        var studentId = row.Cells[0].Value.ToString();
                        RemoveStudent(studentId);
                    }
                    DisplayStudents();
                    MessageBox.Show("Student(s) deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void RemoveStudent(string studentId)
        {
            var allStudentLines = File.ReadAllLines("students.txt");
            var remainingLines = allStudentLines.Where(line => !line.StartsWith(studentId)).ToArray();
            File.WriteAllLines("students.txt", remainingLines);
        }
    }
}