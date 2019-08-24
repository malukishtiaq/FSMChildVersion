using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FSMChildVersion.Common.Model.Attendance;
using MediatR;
using MvvmCross.Commands;

namespace FSMChildVersion.Core.ViewModels
{
    public class AttendanceViewModel : BaseViewModel
    {
        private readonly IMediator mediator;
        private bool isCheckInEnabled;

        public AttendanceViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override void Prepare()
        {            
            WhichAttendanceButtonEnabled();
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        private async Task CheckInAsync()
        {
            var request = AddAttendanceRequest.CreateAttendanceRequest(1, ConstantFlags.CheckIn, DateTime.UtcNow, "");
            await SaveCheckInCheckOutAsync(request);
            IsCheckInEnabled = false;
            return;
        }
        private async Task CheckOutAsync()
        {
            var request = AddAttendanceRequest.CreateAttendanceRequest(1, ConstantFlags.CheckOut, System.DateTime.UtcNow, "");
            await SaveCheckInCheckOutAsync(request);
            IsCheckInEnabled = true;
            return;
        }

        private async Task SaveCheckInCheckOutAsync(AddAttendanceRequest request)
        {
            try
            {
                AddAttendanceResponse result = await mediator.Send(request).ConfigureAwait(false);
                IsResponseVisible = true;
                ResponseMessage = result.Success ? result.Message : result.Message;
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }
        #region Commands
        public ICommand CheckOutCommand => new MvxCommand(async () => await RunSafeAsync(CheckOutAsync()));
        public ICommand CheckInCommand => new MvxCommand(async () => await RunSafeAsync(CheckInAsync()));
        #endregion

        #region Public Properties
        public bool IsCheckInEnabled { get => isCheckInEnabled; set => SetProperty(ref isCheckInEnabled, value); }
        #endregion

        /// <summary>
        /// This method checks what is the last attendance status of logged in user.
        /// if his last status is CheckIn, than disable Check-In button.
        /// else if last status is CheckOut, than disable Check-Out button.
        /// else if status is not logged, than enable Check-In button. (it means he hasn't checked-in yet.)
        /// </summary>
        /// <returns>IsCheckInEnabled is responsible for enabling and disabling either button</returns>
        private bool WhichAttendanceButtonEnabled()
        {
            var loggedInUserID = 1;
            var getSettingsRequest = GetAttendanceRequest.CreateAttendanceRequest(loggedInUserID);
            GetAttendanceResponse response = mediator.Send(getSettingsRequest).Result;
            if (response != null && response.Success)
            {
                IsCheckInEnabled = response.Message switch
                {
                    ConstantFlags.CheckIn => false,
                    ConstantFlags.CheckOut => true,
                    _ => false,
                };
            }
            return response == null ? false : response.Success;
        }
    }
}
