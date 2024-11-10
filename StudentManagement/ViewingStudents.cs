/*  Jonathan Joubert 578085
    Zirong Luo 600287
    Keenan Lombard 578278
    Xander Minnie 600949 */
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class ViewStudentsForm : Form
    {
      // Constructor for the ViewStudentsForm class that initializes the form components.
        public ViewStudentsForm()
        {
            InitializeComponent(); // Initialize the componants needed for this form.
            DisplayStudents(); // Calls the method to load and display student records on form load.
        }

        // Method to display the student records in the DataGridView.
        private void DisplayStudents()
        {
            dataGridViewStudents.Rows.Clear(); // Clears existing rows to refresh data with updated entires.

            // Checks if the file containing student data exists.
             if (File.Exists("students.txt"))
            {
                var studentRecords = File.ReadAllLines("students.txt"); // Reads all lines from the student file.
    
                // Iterates over each record in the file and splits it by commas to extract student detailes.
                foreach (var record in studentRecords)
                {
                    var studentDetails = record.Split(','); // Splits a record into indivdual student details.

                    // Ensures that the record has exactly 4 details (ID, name, age, course).
                    if (studentDetails.Length == 4)
                    {
                        // Adds the student details as a new row in the DataGridView.
                        dataGridViewStudents.Rows.Add(studentDetails); // Adds rows without checking for duplicates.
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
                                                   MessageBoxButtons.YesNo); // Confirmation dialog with Yes/No options.

                // Proceeds only if the user confirms by clicking 'Yes'.
                if (confirmation == DialogResult.Yes)
                {
                    // Loops through each selected row in the DataGridView to delete corresponding student records.
                    foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                    {
                        // Gets the student ID from the first cell of the selected row.
                        var studentId = row.Cells[0].Value.ToString();
    
                        RemoveStudent(studentId); // Calls the method to remove the student from the file.
                    }

                    // Refreshes the DataGridView to reflect the changes after deletion.
                    DisplayStudents();
                    MessageBox.Show("Student(s) deleted succesfully!"); // Notify user of successful deletion.
                }
            }
                else // If no student is selected, show an alert.
            {
                MessageBox.Show("Please select a student to delete."); // Notify user to select a student before deletion.
            }
        }

        // Method to remove a student from the file based on their student ID.
        private void RemoveStudent(string studentId)
            {
            var allStudentLines = File.ReadAllLines("students.txt"); // Reads all lines from the student file.

            // Filters out the line that starts with the provided student ID to remove that specific record.
            var remainingLines = allStudentLines.Where(line => !line.StartsWith(studentId)).ToArray();

             // Writes the updated list back to the student file.
            File.WriteAllLines("students.txt", remainingLines); // Overwrites file without a backup, use cautiously.
        }
    }
}
