using System.Collections.Generic;
using FSMChildVersion.Core.Pages.Dashboard.Farmer;
using FSMChildVersion.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.Core.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "HamburgerMenu Demo")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();


        }
        protected override void OnAppearing()
        {
            //listView.ItemsSource = new List<MvxContentPage>()
            //{
            //    new AddNewFarmerPage() { Title = "a b c" },
            //    new LeavePanelPage(){ Title = "d e f" },
            //    new FeedbackPage(){ Title = "g h i" }
            //};

            base.OnAppearing();
        }
    }
}
