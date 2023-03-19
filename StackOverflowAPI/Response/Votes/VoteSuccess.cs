namespace StackOverflowAPI.Response.Votes
{
    public class VoteSuccess
    {

        public int statusCode { get; set; }

        public string message { get; set; }

        public VoteSuccess(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
