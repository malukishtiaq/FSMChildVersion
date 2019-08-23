namespace FSMChildVersion.Core.Model.Feedback
{
    public class AddFeedbackResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private AddFeedbackResponse(bool success)
        {
            Success = success;
        }

        private AddFeedbackResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public static AddFeedbackResponse WithStatus(bool success)
        {
            return new AddFeedbackResponse(success);
        }

        public static AddFeedbackResponse WithStatusAndMessage(bool success, string message)
        {
            return new AddFeedbackResponse(success, message);
        }
    }
}

