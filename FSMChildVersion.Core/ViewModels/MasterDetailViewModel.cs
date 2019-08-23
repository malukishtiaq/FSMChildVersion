using System;
using System.Collections.Generic;
using System.Text;
using FSMChildVersion.Core.Model.Settings;
using MediatR;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels
{
    public class MasterDetailViewModel : BaseViewModel
    {
        private readonly IMediator mediator;

        public MasterDetailViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            await NavigationService.Navigate<MenuViewModel>();

            if (IsAttendanceUpdated())
            {
                await NavigationService.Navigate<AttendanceViewModel>();
            }
            else
            {
                await NavigationService.Navigate<FarmerVisitViewModel>();
            }
        }

        private bool IsAttendanceUpdated()
        {
            var getSettingsRequest = GetSettingsRequest.CreateSettingRequest(ConstantFlags.LoginFlag, true.ToString());
            GetSettingsResponse getSettingsResponse = mediator.Send(getSettingsRequest).Result;
            return getSettingsResponse == null ? false : getSettingsResponse.Success;
        }
    }
}
