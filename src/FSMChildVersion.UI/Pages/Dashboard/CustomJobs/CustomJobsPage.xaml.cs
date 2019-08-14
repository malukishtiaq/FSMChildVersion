using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.Core.Pages.Dashboard.CustomJobs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class CustomJobsPage : MvxContentPage<CustomJobsViewModel>
    {
        public CustomJobsPage()
        {
            InitializeComponent();
        }
    }
}