using RevisaoProjetoNoticias.Domain.Entities;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Infra.Data.Context;

namespace RevisaoProjetoNoticias.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {                                 //herdando do base        //implementando esse
        private readonly SQLServerContext _context;
        public CategoryRepository(SQLServerContext context)
            :base(context)
        {

        }
    }
}
