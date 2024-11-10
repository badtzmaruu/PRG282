/*  Jonathan Joubert 578085
    Zirong Luo 600287
    Keenan Lombard 578278
    Xander Minnie 600949 */
using System.IO; // Includes the System.IO namespace for file handling operations.

namespace StudentManagementSystem
{
    // Static class responsible for loading initial student data into a file.
    public static class DataLoader
    {
        // Method to load sample student records into a text file if it does not already exist.
        public static void LoadSampleStudents()
        {
            // Checks if the "students.txt" file already exists in the current directory.
            if (!File.Exists("students.txt"))
            {
                // Array of sample student records, each containing ID, name, age, and course.
                var sampleStudents = new[]
                {
                    "1,John Smith,20,BIT", // Represents a student record with basic details.
                    "2,Alice Mabuza,22,BIT", // Each record is separated by commas for easy parsing.
                    "3,Thabo Nkosi,19,BIT", // Contains ID, Name, Age, and Course.
                    "4,Ntombi Zulu,21,BIT", // Incorrect format in any of these records would cause parse issues later.

                    // Multiple student entries to populate initial data for testing or first-time use.
                    "5,Lebo Mashaba,23,BIT",
                    "6,Siphiwe Dlamini,24,BIT",
                    "7,Zodwa Khumalo,20,BIT",
                    "8,Naledi Mthethwa,22,BIT",
                    "9,Bongani Molefe,21,BIT",
                    "10,Andile Mkhize,22,BIT",

                    // Ensuring unique ID and consistent formatting for data reliability.
                    "11,Thandiwe Ntuli,23,BIT",
                    "12,Sizwe Nxumalo,24,BIT",
                    "13,Mandla Sithole,19,BIT",
                    "14,Nomusa Ngcobo,20,BIT",
                    "15,Kagiso Masango,21,BIT",
                    "16,Phumzile Mthembu,22,BIT",

                    // Including a sufficient number of records to simulate a small class size.
                    "17,Ayanda Moyo,23,BIT",
                    "18,Sihle Mabaso,20,BIT",
                    "19,Khanyisile Ncube,21,BIT", // Double-check record structures for errors.
                    "20,Lindokuhle Mkhabela,22,BIT"
                };

                // Writes all the sample student records into "students.txt" as individual lines.
                File.WriteAllLines("students.txt", sampleStudents); // File writing could fail due to permission issues.
            }
            // Note: If the file exists, no action is taken, preventing overwriting existing data.
        }
    }
}
