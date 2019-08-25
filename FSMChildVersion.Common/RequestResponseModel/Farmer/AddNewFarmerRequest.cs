using MediatR;

namespace FSMChildVersion.Common.RequestResponseModel.Farmer
{
    public class AddNewFarmerRequest : IRequest<AddNewFarmerResponse>
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Acre { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;

        public static AddNewFarmerRequest CreateAddNewFarmerRequest(string mobileNo, string famerName, string acre, string area)
        {
            return new AddNewFarmerRequest(mobileNo, famerName, acre, area);
        }
        public AddNewFarmerRequest()
        {

        }
        public AddNewFarmerRequest(string mobileNo, string famerName, string acre, string area)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Acre = acre;
            Area = area;
        }
    }
}
