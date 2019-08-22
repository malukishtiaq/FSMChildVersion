using FSMChildVersion.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = false)]
    public partial class Login : MvxContentPage<LoginViewModel>
    {
        public Login()
        {
            InitializeComponent();
        }
    }
}
