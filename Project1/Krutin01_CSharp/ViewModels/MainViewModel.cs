using System;
using static System.DateTime;

namespace Krutin01_CSharp.ViewModels
{
    internal class MainViewModel

    {

        public MainViewModel() { }
        private string[] westernZodiacSigns = new string[] { "Ram", "Bull", "Twins", "Crab", "Lion", "Virgin", "Scales", "Scorpion", "Centaur", "Sea-Goat", "Water Bearer", "Fish" };
        private string[] chineseZodiacSigns = new string[] { "Rat", "Ox", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        public int FindAge(int year)
        {
            int currentYear = DateTime.Now.Year;

            return currentYear - year;
        }
        public bool ValidateDate(int day,int month,int year)
        {
            return Convert.ToInt32(DateTime.Now.Year) >= year &&
                (day <= 31 && day >= 1) &&
                (month >= 1 && month <= 12) && 
                FindAge(year) <= 120;
        }
        public bool IsBirthday(int day, int month)
        {
            return (day == Convert.ToInt32(DateTime.Now.Day) && month == Convert.ToInt32(DateTime.Now.Month));
        }
        public string FindWesternZodiac(int day, int month)
        {
            int zodiacIndex = (month - 1) / 2 + (day >= 20 ? 1 : 0);
             string zodiacSign = westernZodiacSigns[zodiacIndex];
            return zodiacSign;
        }
        public string FindChineseZodiac(int year)
        {
            int startYear = 1901; 
            int chineseZodiacIndex = (year - startYear) % 12;
            string chineseZodiacSign = chineseZodiacSigns[chineseZodiacIndex];
            return chineseZodiacSign;
        }

    }
}
