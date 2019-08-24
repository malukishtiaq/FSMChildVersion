namespace FSMChildVersion.Common.Model.Farmer
{
    public class AddNewFarmerResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddNewFarmerResponse(bool success)
        {
            Success = success;
        }

        private AddNewFarmerResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddNewFarmerResponse WithStatus(bool success)
        {
            return new AddNewFarmerResponse(success);
        }

        public static AddNewFarmerResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddNewFarmerResponse(success, message);
        }
    }
}
