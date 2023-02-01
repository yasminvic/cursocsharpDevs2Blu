using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Devs2Blu.AgendaContato.ProjetoMVC.Repository;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Service.Implements
{
    public class ContatoService : IContatoService
    {
        private readonly ContatoRepository _repository;

        public ContatoService(ContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(Contato contato)
        {
            return await _repository.DeleteContato(contato);
        }

        public async Task<Contato> FindById(int id)
        {
            return await _repository.FindByIdContato(id);
        }

        public async Task<IEnumerable<Contato>> ListarContatos()
        {
            return await _repository.Listar();
        }

        public async Task<int> Save(Contato contato)
        {
            return await _repository.SaveContato(contato);
        }
    }
}
