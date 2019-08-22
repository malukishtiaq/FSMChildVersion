using System.Collections.Generic;
using FSMChildVersion.Common.Enums;

namespace FSMChildVersion.Common.Constants
{
    public static class ConstantString
    {
        #region Menu List
        private static readonly List<string> MenuItemListForFieldOfficer = new List<string>()
        {
            AddNewFarmer, ViewFarmer, FieldDay, FarmerMeeting, StockReport, Orders, RoutPlan, ApplyForLeave, Feedback
        };

        private static readonly List<string> MenuItemListForAreaManager = new List<string>()
        {
            AddNewDealer, ViewDealers, Policies, FieldDay, FarmerMeeting, RateList, Orders, RoutPlan, ApplyForLeave, Feedback
        };

        private static readonly List<string> MenuItemListForZSM_RSM = new List<string>()
        {
            AddNewDealer, ViewDealers, Policies, FieldDay, FarmerMeeting, RateList, Orders, RoutPlan, ApplyForLeave, Feedback
        };

        #region Field Officer Specific
        public const string AddNewFarmer = "Add New Farmer";
        public const string StockReport = "Stock Report";
        public const string ViewFarmer = "View Farmer";
        #endregion

        #region Area Manager Specific

        #endregion

        #region ZSM_RSM Specific

        #endregion

        #region Field Officer and Area Manager Specific

        #endregion

        #region Area Manager and ZSM_RSM Specific
        public const string AddNewDealer = "Add New Dealer";
        public const string ViewDealers = "View Dealers";
        public const string Policies = "Policies";
        #endregion

        #region Field Officer  and ZSM_RSM Specific

        #endregion

        #region Field Officer, Area Manager and ZSM_RSM Specific
        public const string FieldDay = "Field Day";
        public const string FarmerMeeting = "Farmer Meeting";
        public const string Orders = "Orders";
        public const string RoutPlan = "Rout Plan";
        public const string ApplyForLeave = "Apply For Leave";
        public const string Feedback = "Feedback";
        public const string RateList = "Rate List";
        #endregion

        public static List<string> GetMenuItemList(ERoles role)
        {
            switch (role)
            {
                case ERoles.AreaManager:
                    return MenuItemListForAreaManager;
                case ERoles.FieldOfficer:
                    return MenuItemListForFieldOfficer;
                case ERoles.ZSM_RSM:
                    return MenuItemListForZSM_RSM;
                default:
                    return MenuItemListForFieldOfficer;
            }
        } 
        #endregion
    }
}
