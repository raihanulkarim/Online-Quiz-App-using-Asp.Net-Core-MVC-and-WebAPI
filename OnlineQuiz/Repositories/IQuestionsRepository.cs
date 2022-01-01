using OnlineQuizApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineQuizApi.Repositories
{
    public interface IQuestionsRepository
    {
        Task<IEnumerable<Questions>> GetQuestions();
        Task<IEnumerable<Questions>> GetQuestionsByCat(int catId);
        //Task<IEnumerable<Questions>> Search();
        Task<Questions> GetQuestion(int id);
        Task<Questions> AddQuestion(Questions question);
        Task<Questions> UpdateQuestion(Questions question);
        Task DeleteQuestion(int id);
    }
}
