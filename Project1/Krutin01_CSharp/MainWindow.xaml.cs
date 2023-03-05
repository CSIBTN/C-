using Krutin01_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Krutin01_CSharp
{
  
    public partial class MainWindow : Window
    {

        private MainViewModel viewModel = new MainViewModel();

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(BirthDayDate.SelectedDate != null)
            {
                int day = Convert.ToInt32(BirthDayDate.SelectedDate.Value.Day);
                int month = Convert.ToInt32(BirthDayDate.SelectedDate.Value.Month);
                int year = Convert.ToInt32(BirthDayDate.SelectedDate.Value.Year);
                if(viewModel.ValidateDate(day, month, year))
                {
                    Age.Text = $"You're {viewModel.FindAge(year).ToString()} years old ";
                    if (viewModel.IsBirthday(day,month))
                    {
                        BirthdayGreeting.Visibility = Visibility.Visible;
                        BirthdayGreeting.Text = "Happy birthday to you!" ;
                    }
                    WesternZodiac.Visibility = Visibility.Visible;
                    WesternZodiac.Text = "Western zodiac sign : " + viewModel.FindWesternZodiac(day, month);

                    ChineseZodiac.Visibility = Visibility.Visible;
                    ChineseZodiac.Text = "Chinese zodiac sign : " + viewModel.FindChineseZodiac(year);
                };
            }
        }
    }
}
