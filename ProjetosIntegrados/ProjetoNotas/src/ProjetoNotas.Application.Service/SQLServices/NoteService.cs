using ProjetoNotas.Domain.DTO;
using ProjetoNotas.Domain.Interfaces.IRepository;
using ProjetoNotas.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Application.Service.SQLServices
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public async Task<List<NoteDTO>> FindAll()
        {
            List<NoteDTO> listadto = new List<NoteDTO>();
            foreach (var entity in await _repository.FindAll())
            {
                var entitydto = new NoteDTO();
                listadto.Add(entitydto.mapToDTO(entity));
            }

            return listadto;
        }

        public async Task<NoteDTO> FindById(int id)
        {
            var Notedto = new NoteDTO();
            return Notedto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(NoteDTO entity)
        {
            if (entity.id > 0)
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
