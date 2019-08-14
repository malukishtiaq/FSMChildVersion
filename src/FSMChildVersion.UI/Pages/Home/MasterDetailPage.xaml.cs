using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.Core.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false, Title = "MasterDetail Page")]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Root, WrapInNavigationPage = false, Title = "MasterDetail Page")]
    public partial class MasterDetailPage : MvxMasterDetailPage<MasterDetailViewModel>
    {
        public MasterDetailPage()
        {
            InitializeComponent();
        }
    }
}
