using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.LivrosProjetoMVC.Models
{
    [Table("produtos")]
    public class Livros
    {
        
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("titulo")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Column("editora")]
        [Display(Name = "Editora")]
        public string Editora { get; set; }

        [Column("autor")]
        [Display(Name = "Autor (a)")]
        public string Autor { get; set; }
    }
}
