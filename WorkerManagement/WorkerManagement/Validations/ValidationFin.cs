using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WorkerManagement.Validations
{
    public class ValidationFin : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var fin = value.ToString();

            string regexed = @"^([A-Z0-9]{7}$)";

            return Regex.IsMatch(fin, regexed);


        }

    }
}
