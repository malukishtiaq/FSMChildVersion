using System.Collections.Generic;
using MediatR;

namespace FSMChildVersion.Common.RequestResponseModel.Farmer
{
    public class GetAllFarmersRequest : IRequest<List<GetAllFarmersResponse>>
    {

    }
    public class GetAllFarmersResponse
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string NoOfParticipent { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public static GetAllFarmersResponse CreateAddNewFarmerRequest(string mobileNo, string famerName, string area, string noOfParticipent, string image)
        {
            return new GetAllFarmersResponse(mobileNo, famerName, area, noOfParticipent, image);
        }
        public GetAllFarmersResponse()
        {

        }
        public GetAllFarmersResponse(string mobileNo, string famerName, string area, string noOfParticipent, string image)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Area = area;
            NoOfParticipent = noOfParticipent;
            Image = image;
        }
        public string Message { get; set; }
        public bool Success { get; set; }
        private GetAllFarmersResponse(bool success)
        {
            Success = success;
        }

        private GetAllFarmersResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static GetAllFarmersResponse WithStatus(bool success)
        {
            return new GetAllFarmersResponse(success);
        }

        public static GetAllFarmersResponse WithStatusAndMessage(bool success, string message)
        {
            return new GetAllFarmersResponse(success, message);
        }
    }
}
