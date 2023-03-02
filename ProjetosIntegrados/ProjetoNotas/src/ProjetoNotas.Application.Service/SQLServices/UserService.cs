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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public async Task<List<UserDTO>> FindAll()
        {
            List<UserDTO> listadto = new List<UserDTO>();
            foreach (var entity in await _repository.FindAll())
            {
                var entitydto = new UserDTO();
                listadto.Add(entitydto.mapToDTO(entity));
            }

            return listadto;
        }

        public async Task<UserDTO> FindById(int id)
        {
            var userdto = new UserDTO();
            return userdto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(UserDTO entity)
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
