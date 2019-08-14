using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace FSMChildVersion.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            MenuItemList = new MvxObservableCollection<string>()
            {
                "Add New Farmer",
                "Feedback"
            };
        }



        #region MenuItemList;
        private ObservableCollection<string> _menuItemList;
        public ObservableCollection<string> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }
        #endregion

        #region ShowDetailPageAsyncCommand;
        private IMvxAsyncCommand _showDetailPageAsyncCommand;
        public IMvxAsyncCommand ShowDetailPageAsyncCommand
        {
            get
            {
                _showDetailPageAsyncCommand = _showDetailPageAsyncCommand ?? new MvxAsyncCommand(ShowDetailPageAsync);
                return _showDetailPageAsyncCommand;
            }
        }
        private async Task ShowDetailPageAsync()
        {
            switch (SelectedMenuItem)
            {
                case "Add New Farmer":
                    await NavigationService.Navigate<AddNewFarmerViewModel>();
                    break;
                case "Feedback":
                    await NavigationService.Navigate<FeedbackViewModel>();
                    break;
                default:
                    break;
            }
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage
                     && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }
        #endregion


        #region SelectedMenuItem;
        private string _selectedMenuItem;
        public string SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }
        #endregion
    }
}
