using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krutin02_CSharp.viewmodels.models;

namespace Krutin02_CSharp.data.viewmodels
{
    internal class MainViewModel
    {
        public MainViewModel() { }
       
        public int FindAge(int year)
        {
            int currentYear = DateTime.Now.Year;

            return currentYear - year;
        }
        public bool ValidateDate(int day, int month, int year)
        {
            if(!FindAge(year) <= 135)
            {
                throw new TooOldException("You're too old!");
            }

            if(!(Convert.ToInt32(DateTime.Now.Year) >= year &&
                Convert.ToInt32(DateTime.Now.Month) >= month &&
                Convert.ToInt32(DateTime.Now.Day) >= day))
            {
                throw new FutureBirthdayException("You haven't been born yet!")
            }

            return 
                (day <= 31 && day >= 1) &&
                (month >= 1 && month <= 12);
        }
        public bool IsBirthday(int day, int month)
        {
            return (day == Convert.ToInt32(DateTime.Now.Day) && month == Convert.ToInt32(DateTime.Now.Month));
        }

        public bool checkIfNameAndSurnameAreCorrect(string name, string surname)
        {
            return (name.Length >= 2 && surname.Length >= 2);
        }
        public bool checkIfEmailIsCorrect(string email)
        {
            return email.Contains("@");
        }
    }
}
