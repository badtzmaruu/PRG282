using System.Linq.Expressions;

namespace StudentManagement
{
    public partial class StudentManagement : Form
    {
        public StudentManagement()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            String studentID = txtStudentID.Text;
            String name = txtName.Text;
            int age = (int)numAge.Value;
            String course = cmbCourse.SelectedItem != null ? cmbCourse.SelectedItem.ToString() : "null";


            //Basic Validation
            if (course == "null")
            {
                MessageBox.Show("Please select an available course!");
                return;
            }
            else if ((name == "") || (studentID == ""))
            {
                MessageBox.Show("Please fill out all the fields!");
                return;
            }

            //Create Student Object

            //---------------------

            try
            {
                //Write to text file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            //Page Load Function
        }
    }
}