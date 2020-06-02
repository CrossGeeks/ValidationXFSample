using ValidationsXFSample.ViewModels;
using Xamarin.Forms;

namespace ValidationsXFSample.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterPageViewModel();
        }
    }
}
