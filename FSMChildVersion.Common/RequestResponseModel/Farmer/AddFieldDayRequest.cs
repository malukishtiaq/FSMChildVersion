using MediatR;

namespace FSMChildVersion.Common.RequestResponseModel.Farmer
{
    public class AddFieldDayRequest : IRequest<AddFieldDayResponse>
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Crop { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public static AddFieldDayRequest CreateAddNewFarmerRequest(string mobileNo, string famerName, string crop, string product, string image)
        {
            return new AddFieldDayRequest(mobileNo, famerName, crop, product, image);
        }
        public AddFieldDayRequest()
        {

        }
        public AddFieldDayRequest(string mobileNo, string famerName, string crop, string product, string image)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Crop = crop;
            Product = product;
            Image = image;
        }
    }
}
