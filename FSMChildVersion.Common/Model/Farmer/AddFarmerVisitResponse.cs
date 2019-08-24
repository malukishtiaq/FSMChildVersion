namespace FSMChildVersion.Common.Model.Farmer
{
    public class AddFarmerVisitResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddFarmerVisitResponse(bool success)
        {
            Success = success;
        }

        private AddFarmerVisitResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddFarmerVisitResponse WithStatus(bool success)
        {
            return new AddFarmerVisitResponse(success);
        }

        public static AddFarmerVisitResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddFarmerVisitResponse(success, message);
        }
    }
}
