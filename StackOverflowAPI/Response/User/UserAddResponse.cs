namespace StackOverflowAPI.Response.User
{
    public class UserAddResponse
    {

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public UserAddResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
