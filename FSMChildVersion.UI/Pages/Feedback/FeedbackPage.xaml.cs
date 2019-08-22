using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Feedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Feedback")]
    public partial class FeedbackPage : MvxContentPage<FeedbackViewModel>
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }
    }
}
