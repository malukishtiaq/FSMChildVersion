using MediatR;

namespace FSMChildVersion.Core.Model.Farmer
{
    public class AddFarmerVisitRequest : IRequest<AddFarmerVisitResponse>
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Crop { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public static AddNewFarmerRequest CreateAddNewFarmerRequest(string mobileNo, string famerName, string crop, string location)
        {
            return new AddNewFarmerRequest(mobileNo, famerName, crop, location);
        }
        public AddFarmerVisitRequest()
        {

        }
        public AddFarmerVisitRequest(string mobileNo, string famerName, string crop, string location)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Crop = crop;
            Location = location;
        }
    }
}
