using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Interfaces
{
    public interface answerInterface
    {

       public  Task<IEnumerable<Answer>> getAnswers();

       public  Task<Answer> getAnswer(int id); 

       public void addAnswer(Answer answer);

       public void removeAnswer(Answer answer);

        Task<bool> saveAnswerChangesAsync();
    }
}
