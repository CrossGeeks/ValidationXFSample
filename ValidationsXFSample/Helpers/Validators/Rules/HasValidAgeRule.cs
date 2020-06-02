using System;
namespace ValidationsXFSample.Validators.Rules
{
    public class HasValidAgeRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value is DateTime bday)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - bday.Year;
                return (age >= 18);
            }

            return false;
        }
    }
}
