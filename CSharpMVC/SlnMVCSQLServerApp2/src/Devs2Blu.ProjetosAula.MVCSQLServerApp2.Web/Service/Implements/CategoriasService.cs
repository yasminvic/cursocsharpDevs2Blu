using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Repository;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Service.Interfaces;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Service.Implements
{
                                      //interface
    public class CategoriasService : ICategoriasService
    {
        private readonly CategoriaRepository _repository;

        public CategoriasService(CategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategorias()
        {
            //retorna uma lista
            return await _repository.GetAll();
        }

        //salvar categorias
        //retorna quantidade de registros alterados
        public async Task<int> Save(Categoria categoria)
        {
            return await _repository.SaveCategoria(categoria);
        }
    }
}
