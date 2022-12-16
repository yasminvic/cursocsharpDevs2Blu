using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities
{
    [Table("contatos")]
    public class Contato
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public ICollection<Compromisso>? Compromissos { get; set; }
    }
}
