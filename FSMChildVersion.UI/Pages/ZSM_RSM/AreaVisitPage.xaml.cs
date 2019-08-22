using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.ZSM_RSM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Area Visit")]
    public partial class AreaVisitPage : MvxContentPage<AreaVisitViewModel>
    {
        public AreaVisitPage()
        {
            InitializeComponent();
        }
    }
}
