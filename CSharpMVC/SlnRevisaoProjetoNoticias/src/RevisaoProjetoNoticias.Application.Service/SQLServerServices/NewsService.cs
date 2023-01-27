using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.Entities;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProjetoNoticias.Application.Service.SQLServerServices
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<NewsDTO> FindAll()
        {
            //findall vai trazer uma lista com objetos News
            //esse select está pegando cada um através do n, e criando um NewsDTO pra cada News
            //pegando as propriedades do NewsDTO e preenchendo com News
            //e convertendo em Lista
            return _repository.FindAll().Select(n => new NewsDTO()
            {
                id = n.Id,
                title = n.Title,
                description = n.Description,
                categoryId = n.CategoryId,
                createdOn = n.CreatedOn,
                published = n.Published
            }).ToList();
        }

        public async Task<NewsDTO> FindById(int id)
        {
            News news = await _repository.FindById(id);
            return new NewsDTO
            {
                id = news.Id,
                title = news.Title,
                description = news.Description,
                published = news.Published,
                categoryId = news.CategoryId,
                createdOn = news.CreatedOn
            };
        }

        public Task<int> Save(NewsDTO entity)
        {
            if(entity.id > 0)
            {
                return _repository.Update(entity.mapToEntity());
            }
            else
            {
                return _repository.Save(entity.mapToEntity());
            }
            
        }
    }
}
