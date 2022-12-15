using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Service.Interfaces
{
    public interface ICategoriasService
    {
        //retorna uma lista
        //sempre que tiver uma classe que implemente categoria vai ter que implementar esse metodo
        Task<IEnumerable<Categoria>> GetAllCategorias();

        //salva categorias no banco
        //retorna quantidade de registros alterados
        Task<int> Save(Categoria categoria);
    }
}
