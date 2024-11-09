using System.IO;

namespace StudentManagementSystem
{
    public static class DataLoader
    {
        public static void LoadSampleStudents()
        {
            if (!File.Exists("students.txt"))
            {
                var sampleStudents = new[]
                {
                    "1,John Smith,20,BIT",
                    "2,Alice Mabuza,22,BIT",
                    "3,Thabo Nkosi,19,BIT",
                    "4,Ntombi Zulu,21,BIT",
                    "5,Lebo Mashaba,23,BIT",
                    "6,Siphiwe Dlamini,24,BIT",
                    "7,Zodwa Khumalo,20,BIT",
                    "8,Naledi Mthethwa,22,BIT",
                    "9,Bongani Molefe,21,BIT",
                    "10,Andile Mkhize,22,BIT",
                    "11,Thandiwe Ntuli,23,BIT",
                    "12,Sizwe Nxumalo,24,BIT",
                    "13,Mandla Sithole,19,BIT",
                    "14,Nomusa Ngcobo,20,BIT",
                    "15,Kagiso Masango,21,BIT",
                    "16,Phumzile Mthembu,22,BIT",
                    "17,Ayanda Moyo,23,BIT",
                    "18,Sihle Mabaso,20,BIT",
                    "19,Khanyisile Ncube,21,BIT",
                    "20,Lindokuhle Mkhabela,22,BIT"
                };
                File.WriteAllLines("students.txt", sampleStudents);
            }
        }
    }
}