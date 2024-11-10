using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class StudentManagement : Form
    {
        private List<Student> studentsList = new List<Student>();

        public StudentManagement()
        {
            InitializeComponent();
        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            // Load the student records into the DataGridView on form load
            LoadStudentRecords();
        }

        private void LoadStudentRecords()
        {
            if (File.Exists("students.txt"))
            {
                // Define the columns if they aren't already defined in the designer
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("StudentID", "Student ID");
                    dataGridView1.Columns.Add("Name", "Name");
                    dataGridView1.Columns.Add("Age", "Age");
                    dataGridView1.Columns.Add("Course", "Course");
                }

                var studentRecords = File.ReadAllLines("students.txt");

                // Iterate over the lines and add them to the DataGridView
                foreach (var record in studentRecords)
                {
                    var studentData = record.Split(',');
                    if (studentData.Length == 4)
                    {
                        // Add rows to the DataGridView
                        dataGridView1.Rows.Add(studentData[0], studentData[1], studentData[2], studentData[3]);
                    }
                }
            }
            else
            {
                MessageBox.Show("No student records found.");
            }
        }


        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text.Trim();
            string name = txtName.Text.Trim();
            string age = numAge.Value.ToString();
            string course = cmbCourse.SelectedItem?.ToString(); // Handle null if no course is selected

            string validationMessage;
            if (!DataValidator.ValidateInput(studentID, name, age, course, out validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            string newStudentRecord = $"{studentID},{name},{age},{course}";

            // Define the file path
            string filePath = Path.Combine(Application.StartupPath, "students.txt");

            // Check if the file exists, if not, create it
            if (!File.Exists(filePath))
            {
                // Create the file and write a header or leave it empty if you want
                try
                {
                    // Ensure the directory exists
                    string directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath); // Create directory if it doesn't exist
                    }

                    // Create the file and write headers
                    File.WriteAllText(filePath, "StudentID,Name,Age,Course\n");
                    MessageBox.Show($"File created successfully at: {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating file: {ex.Message}");
                    return;
                }
            }

            // Append the new student record to the file
            try
            {
                File.AppendAllLines(filePath, new[] { newStudentRecord });
                MessageBox.Show($"Student added successfully!\nFile path: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error appending to file: {ex.Message}");
            }

            ClearFormFields();

            // Reload the data to display the newly added student
            LoadStudentRecords();
        }

        private void ClearFormFields()
        {
            txtStudentID.Clear();
            txtName.Clear();
            numAge.Value = 18;
            cmbCourse.SelectedIndex = -1;
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string studentID = selectedRow.Cells[0].Value.ToString();
                string name = selectedRow.Cells[1].Value.ToString();
                string age = selectedRow.Cells[2].Value.ToString();
                string course = selectedRow.Cells[3].Value.ToString();

                // Open an edit form or enable input fields for editing
                txtStudentID.Text = studentID;
                txtName.Text = name;
                numAge.Value = Convert.ToDecimal(age);
                cmbCourse.SelectedItem = course;

                // After editing, save the updated data back to the file
                var updatedStudentRecord = $"{studentID},{txtName.Text},{numAge.Value},{cmbCourse.SelectedItem}";
                UpdateStudentRecord(studentID, updatedStudentRecord);

                // Reload the data to reflect the updated student
                LoadStudentRecords();
            }
            else
            {
                MessageBox.Show("Please select one student to edit.");
            }
        }

        private void UpdateStudentRecord(string studentID, string updatedRecord)
        {
            var allStudentLines = File.ReadAllLines("students.txt");
            var updatedLines = allStudentLines.Select(line =>
                line.StartsWith(studentID) ? updatedRecord : line).ToArray();
            File.WriteAllLines("students.txt", updatedLines);

            MessageBox.Show("Student updated successfully!");
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            if (File.Exists("students.txt"))
            {
                var studentRecords = File.ReadAllLines("students.txt");
                int totalStudents = studentRecords.Length;
                double averageAge = studentRecords
                    .Select(record => Convert.ToInt32(record.Split(',')[2]))
                    .Average();

                MessageBox.Show($"Total Students: {totalStudents}\nAverage Age: {averageAge:F2}");
            }
            else
            {
                MessageBox.Show("No student records found.");
            }
        }

        public class Student
        {
            public string StudentID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Course { get; set; }

            public Student(string studentID, string name, int age, string course)
            {
                StudentID = studentID;
                Name = name;
                Age = age;
                Course = course;
            }
        }
    }
}
