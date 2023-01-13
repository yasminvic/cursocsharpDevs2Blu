using Devs2Blu.AgendaContato.ProjetoMVC.Models;
using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Repository
{
    public class CompromissoRepository
    {
        private readonly ContextoDatabase _context;

        public CompromissoRepository(ContextoDatabase context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Compromisso>> Listar()
        {
            return await _context.Compromisso.ToListAsync();
        }

        public async Task<int> SaveCompromisso(Compromisso compromisso)
        {
            _context.Add(compromisso);
            return await _context.SaveChangesAsync();
        }
    }
}
