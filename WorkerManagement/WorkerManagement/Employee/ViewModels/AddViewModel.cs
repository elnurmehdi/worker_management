using System.ComponentModel.DataAnnotations;
using WorkerManagement.Validations;

namespace WorkerManagement.Employee.ViewModels
{
    public class AddViewModel
    {

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "First Name must contain at least 3 charachters and only letters")]
        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Last Name must contain at least 3 charachters and only letters")]

        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Father Name must contain at least 3 charachters and only letters")]
        [Required]
        public string FatherName { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        [ValidationFin(ErrorMessage = "Length of the FIN code must be 7 and can only consist of letters and numbers.")]
        public string FIN { get; set; }

        public AddViewModel()
        {

        }
        public AddViewModel(string firstName, string lastName, string fatherName, string email, string fin)
        {

            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Email = email;
            FIN = fin;
        }
    }
}
