namespace StackOverflowAPI.Response.Auth
{
    public class AuthResponse
    {

        public int StatusCode { get; set; }

        public  string StatusMessage { get; set; } 


        public AuthResponse(int statusCode , string message)
        {
                StatusCode= statusCode;
                StatusMessage = message;
        }
    }
}
