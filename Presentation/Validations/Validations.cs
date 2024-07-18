using System.Text.RegularExpressions;

namespace Presentation.Validations
{
    public class Validation
    {
        public static bool ValidateEmployeeId(string id)
        {
            string exp = @"^TZ\d{4}$";
            Regex re = new Regex(exp);
            if (re.IsMatch(id))
                return true;
            return false;
        }
        public static bool ValidateName(string name)
        {
            string exp = @"^[a-zA-Z]+$";
            Regex re = new Regex(exp);
            if (re.IsMatch(name))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateEmail(string email)
        {
            string exp = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex re = new Regex(exp);
            if (re.IsMatch(email))
                return true;
            return false;
        }
        public static bool ValidateJoiningDate(string dateTime)
        {
            DateTime joiningDate;
            DateTime today = DateTime.Today;
            if (DateTime.TryParse(dateTime, out joiningDate))
            {
                if (joiningDate <= today)
                    return true;
            }
            return false;
        }
        public static bool ValidateManagerId(string managerId)
        {
            if (managerId == "None")
            {
                return true;
            }
            return false;
        }
        public static bool ValidateMobileNumber(string mobileNumber)
        {
            string exp = @"^[0-9]{10}$";
            Regex re = new Regex(exp);
            if (re.IsMatch(mobileNumber))
            {
                return true;
            }
            return false;
        }
    }
}
