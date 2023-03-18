namespace StackOverflowAPI.Response.Comments
{
    public class CommentResponse
    {

        public int statusCode { get; set; } 

        public string message { get; set; }

        public CommentResponse(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
