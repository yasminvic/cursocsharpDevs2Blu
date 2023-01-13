using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces
{
    public interface ICompromissoService
    {
        Task<IEnumerable<Compromisso>> ListarCompromissos();
        Task<int> Save(Compromisso compromisso);
    }
}
