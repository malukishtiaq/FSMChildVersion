using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Farmer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Farmer Visit")]
    public partial class FarmerVisitPage : MvxContentPage<FarmerVisitViewModel>
    {
        public FarmerVisitPage()
        {
            InitializeComponent();
        }
    }
}
