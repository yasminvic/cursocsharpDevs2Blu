using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.ProjetosAula.MVCSQL.Web.Models.Entities
{
    [Table("filmes")] //essa é uma tabela
    public class Filme
    {
        [Column("id")]
        [Display(Name = "Código")] //é tipo o select id from filme AS Código
        public int Id { get; set; }

        [Column("title")]
        [Display(Name = "Título")]
        public string Title { get; set; }
    }
}
