using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Dealer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Add New Dealer")]
    public partial class AddNewDealerPage : MvxContentPage<AddNewDealerViewModel>
    {
        public AddNewDealerPage()
        {
            InitializeComponent();
        }
    }
}
