using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Leaves
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Leave Panel")]
    public partial class LeavePanelPage : MvxContentPage<LeavePanelViewModel>
    {
        public LeavePanelPage()
        {
            InitializeComponent();
        }
    }
}
