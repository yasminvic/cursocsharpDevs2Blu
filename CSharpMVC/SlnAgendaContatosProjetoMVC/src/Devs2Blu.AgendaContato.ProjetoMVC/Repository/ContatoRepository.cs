using Devs2Blu.AgendaContato.ProjetoMVC.Models;
using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Repository
{
    public class ContatoRepository
    {
        private readonly ContextoDatabase _contexto;

        public ContatoRepository(ContextoDatabase contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Contato>> Listar()
        {
            return await _contexto.Contato.ToListAsync();
        }

        public async Task<int> DeleteContato(Contato contato)
        {
            _contexto.Contato.Remove(contato);
            return await _contexto.SaveChangesAsync();
        }

        internal async Task<Contato> FindByIdContato(int id)
        {
            return await _contexto.Contato.FindAsync(id);
        }

        internal async Task<int> SaveContato(Contato contato)
        {
            _contexto.Add(contato);
            return await _contexto.SaveChangesAsync();
        }
    }
}
