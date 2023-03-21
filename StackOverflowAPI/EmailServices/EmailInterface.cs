using StackOverflowAPI.Request.Email;

namespace StackOverflowAPI.EmailServices
{
    public interface EmailInterface
    {
        void sendEmail(EmailDto dto);
    }
}
