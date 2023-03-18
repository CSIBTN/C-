using Krutin02_CSharp.data.viewmodels;
using Krutin02_CSharp.viewmodels.models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Krutin02_CSharp
{
    
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();
        private bool valFirstNameEntered = false;
        private bool valLastNameEntered = false;
        private bool valEmailEntered = false;
        private bool valDatePicked = false;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                valFirstNameEntered = true;
                unlockButton();
            }
        }


        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                valLastNameEntered = true;
                unlockButton();
            }
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailTextBox.Text))
            {
                valEmailEntered = true;
                unlockButton();
            }
        }

        private void DateOfBirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = DateOfBirthDatePicker.SelectedDate.GetValueOrDefault();
            if (selectedDate != default(DateTime)){
                if (viewModel.ValidateDate(selectedDate.Day, selectedDate.Month, selectedDate.Year)) {
                    if (viewModel.IsBirthday(selectedDate.Day, selectedDate.Month))
                    {
                        MessageBox.Show("Happy Birthday!", "Bday!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    valDatePicked = true;
                    unlockButton();
                }
                else
                {
                    MessageBox.Show("You've entered the wrong date! Pick the correct one!", "WRONG DATE", MessageBoxButton.OK, MessageBoxImage.Error);
                    DateOfBirthDatePicker.SelectedDate = default(DateTime);
                }
            }
            
        }
        private void unlockButton()
        {
            if(valFirstNameEntered && valLastNameEntered && valEmailEntered && valDatePicked)
            {
                ProceedButton.IsEnabled = true;           
            }
        }

        async private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            suspendUI(false);

            String firstName = FirstNameTextBox.Text;
            String lastName = LastNameTextBox.Text;
            String email = EmailTextBox.Text;
            DateTime bDate = (DateTime)DateOfBirthDatePicker.SelectedDate;

            await Task.Run(() =>
            {
                if(viewModel.checkIfEmailIsCorrect(email) 
                && viewModel.checkIfNameAndSurnameAreCorrect(firstName, lastName))
                {
                    Person createdPerson = new Person(
                        firstName: firstName,
                        lastName: lastName,
                        email: email,
                        dateOfBirth: bDate
                    );
                    MessageBox.Show($"User : \nFirst Name : {createdPerson.FirstName} \nLast Name : {createdPerson.LastName} \n" +
                        $"Email : {createdPerson.Email} \nBDate : {createdPerson.DateOfBirth} \nAdult : {createdPerson.IsAdult} \n" +
                        $"Sun sign : {createdPerson.SunSign} \nChinese sign : {createdPerson.ChineseSign}"
                        
                        , "Created User", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Your email or name might me wrong! Check it ones again!", "WRONG INPUT", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            suspendUI(true);
        }

        private void suspendUI(Boolean isToBeSuspended)
        {
            FirstNameTextBox.IsEnabled = isToBeSuspended;
            LastNameTextBox.IsEnabled = isToBeSuspended;
            EmailTextBox.IsEnabled = isToBeSuspended;
            DateOfBirthDatePicker.IsEnabled = isToBeSuspended;
            ProceedButton.IsEnabled = isToBeSuspended;
        }
    }
}
