using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace FSMChildVersion.Common.Model.Feedback
{
    public class AddFeedbackRequest : IRequest<AddFeedbackResponse>
    {
        public string MobileNo { get; set; } = string.Empty;
        public string FarmerName { get; set; } = string.Empty;
        public string Crop { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public static AddFeedbackRequest CreateAddNewFarmerRequest(string mobileNo, string famerName, string crop, string product, string image)
        {
            return new AddFeedbackRequest(mobileNo, famerName, crop, product, image);
        }
        public AddFeedbackRequest()
        {

        }
        public AddFeedbackRequest(string mobileNo, string famerName, string crop, string product, string image)
        {
            MobileNo = mobileNo;
            FarmerName = famerName;
            Crop = crop;
            Product = product;
            Image = image;
        }
    }
}
