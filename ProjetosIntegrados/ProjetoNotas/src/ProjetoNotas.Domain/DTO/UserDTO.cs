using ProjetoNotas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public virtual ICollection<NoteDTO>? notes { get; set; }

        public User mapToEntity()
        {
            return new User()
            {
                Id = id,
                Name = name,
                Login = login,
                Password = password
            };
        }

        public UserDTO mapToDTO(User user)
        {
            return new UserDTO()
            {
                id = user.Id,
                name = user.Name,
                login = user.Login,
                password = user.Password
            };
        }
    }
}
