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

            private void btnAddStudent_Click(object sender, EventArgs e)
            {
                string studentID = txtStudentID.Text;
                string name = txtName.Text;
                int age = (int)numAge.Value;
                string course = cmbCourse.SelectedItem?.ToString() ?? "null";

                // Basic Validation
                if (course == "null")
                {
                    MessageBox.Show("Please select an available course!");
                    return;
                }
                else if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("Please fill out all the fields!");
                    return;
                }

                // Create Student Object
                Student student = new Student(studentID, name, age, course);
                studentsList.Add(student);

                // Write to text file
                try
                {
                    File.AppendAllText("students.txt", $"{studentID},{name},{age},{course}\n");
                    MessageBox.Show("Student added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void StudentManagement_Load(object sender, EventArgs e)
            {
                // Page Load Function
            }

            private void btnEditStudent_Click(object sender, EventArgs e)
            {
                string studentID = txtStudentID.Text;

                // Find student by ID
                var student = studentsList.FirstOrDefault(s => s.StudentID == studentID);
                if (student != null)
                {
                    // Update student information
                    student.Name = txtName.Text;
                    student.Age = (int)numAge.Value;
                    student.Course = cmbCourse.SelectedItem?.ToString() ?? "null";
                    MessageBox.Show("Student information updated successfully.");
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }

            private void btnSummaryReport_Click(object sender, EventArgs e)
            {
                // Generate summary report
                int totalStudents = studentsList.Count;
                double averageAge = studentsList.Any() ? studentsList.Average(s => s.Age) : 0;

                string summary = $"Total Students: {totalStudents}\nAverage Age: {averageAge:F2}";
                MessageBox.Show(summary);

                // Write summary to file
                File.WriteAllText("summary.txt", summary);
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
