using FSMChildVersion.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.UI.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "User Profile")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}
