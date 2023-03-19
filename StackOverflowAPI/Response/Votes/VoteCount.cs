namespace StackOverflowAPI.Response.Votes
{
    public class VoteCount
    {
        public int statusCode { get; set; }

        public int totalVotes { get; set; }


        public VoteCount(int statusCode, int totalVotes)
        {
            this.statusCode = statusCode;
            this.totalVotes = totalVotes;
        }
    }
}
