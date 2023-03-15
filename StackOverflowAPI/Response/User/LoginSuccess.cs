namespace StackOverflowAPI.Response.User
{
    public class LoginSuccess
    {
        public string message { get; set; }

        public string token { get; set; }

        public int statusCode { get; set; }

        public LoginSuccess(string message, string token, int statusCode)
        {
            this.message = message;
            this.token = token;
            this.statusCode = statusCode;
        }
    }
}
