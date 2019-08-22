using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Policies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Policies")]
    public partial class ViewPoliciesPage : MvxContentPage<ViewPoliciesViewModel>
    {
        public ViewPoliciesPage()
        {
            InitializeComponent();
        }
    }
}
