using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return await _appDbContext.Categories
                .Include(s => s.Products)
                .Where(s => s.Id == categoryId)
                .SingleOrDefaultAsync();
        }

       
    }
}
