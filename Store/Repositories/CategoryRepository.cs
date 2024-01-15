using Entities.Models;
using Repositories.Contracts;
using Store.Repositories;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {

        }

    }
}
