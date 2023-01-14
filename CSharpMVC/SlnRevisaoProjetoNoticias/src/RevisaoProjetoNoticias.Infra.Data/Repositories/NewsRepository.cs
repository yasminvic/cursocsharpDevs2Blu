using RevisaoProjetoNoticias.Domain.Entities;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Infra.Data.Repositories
{
    //utilizando base repository só passando o tipo T
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        //ele já faz tudo oq o base faz, só faltava implementar o context pra ele saber onde fazer as alterações
        private readonly SQLServerContext _context;

        public NewsRepository(SQLServerContext context)
            : base(context)
        {

        }
    }
}
