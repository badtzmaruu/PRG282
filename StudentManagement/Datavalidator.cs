namespace StudentManagementSystem
{
    public static class DataValidator
    {
        public static bool ValidateInput(string studentID, string name, string age, string course, out string validationMessage)
        {
            validationMessage = "";

            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(name) ||
                !int.TryParse(age, out _) ||
                string.IsNullOrWhiteSpace(course))
            {
                validationMessage = "Please fill in all fields correctly.";
                return false;
            }
            return true;
        }
    }
}