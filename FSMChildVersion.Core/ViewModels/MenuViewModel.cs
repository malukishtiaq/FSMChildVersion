using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FSMChildVersion.Common.Constants;
using FSMChildVersion.Common.Enums;
using FSMChildVersion.Common.Extention;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace FSMChildVersion.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            CreateMenuList();
        }

        private void CreateMenuList()
        {
            MenuItemList = new MvxObservableCollection<string>(ConstantString.GetMenuItemList(GetSelectedRole()));
        }

        #region MenuItemList;
        private ObservableCollection<string> _menuItemList;
        public ObservableCollection<string> MenuItemList
        {
            get => _menuItemList;
            set
            {
                _menuItemList = value;
                RaisePropertyChanged(() => MenuItemList);
            }
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
            await ChoosePageToBeDisplayedAsync(GetSelectedRole());

            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }

        private async Task ChoosePageToBeDisplayedAsync(ERoles roles)
        {
            return;
            switch (roles)
            {
                case ERoles.FieldOfficer:
                    switch (SelectedMenuItem)
                    {
                        case ConstantString.AddNewFarmer:
                            await NavigationService.Navigate<AddNewFarmerViewModel>();
                            break;
                        case ConstantString.ViewFarmer:
                            await NavigationService.Navigate<ViewFarmerViewModel>();
                            break;
                        case ConstantString.FieldDay:
                            await NavigationService.Navigate<FieldDayViewModel>();
                            break;
                        case ConstantString.FarmerMeeting:
                            await NavigationService.Navigate<FarmerMeetingViewModel>();
                            break;
                        case ConstantString.StockReport:
                            await NavigationService.Navigate<StockReportViewModel>();
                            break;
                        case ConstantString.Orders:
                            await NavigationService.Navigate<OrdersViewModel>();
                            break;
                        case ConstantString.RoutPlan:
                            await NavigationService.Navigate<RoutPlanViewModel>();
                            break;
                        case ConstantString.ApplyForLeave:
                            await NavigationService.Navigate<LeavePanelViewModel>();
                            break;
                        case ConstantString.Feedback:
                            await NavigationService.Navigate<FeedbackViewModel>();
                            break;
                        default:
                            break;
                    };
                    break;
                case ERoles.AreaManager:
                    switch (SelectedMenuItem)
                    {
                        case ConstantString.AddNewDealer:
                            await NavigationService.Navigate<AddNewDealerViewModel>();
                            break;
                        case ConstantString.ViewDealers:
                            await NavigationService.Navigate<ViewDelearViewModel>();
                            break;
                        case ConstantString.Policies:
                            await NavigationService.Navigate<ViewPoliciesViewModel>();
                            break;
                        case ConstantString.FieldDay:
                            await NavigationService.Navigate<FieldDayViewModel>();
                            break;
                        case ConstantString.FarmerMeeting:
                            await NavigationService.Navigate<FarmerMeetingViewModel>();
                            break;
                        case ConstantString.RateList:
                            await NavigationService.Navigate<RateListViewModel>();
                            break;
                        case ConstantString.Orders:
                            await NavigationService.Navigate<OrdersViewModel>();
                            break;
                        case ConstantString.RoutPlan:
                            await NavigationService.Navigate<RoutPlanViewModel>();
                            break;
                        case ConstantString.ApplyForLeave:
                            await NavigationService.Navigate<LeavePanelViewModel>();
                            break;
                        case ConstantString.Feedback:
                            await NavigationService.Navigate<FeedbackViewModel>();
                            break;
                        default:
                            break;
                    }
                    break;
                case ERoles.ZSM_RSM:
                    switch (SelectedMenuItem)
                    {
                        case ConstantString.AddNewDealer:
                            await NavigationService.Navigate<AddNewDealerViewModel>();
                            break;
                        case ConstantString.ViewDealers:
                            await NavigationService.Navigate<ViewDelearViewModel>();
                            break;
                        case ConstantString.Policies:
                            await NavigationService.Navigate<ViewPoliciesViewModel>();
                            break;
                        case ConstantString.FieldDay:
                            await NavigationService.Navigate<FieldDayViewModel>();
                            break;
                        case ConstantString.FarmerMeeting:
                            await NavigationService.Navigate<FarmerMeetingViewModel>();
                            break;
                        case ConstantString.RateList:
                            await NavigationService.Navigate<RateListViewModel>();
                            break;
                        case ConstantString.Orders:
                            await NavigationService.Navigate<OrdersViewModel>();
                            break;
                        case ConstantString.RoutPlan:
                            await NavigationService.Navigate<RoutPlanViewModel>();
                            break;
                        case ConstantString.ApplyForLeave:
                            await NavigationService.Navigate<LeavePanelViewModel>();
                            break;
                        case ConstantString.Feedback:
                            await NavigationService.Navigate<FeedbackViewModel>();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
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

        #region Temp List
        private ERoles GetSelectedRole()
        {
            if (SelectedRole == string.Empty)
                SelectedRole = ERoles.FieldOfficer.ToString();
            Enum.TryParse(SelectedRole, out ERoles roles);
            return roles;
        }
        public List<string> Roles => Enum.GetNames(typeof(ERoles)).Select(b => b.SplitCamelCase()).ToList();

        private string selectedRole;
        public string SelectedRole
        {
            get => selectedRole;
            set
            {
                if (selectedRole == value)
                { }
                selectedRole = value;
                CreateMenuList();
                RaisePropertyChanged(() => SelectedRole);
            }
        }
        #endregion
    }
}
