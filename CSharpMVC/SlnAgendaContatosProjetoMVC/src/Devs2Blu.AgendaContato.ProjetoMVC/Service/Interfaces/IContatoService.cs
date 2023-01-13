using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces
{
    public interface IContatoService
    {
        Task<int> Delete(Contato contato);
        Task<Contato> FindById(int id);
        Task<IEnumerable<Contato>> ListarContatos();
        Task<int> Save(Contato contato);
    }
}
