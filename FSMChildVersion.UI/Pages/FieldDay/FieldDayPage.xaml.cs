using MvvmCross.Forms.Views;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;
using FSMChildVersion.Core.ViewModels;

namespace FSMChildVersion.UI.Pages.Farmer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Field Day")]
    public partial class FieldDayPage : MvxContentPage<FieldDayViewModel>
    {
        public FieldDayPage()
        {
            InitializeComponent();
        }
    }
}
