namespace StackOverflowAPI.Response.User
{
    public class UserUpdateResponse
    {

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public UserUpdateResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
