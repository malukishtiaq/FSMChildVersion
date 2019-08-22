using FSMChildVersion.Core.ViewModels;
using FSMChildVersion.UI.Pages.Popups;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.UI.Pages.RoutPlan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Rout Plan")]
    public partial class RoutPlanPage : MvxContentPage<RoutPlanViewModel>
    {
        public RoutPlanPage()
        {
            InitializeComponent();
        }

        private void DetailsCommandAsync(object sender, System.EventArgs e)
        {
            _ = PopupNavigation.Instance.PushAsync(new RoutDetails(), true);
        }
    }
}
