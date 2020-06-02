using System;
using System.ComponentModel;
using System.Windows.Input;
using ValidationsXFSample.Validators;
using ValidationsXFSample.Validators.Rules;
using Xamarin.Forms;

namespace ValidationsXFSample.ViewModels
{
    public class RegisterPageViewModel: INotifyPropertyChanged
    {
        public ValidatableObject<string> FirstName { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> LastName { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<DateTime> BirthDay { get; set; } = new ValidatableObject<DateTime>() { Value = DateTime.Now };
        public ValidatableObject<string> PhoneNumber { get; set; } = new ValidatableObject<string>();
        public ValidatablePair<string> Email { get; set; } = new ValidatablePair<string>();
        public ValidatablePair<string> Password { get; set; } = new ValidatablePair<string>();
        public ValidatableObject<bool> TermsAndCondition { get; set; } = new ValidatableObject<bool>();

        public RegisterPageViewModel()
        {
            AddValidationRules();
        }

        public void AddValidationRules()
        {
            FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
            LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name Required" });
            BirthDay.Validations.Add(new HasValidAgeRule<DateTime> { ValidationMessage = "You must be 18 years of age or older" });
            PhoneNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Number Required" });
            PhoneNumber.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "Phone Number should have a maximun of 10 digits and minimun of 8", MaximunLenght = 10, MinimunLenght = 8 });
        
            //Email Validation Rules
            Email.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Email.Item1.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
            Email.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirm Email Required" });
            Email.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = "Email and confirm email don't match" });

            //Password Validation Rules
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item1.Validations.Add(new IsValidPasswordRule<string> { ValidationMessage = "Password between 8-20 characters; must contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirm password required" });
            Password.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = "Password and confirm password don't match" });

            TermsAndCondition.Validations.Add(new IsValueTrueRule<bool> { ValidationMessage = "Please accept tems and condition" });
        }


        public ICommand SignUpCommand => new Command(async () =>
        {
            if (AreFieldsValid())
            {
                await App.Current.MainPage.DisplayAlert("Welcome", "", "Ok");
            }
        });

        bool AreFieldsValid()
        {
            bool isFirstNameValid = FirstName.Validate();
            bool isLastNameValid = LastName.Validate();
            bool isBirthDayValid = BirthDay.Validate();
            bool isPhoneNumberValid = PhoneNumber.Validate();
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();
            bool isTermsAndConditionValid = TermsAndCondition.Validate();

            return isFirstNameValid && isLastNameValid && isBirthDayValid
                   && isPhoneNumberValid && isEmailValid && isPasswordValid && isTermsAndConditionValid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
