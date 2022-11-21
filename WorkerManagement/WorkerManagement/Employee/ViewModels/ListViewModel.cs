namespace WorkerManagement.Employee.ViewModels
{
    public class ListViewModel
    {

        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public bool IsDeleted { get; set; }

        public ListViewModel(string employeeCode, string firstName, string lastName, string fatherName, bool ısDeleted)
        {
            EmployeeCode = employeeCode;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            IsDeleted = ısDeleted;
        }
    }
}
