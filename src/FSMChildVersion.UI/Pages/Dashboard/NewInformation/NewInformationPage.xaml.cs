using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.Core.Pages.Dashboard.NewInformation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class NewInformationPage : MvxContentPage<NewInformationViewModel>
    {
        public NewInformationPage()
        {
            InitializeComponent();
        }
    }
}