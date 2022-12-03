namespace ITS.WebApi.Helper.Implement
{
    public class Error
    {
        public Error(string message, object errorMessages = null)
        {
            Message = message;
            ErrorMessages = errorMessages;
        }
        public string Message { get; }

        public object ErrorMessages { get; set; }
    }
}