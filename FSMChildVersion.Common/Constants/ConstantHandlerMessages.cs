using System;
using System.Collections.Generic;
using System.Text;

namespace FSMChildVersion
{
    public class ConstantHandlerMessages
    {
        public const string IsLoggedIn = "IsLoggedIn";
        public const string AttandenceUpdateFailure = "Could not update attendance";
        public const string AttandenceUpdateSuccess = "Attendance update successfully";
        public const string AttandenceCheckInSuccess = "Check-in was successfully";
        public const string AttandenceCheckOutSuccess = "Check-out was successfully";
        public const string LoginFailure = "Login was unsuccessful";
        public const string GetCheckInFalg = "Could not get check in flag in settings";
        public const string AddCheckInFalg = "Could not save attendance related check in settings";
        public const string AddNewFarmerFailure = "Could not save farmer";
        public const string AddNewFarmerSuccess = "Farmer saved successfully";
        public const string AddNewFielddayFailure = "Could not add new field day";
        public const string AddNewFielddaySuccess = "Field day saved successfully";
    }
}
