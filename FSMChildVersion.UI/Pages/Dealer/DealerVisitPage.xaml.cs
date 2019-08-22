using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Dealer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Dealer Visit")]
    public partial class DealerVisitPage : MvxContentPage<DealerVisitViewModel>
    {
        public DealerVisitPage()
        {
            InitializeComponent();
        }
    }
}
