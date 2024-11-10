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
        private bool isEditing = false; // Flag to track if in edit mode
        private string selectedStudentID = ""; // Store the ID of the student being edited

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
            dataGridView1.Rows.Clear(); // Clear existing rows to avoid duplicates

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

                var studentRecords = File.ReadAllLines("students.txt").Skip(1); // Skip header if present

                // Add each student record as a row
                foreach (var record in studentRecords)
                {
                    var studentData = record.Split(',');
                    if (studentData.Length == 4)
                    {
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
            if (!isEditing)
            {
                // First click - load selected student's details into fields for editing
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    selectedStudentID = selectedRow.Cells[0].Value.ToString();
                    string name = selectedRow.Cells[1].Value.ToString();
                    string age = selectedRow.Cells[2].Value.ToString();
                    string course = selectedRow.Cells[3].Value.ToString();

                    // Populate fields with selected row's data for editing
                    txtStudentID.Text = selectedStudentID;
                    txtName.Text = name;
                    numAge.Value = Convert.ToDecimal(age);
                    cmbCourse.SelectedItem = course;

                    // Set the flag to indicate editing mode
                    isEditing = true;
                    btnEditStudent.Text = "Save Changes"; // Change button text to indicate saving
                }
                else
                {
                    MessageBox.Show("Please select one student to edit.");
                }
            }
            else
            {
                // Second click - save changes
                string updatedStudentRecord = $"{selectedStudentID},{txtName.Text},{numAge.Value},{cmbCourse.SelectedItem}";
                UpdateStudentRecord(selectedStudentID, updatedStudentRecord);

                // Reset editing mode and button text
                isEditing = false;
                btnEditStudent.Text = "Edit Student";

                // Clear fields and reload data to reflect the changes
                ClearFormFields();
                LoadStudentRecords();
            }
        }

        private void UpdateStudentRecord(string studentID, string updatedRecord)
        {
            // Read all lines from the file
            var allStudentLines = File.ReadAllLines("students.txt").ToList();

            // Update the selected student's record in the list
            for (int i = 0; i < allStudentLines.Count; i++)
            {
                if (allStudentLines[i].StartsWith(studentID + ","))
                {
                    allStudentLines[i] = updatedRecord;
                    break;
                }
            }

            // Write the updated list back to the file
            File.WriteAllLines("students.txt", allStudentLines);

            MessageBox.Show("Student updated successfully!");
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            if (File.Exists("students.txt"))
            {
                var studentRecords = File.ReadAllLines("students.txt").Skip(1); // Skip header if present
                int totalStudents = studentRecords.Count();
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
