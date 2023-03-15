namespace StackOverflowAPI.Response.Questions
{
    public class QuestionsSuccessResponse
    {
        public int statusCode { get; set; }

        public string message { get; set; }


        public QuestionsSuccessResponse(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
