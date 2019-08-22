using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.AreaManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class AreaManagerDashboardPage : MvxContentPage<AreaManagerDashboardViewModel>
    {
        public AreaManagerDashboardPage()
        {
            InitializeComponent();
        }
    }
}