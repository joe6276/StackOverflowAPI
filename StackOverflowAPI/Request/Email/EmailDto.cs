namespace StackOverflowAPI.Request.Email
{
    public class EmailDto
    {

        public string  To { get; set; }

        public string Body { get; set; }


        public string Subject { get; set; }


        public EmailDto(string to , string  body, string subject)
        {
            To= to;
            Body= body;
            Subject= subject;
        }

    }
}
