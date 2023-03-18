using System;

namespace Krutin02_CSharp.viewmodels.models
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public bool IsAdult
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age)) age--;
                return age >= 18;
            }
        }

        public string SunSign
        {
            get
            {
                int month = DateOfBirth.Month;
                int day = DateOfBirth.Day;

                if (month == 1)
                    return (day <= 20) ? "Capricorn" : "Aquarius";
                else if (month == 2)
                    return (day <= 19) ? "Aquarius" : "Pisces";
                else if (month == 3)
                    return (day <= 20) ? "Pisces" : "Aries";
                else if (month == 4)
                    return (day <= 20) ? "Aries" : "Taurus";
                else if (month == 5)
                    return (day <= 21) ? "Taurus" : "Gemini";
                else if (month == 6)
                    return (day <= 21) ? "Gemini" : "Cancer";
                else if (month == 7)
                    return (day <= 22) ? "Cancer" : "Leo";
                else if (month == 8)
                    return (day <= 23) ? "Leo" : "Virgo";
                else if (month == 9)
                    return (day <= 23) ? "Virgo" : "Libra";
                else if (month == 10)
                    return (day <= 23) ? "Libra" : "Scorpio";
                else if (month == 11)
                    return (day <= 22) ? "Scorpio" : "Sagittarius";
                else
                    return (day <= 21) ? "Sagittarius" : "Capricorn";
            }
        }

        public string ChineseSign
        {
            get
            {
                int year = DateOfBirth.Year;
                return ((year - 4) % 12) switch
                {
                    0 => "Rat",
                    1 => "Ox",
                    2 => "Tiger",
                    3 => "Rabbit",
                    4 => "Dragon",
                    5 => "Snake",
                    6 => "Horse",
                    7 => "Goat",
                    8 => "Monkey",
                    9 => "Rooster",
                    10 => "Dog",
                    11 => "Pig",
                    _ => "",
                };
            }
        }

        public bool IsBirthday
        {
            get
            {
                var today = DateTime.Today;
                return DateOfBirth.Day == today.Day && DateOfBirth.Month == today.Month;
            }
        }
    }
}