using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.Core.Pages.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false)]
    public partial class MasterTestPage : MvxMasterDetailPage<MasterTestViewModel>
    {
        public MasterTestPage()
        {
            InitializeComponent();
        }
    }
}