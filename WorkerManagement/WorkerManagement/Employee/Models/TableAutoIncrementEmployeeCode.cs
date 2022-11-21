using WorkerManagement.Database.DataBaseAccess;

namespace WorkerManagement.Employee.Models
{
    public class TableAutoIncrementEmployeeCode
    {

        static Random randomCode = new Random();

        private static string _employeeCode;
        public static string RandomEmployeeCode
        {
            get
            {
                _employeeCode = "E" + randomCode.Next(10000, 100000);
                return _employeeCode;

            }

        }
    }

    }

