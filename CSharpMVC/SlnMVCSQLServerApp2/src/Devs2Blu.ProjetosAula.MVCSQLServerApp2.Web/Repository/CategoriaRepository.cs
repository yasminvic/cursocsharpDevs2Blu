using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Repository
{
    public class CategoriaRepository
    {
        //injetar o contexto aqui

        //objeto da classe contexto
        private readonly ContextoDatabase _context;
        public CategoriaRepository(ContextoDatabase context)
        {
            _context = context;
        }

        //pega todos os registros, retorna do banco de dados
        public async Task<IEnumerable<Categoria>> GetAll()
        {
            //retornar uma lista de categorias instaciandas na classe contexto
            return await _context.Categoria.ToListAsync();
        }

        public async Task<int> SaveCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            //retorna qualquer mudança no banco
            return await _context.SaveChangesAsync();
        }
    }
}


//passo a passo:
/*
 View solicita algo para Controller atraves de um form (nem sempre)
 Controller vai solicitar ao Service
 Service vai solicitar ao Repository
 Repository vai salvar no contexto (banco de dados)
 */