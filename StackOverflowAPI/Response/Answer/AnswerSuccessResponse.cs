namespace StackOverflowAPI.Response.Answer
{
    public class AnswerSuccessResponse
    {
        public int statusCode { get; set; }

        public string message { get; set; }

        public AnswerSuccessResponse(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
