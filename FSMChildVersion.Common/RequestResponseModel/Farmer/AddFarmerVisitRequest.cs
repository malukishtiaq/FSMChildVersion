using MediatR;

namespace FSMChildVersion.Common.RequestResponseModel.Farmer
{
    public class AddFarmerVisitRequest : IRequest<AddFarmerVisitResponse>
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Crop { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public static AddFarmerVisitRequest CreateAddFarmerVisitRequest(string mobileNo, string famerName, string crop, string location, string image)
        {
            return new AddFarmerVisitRequest(mobileNo, famerName, crop, location, image);
        }
        public AddFarmerVisitRequest()
        {

        }
        public AddFarmerVisitRequest(string mobileNo, string famerName, string crop, string location, string image)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Crop = crop;
            Location = location;
            Image = image;
        }
    }
}
