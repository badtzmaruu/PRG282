/*  Jonathan Joubert 578085
    Zirong Luo 600287
    Keenan Lombard 578278
    Xander Minnie 600949 */
namespace StudentManagementSystem
{
    // Static class that provides methods for validating student input data.
    public static class DataValidator
    {
        // Method to validate input fields for student records.
        // Returns a boolean indicating whether the input is valid and an out parameter for validation messages.
        public static bool ValidateInput(string studentID, string name, string age, string course, out string validationMessage)
        {
            validationMessage = ""; // Initializes the validation message as an empty string.

            // Checks if any of the input fields are empty or contain only whitespace.
            // Also checks if the 'age' field is a valid integer using TryParse.
            if (string.IsNullOrWhiteSpace(studentID) ||
                 string.IsNullOrWhiteSpace(name) || // Ensures the 'name' field is not empty or whitespace.
                !int.TryParse(age, out _) || // Validates if 'age' can be parsed as an integer value.
                string.IsNullOrWhiteSpace(course)) // Checks if the 'course' field is provided.
            {
                validationMessage = "Please fill in all fields corectly."; // Sets an error message if any field is invalid.
                return false; // Returns false indicating input validation has failed.
            }

            // If all fields pass the checks, returns true, indicating valid input.
            return true; // Indicates that the input data is valid.
        }
    }
}
