using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels
{
    public class MasterDetailViewModel : BaseViewModel
    {
        public MasterDetailViewModel()
        {
        }
        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            await NavigationService.Navigate<MenuViewModel>();
            await NavigationService.Navigate<FarmerVisitViewModel>();
        }
    }
}
