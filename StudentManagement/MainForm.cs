using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataLoader.LoadSampleStudents(); // Load sample data if the file does not exist
            LoadStudentData(); // Load existing student data
        }

        private void LoadStudentData()
        {
            // Clear existing rows in the DataGridView
            dataGridViewStudents.Rows.Clear();

            // Check if the student data file exists
            if (File.Exists("students.txt"))
            {
                // Read all student records from the file
                var studentRecords = File.ReadAllLines("students.txt");

                // Populate the DataGridView with student data
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

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (DataValidator.ValidateInput(txtStudentID.Text, txtName.Text, txtAge.Text, txtCourse.Text, out string validationMessage))
            {
                // Gather student details from input fields
                string studentID = txtStudentID.Text;
                string name = txtName.Text;
                string age = txtAge.Text;
                string course = txtCourse.Text;

                // Create a student record string
                string studentRecord = $"{studentID},{name},{age},{course}";

                // Append the new student record to the file
                File.AppendAllLines("students.txt", new[] { studentRecord });

                // Refresh the DataGridView with updated data
                LoadStudentData();

                // Clear input fields
                ClearInputFields();

                MessageBox.Show("Student added successfully!");
            }
            else
            {
                MessageBox.Show(validationMessage);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (DataValidator.ValidateInput(txtStudentID.Text, txtName.Text, txtAge.Text, txtCourse.Text, out string validationMessage))
            {
                string studentID = txtStudentID.Text;
                string[] studentRecords = File.ReadAllLines("students.txt");
                bool isUpdated = false;

                for (int i = 0; i < studentRecords.Length; i++)
                {
                    var details = studentRecords[i].Split(',');
                    if (details[0] == studentID)
                    {
                        studentRecords[i] = $"{studentID},{txtName.Text},{txtAge.Text},{txtCourse.Text}";
                        isUpdated = true;
                        break;
                    }
                }

                if (isUpdated)
                {
                    File.WriteAllLines("students.txt", studentRecords);
                    MessageBox.Show("Student information updated successfully!");
                    LoadStudentData();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Student ID not found.");
                }
            }
            else
            {
                MessageBox.Show(validationMessage);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                // Confirm deletion with the user
                var confirmDelete = MessageBox.Show("Are you sure you want to delete the selected student(s)?", 
                                                    "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    // Delete selected students
                    foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                    {
                        var studentId = row.Cells[0].Value.ToString();
                        DeleteStudentRecord(studentId);
                    }
                    // Reload student data to update the DataGridView
                    LoadStudentData();
                    MessageBox.Show("Student(s) deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void DeleteStudentRecord(string studentId)
        {
            // Read all lines from the student data file
            var allStudentEntries = File.ReadAllLines("students.txt");

            // Filter out the student record with the matching ID
            var updatedEntries = allStudentEntries.Where(entry => !entry.StartsWith(studentId)).ToArray();

            // Write the updated entries back to the file
            File.WriteAllLines("students.txt", updatedEntries);
        }

        private void ClearInputFields()
        {
            // Clear the input fields
            txtStudentID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCourse.Clear();
        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            // Load selected student's details into input fields for editing
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewStudents.SelectedRows[0];
                txtStudentID.Text = selectedRow.Cells[0].Value.ToString();
                txtName.Text = selectedRow.Cells[1].Value.ToString();
                txtAge.Text = selectedRow.Cells[2].Value.ToString();
                txtCourse.Text = selectedRow.Cells[3].Value.ToString();
            }
        }
    }
}