using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Devs2Blu.AgendaContato.ProjetoMVC.Repository;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Service.Implements
{
    public class CompromissoService : ICompromissoService
    {
        private readonly CompromissoRepository _repository;

        public CompromissoService(CompromissoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Compromisso>> ListarCompromissos()
        {
            return await _repository.Listar();
        }

        public async Task<int> Save(Compromisso compromisso)
        {
            return await _repository.SaveCompromisso(compromisso);
        }
    }
}
