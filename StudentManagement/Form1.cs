/*  Jonathan Joubert 578085
    Zirong Luo 600287
    Keenan Lombard 578278
    Xander Minnie 600949 */
using StudentManagementSystem; // References necessary classes like DataLoader and DataValidator.
using System;
using System.Collections.Generic; // Provides access to List<T>.
using System.IO; // Required for file input/output operations.
using System.Linq; // Used for LINQ operations.
using System.Windows.Forms; // Required for Windows Forms functionalities.

namespace StudentManagement
{
    public partial class StudentManagement : Form
    {
        // List to store students for display and manipulation.
        private List<Student> studentsList = new List<Student>();
        // Boolean flag to track if the form is in "editing mode".
        private bool isEditing = false;
        // Variable to hold the ID of the currently selected student for editing.
        private string selectedStudentID = "";

        public StudentManagement()
        {
            InitializeComponent(); // Initializes form components.
        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            // Load the student records into the DataGridView when the form is first loaded.
            LoadStudentRecords();
        }

        private void LoadStudentRecords()
        {
            dataGridView1.Rows.Clear(); // Clear existing rows to avoid duplicate entries.

            if (File.Exists("students.txt")) // Check if the student file exists.
            {
                // Ensure columns are defined if not already created in the designer.
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("StudentID", "Student ID");
                    dataGridView1.Columns.Add("Name", "Name");
                    dataGridView1.Columns.Add("Age", "Age");
                    dataGridView1.Columns.Add("Course", "Course");
                }

                // Skip header if present and read the student records.
                var studentRecords = File.ReadAllLines("students.txt").Skip(1);

                // Populate the DataGridView with student data.
                foreach (var record in studentRecords)
                {
                    var studentData = record.Split(',');
                    if (studentData.Length == 4) // Ensure data has the expected format.
                    {
                        dataGridView1.Rows.Add(studentData[0], studentData[1], studentData[2], studentData[3]);
                    }
                }
            }
            else
            {
                MessageBox.Show("No student records found."); // Display a message if the file doesn't exist.
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Gather and trim input from form controls.
            string studentID = txtStudentID.Text.Trim();
            string name = txtName.Text.Trim();
            string age = numAge.Value.ToString();
            string course = cmbCourse.SelectedItem?.ToString(); // Handle null if no course is selected.

            // Validate the input using a custom validation method.
            string validationMessage;
            if (!DataValidator.ValidateInput(studentID, name, age, course, out validationMessage))
            {
                MessageBox.Show(validationMessage);
                return; // Exit if validation fails.
            }

            // Construct a new student record.
            string newStudentRecord = $"{studentID},{name},{age},{course}";
            string filePath = Path.Combine(Application.StartupPath, "students.txt"); // Define the file path.

            // Check if the file exists; if not, create it with headers.
            if (!File.Exists(filePath))
            {
                try
                {
                    string directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath); // Create directory if needed.
                    }

                    // Create the file and write headers.
                    File.WriteAllText(filePath, "StudentID,Name,Age,Course\n");
                    MessageBox.Show($"File created successfully at: {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating file: {ex.Message}"); // Display error message if file creation fails.
                    return; // Exit after catching the exception.
                }
            }

            // Append the new student record to the file.
            try
            {
                File.AppendAllLines(filePath, new[] { newStudentRecord });
                MessageBox.Show($"Student added successfully!\nFile path: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error appending to file: {ex.Message}"); // Catch and show file appending error.
            }

            ClearFormFields(); // Reset form fields after adding the student.
            LoadStudentRecords(); // Reload the data to include the new student.
        }

        private void ClearFormFields()
        {
            txtStudentID.Clear(); // Clear the student ID text box.
            txtName.Clear(); // Clear the name text box.
            numAge.Value = 18; // Reset the numeric age selector to its default.
            cmbCourse.SelectedIndex = -1; // Deselect any selected course.
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // Check if a row is selected to edit.
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    selectedStudentID = selectedRow.Cells[0].Value.ToString(); // Get the ID from the selected row.
                    string name = selectedRow.Cells[1].Value.ToString();
                    string age = selectedRow.Cells[2].Value.ToString();
                    string course = selectedRow.Cells[3].Value.ToString();

                    // Populate form fields with data for editing.
                    txtStudentID.Text = selectedStudentID;
                    txtName.Text = name;
                    numAge.Value = Convert.ToDecimal(age);
                    cmbCourse.SelectedItem = course;

                    isEditing = true; // Set the editing flag to true.
                    btnEditStudent.Text = "Save Changes"; // Change the button text to indicate the save action.
                }
                else
                {
                    MessageBox.Show("Please select one student to edit."); // Display message if no or multiple rows are selected.
                }
            }
            else
            {
                // Construct the updated student record.
                string updatedStudentRecord = $"{selectedStudentID},{txtName.Text},{numAge.Value},{cmbCourse.SelectedItem}";
                UpdateStudentRecord(selectedStudentID, updatedStudentRecord);

                isEditing = false; // Reset editing flag.
                btnEditStudent.Text = "Edit Student"; // Reset the button text.

                ClearFormFields(); // Clear fields after saving changes.
                LoadStudentRecords(); // Refresh the DataGridView.
            }
        }

        private void UpdateStudentRecord(string studentID, string updatedRecord)
        {
            var allStudentLines = File.ReadAllLines("students.txt").ToList(); // Read the student file into a list.

            // Find and update the student's record in the list.
            for (int i = 0; i < allStudentLines.Count; i++)
            {
                if (allStudentLines[i].StartsWith(studentID + ","))
                {
                    allStudentLines[i] = updatedRecord;
                    break;
                }
            }

            // Write the updated list back to the file.
            File.WriteAllLines("students.txt", allStudentLines);
            MessageBox.Show("Student updated successfully!"); // Notify the user of a successful update.
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            if (File.Exists("students.txt"))
            {
                var studentRecords = File.ReadAllLines("students.txt").Skip(1); // Skip the header line.
                int totalStudents = studentRecords.Count(); // Count the number of students.

                double averageAge = studentRecords
                    .Select(record => Convert.ToInt32(record.Split(',')[2])) // Extract and convert the age field.
                    .Average(); // Calculate the average age.

                MessageBox.Show($"Total Students: {totalStudents}\nAverage Age: {averageAge:F2}"); // Display the summary report.
            }
            else
            {
                MessageBox.Show("No student records found."); // Notify the user if the file is missing.
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

        // Navigate to the next student row.
        private void button1_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            int nextIndex = currentIndex + 1;

            if (nextIndex < dataGridView1.Rows.Count) // Ensure the next index is within bounds.
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[nextIndex].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        // Navigate to the previous student row.
        private void button3_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            int prevIndex = currentIndex - 1;

            if (prevIndex >= 0) // Ensure the previous index is within bounds.
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[prevIndex].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }
    }
}
