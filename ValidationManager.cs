using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSaveCSV
{
    class ValidationManager
    {
        public ValidationManager() { }
        public bool ValidateEmail(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Invalid email");
                return false;
            }
            return true;
        }
        //validate phone number
        public bool ValidatePhoneNumber(string phoneNo)
        {
            if (phoneNo.Length != 10 || !phoneNo.All(char.IsDigit))
            {
                Console.WriteLine("Phone number should be 10 digits");
                return false;
            }
            return true;
        }
    }
}
