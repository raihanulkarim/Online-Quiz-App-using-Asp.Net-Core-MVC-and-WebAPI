using OnlineQuizApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineQuizApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> GetCategory(int id);
        Task<Categories> AddCategory(Categories category);
        Task<Categories> UpdateCategory(Categories category);
        Task DeleteCategory(int id);
    }
}
