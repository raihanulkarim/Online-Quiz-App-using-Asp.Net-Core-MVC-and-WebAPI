using Microsoft.EntityFrameworkCore;
using OnlineQuizApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineQuizApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Categories> AddCategory(Categories category)
        {
            var cat = await context.Categories.AddAsync(category); 
            await context.SaveChangesAsync();
            return cat.Entity;
        }

        public async Task DeleteCategory(int id)
        {
            var cat = await context.Categories.FirstOrDefaultAsync( r=> r.CategoryId == id);
            if (cat != null)
            {
                context.Categories.Remove(cat);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Categories> GetCategory(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(r=> r.CategoryId == id);
        }

        public async Task<Categories> UpdateCategory(Categories category)
        {
            var cat = await context.Categories.FirstOrDefaultAsync(r=> r.CategoryId == category.CategoryId);
            if (cat != null)
            {
                cat.Title = category.Title;
                await context.SaveChangesAsync();
                return cat;
            }
            return null;
        }
    }
}
