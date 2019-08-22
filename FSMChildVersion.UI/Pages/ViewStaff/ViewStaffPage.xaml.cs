using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.ViewStaff
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "View Staff")]
    public partial class ViewStaffPage : MvxContentPage<ViewStaffViewModel>
    {
        public ViewStaffPage()
        {
            InitializeComponent();
        }
    }
}
