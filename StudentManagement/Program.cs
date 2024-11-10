/*  Jonathan Joubert 578085
    Zirong Luo 600287
    Keenan Lombard 578278
    Xander Minnie 600949 */
using System; // Provides basic functions such as the Console class and basic data types.
using System.Windows.Forms; // Allows the use of Windows Forms for building desktop applications.
using StudentManagementSystem; // Includes the custom namespace where DataLoader and other utilities are defined.

namespace StudentManagement
{
    // Main entry class for the application.
    internal static class Program
    {
        // Attribute indicating that the COM threading model for the application is single-threaded apartment.
        [STAThread]
        static void Main()
        {
            // Calls the LoadSampleStudents method from the DataLoader class to create the "students.txt" file
            // if it doesn't already exist in the current directory.
            DataLoader.LoadSampleStudents(); // Ensures that sample data is loaded before the application starts.
            ApplicationConfiguration.Initialize(); // Initializse the app's global configurations and settings.

            // Starts the Windows Forms application and displays the main StudentManagement form.
            Application.Run(new StudentManagement()); // Runs the main form of the application, allowing user interaction.
        }
    }
}
