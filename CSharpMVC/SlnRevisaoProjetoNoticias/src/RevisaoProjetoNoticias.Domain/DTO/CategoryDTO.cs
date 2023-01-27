using RevisaoProjetoNoticias.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace RevisaoProjetoNoticias.Domain.DTO
{
    public class CategoryDTO //DTO = objeto de transferencia de dados
    {
        //em minusculo pq é o padrao web
        public int id { get; set; }
        [Display(Name = "Categoria")]
        public string name { get; set; }
        public virtual ICollection<NewsDTO>? newsList { get; set; }

        //convertendo pra Category pra poder Ocultar propriedades específicas que os clientes não devem exibir.
        // e Omitir algumas propriedades para reduzir o tamanho da carga.
        public Category mapToEntity()
        {
            return new Category
            {
                //esse this faz referencia as propriedades da própria classe CategoryDTO
                Id = this.id,
                Name = this.name
            };
        }  
        
        public CategoryDTO mapToDTO(Category category)
        {
            return new CategoryDTO
            {
                id = category.Id,
                name = category.Name,
                //estamos fazendo com que cada objeto da lista vai ser convertido em NewsDTO
                //newsList = category.NewsList.Select(c => new NewsDTO()
                //{

                //}).ToList()
            };
        }
    }
}
