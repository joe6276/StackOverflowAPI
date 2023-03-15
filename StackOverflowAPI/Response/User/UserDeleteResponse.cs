namespace StackOverflowAPI.Response.User
{
    public class UserDeleteResponse
    {

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public UserDeleteResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
