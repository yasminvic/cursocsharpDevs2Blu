using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Models.DTO
{
    public class ContatoViewModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        public Contato ToEntity()
        {
            return new Contato()
            {
                Id = id,
                Nome = nome,
                Telefone = telefone,
                Email = email
            };
        }
    }
}
