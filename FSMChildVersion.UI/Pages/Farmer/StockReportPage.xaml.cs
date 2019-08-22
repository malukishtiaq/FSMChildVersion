using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Farmer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Stock Reporting")]
    public partial class StockReportPage : MvxContentPage<StockReportViewModel>
    {
        public StockReportPage()
        {
            InitializeComponent();
        }
    }
}
