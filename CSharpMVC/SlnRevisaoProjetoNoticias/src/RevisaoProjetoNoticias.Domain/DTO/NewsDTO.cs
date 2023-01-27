using RevisaoProjetoNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Domain.DTO
{
    public class NewsDTO //DTO serve pra trazer algumas informações, não todas do BD
    {
        public int id { get; set; }
        [Display(Name = "Título")]
        public string title { get; set; }
        [Display(Name = "Descrição")]
        public string description { get; set; }
        [Display(Name = "Categoria")]
        public int categoryId { get; set; }

        [Display(Name = "Data de criação")]
        public DateTime? createdOn { get; set; }

        [Display(Name = "Publicado")]
        public bool published { get; set; }
        public virtual CategoryDTO? category { get; set; }

        public News mapToEntity()
        {
            return new News
            {
                Id = id,
                Title = title,
                Description = description,
                CategoryId = categoryId,
                CreatedOn = createdOn,
                Published = published

            };
        }

        public NewsDTO mapToDTO(News news)
        {
            return new NewsDTO
            {
                id = news.Id,
                title = news.Title,
                description = news.Description,
                categoryId = news.CategoryId,
                createdOn = news.CreatedOn,
                published = news.Published,
                category = new CategoryDTO
                {
                    id = news.Category.Id,
                    name = news.Category.Name
                }
            };
        }
    }
}
