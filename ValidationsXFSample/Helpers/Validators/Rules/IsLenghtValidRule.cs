
namespace ValidationsXFSample.Validators.Rules
{
    public class IsLenghtValidRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public int MinimunLenght { get; set; }
        public int MaximunLenght { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return (str.Length > MinimunLenght && str.Length <= MaximunLenght);
        }
    }

}
