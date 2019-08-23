namespace FSMChildVersion.Core.Model.Farmer
{
    public class AddFieldDayResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddFieldDayResponse(bool success)
        {
            Success = success;
        }

        private AddFieldDayResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddFieldDayResponse WithStatus(bool success)
        {
            return new AddFieldDayResponse(success);
        }

        public static AddFieldDayResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddFieldDayResponse(success, message);
        }
    }
}
