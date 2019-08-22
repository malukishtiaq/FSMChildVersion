using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.ViewStaff
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Area Manager")]
    public partial class ViewAreaManagerPage : MvxContentPage<ViewAreaManagerViewModel>
    {
        public ViewAreaManagerPage()
        {
            InitializeComponent();
        }
    }
}
