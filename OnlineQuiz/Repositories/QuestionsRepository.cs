using Microsoft.EntityFrameworkCore;
using OnlineQuizApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuizApi.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly ApplicationDbContext context;

        public QuestionsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Questions> AddQuestion(Questions question)
        {
            var res = await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteQuestion(int id)
        {
            var ques = await context.Questions.FirstOrDefaultAsync(r=> r.Id == id);
            if(ques != null)
            {
                context.Questions.Remove(ques);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Questions> GetQuestion(int id)
        {
            return await context.Questions.Include(r=> r.category).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Questions>> GetQuestions()
        {
            return await context.Questions.Include(r=> r.category).ToListAsync();
        }

        public async Task<IEnumerable<Questions>> GetQuestionsByCat(int catId)
        {
            return await context.Questions.Include(r=> r.category).Where(r => r.CategoryId == catId).ToListAsync();
        }

        public async Task<Questions> UpdateQuestion(Questions question)
        {
            var ques = await context.Questions.FirstOrDefaultAsync(r=> r.Id == question.Id);
            if (ques != null)
            {
                ques.Question = question.Question;
                ques.Option1 = question.Option1;
                ques.Option2 = question.Option2;
                ques.Option3 = question.Option3;
                ques.Option4 = question.Option4;
                ques.CorrAns = question.CorrAns;
                ques.CategoryId = question.CategoryId;
                await context.SaveChangesAsync();
                return ques;
            }
            return null;
        }
    }
}
