using FSMChildVersion.Common.Model.Farmer;
using MediatR;

namespace FSMChildVersion.Core.Model.Farmer
{
    public class AddFarmerMeetingRequest : IRequest<AddFarmerMeetingResponse>
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string NoOfParticipent { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public static AddFieldDayRequest CreateAddNewFarmerRequest(string mobileNo, string famerName, string area, string noOfParticipent, string image)
        {
            return new AddFieldDayRequest(mobileNo, famerName, area, noOfParticipent, image);
        }
        public AddFarmerMeetingRequest()
        {

        }
        public AddFarmerMeetingRequest(string mobileNo, string famerName, string area, string noOfParticipent, string image)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Area = area;
            NoOfParticipent = noOfParticipent;
            Image = image;
        }
    }
}
