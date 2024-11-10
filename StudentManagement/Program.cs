using System;
using System.Windows.Forms;  // Needed for Application and Forms
using StudentManagementSystem; // Add this to reference DataLoader

namespace StudentManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Call LoadSampleStudents method from DataLoader to create the file if it doesn't exist
            DataLoader.LoadSampleStudents();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StudentManagement());
        }
    }
}
