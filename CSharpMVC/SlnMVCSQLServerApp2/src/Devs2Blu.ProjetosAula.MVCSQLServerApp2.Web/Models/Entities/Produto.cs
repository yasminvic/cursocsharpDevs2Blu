using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities
{
    [Table("produtos")]
    public class Produto
    {
        [Column("id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name = "Name")]
        public string Nome { get; set; }

        [Column("preco")]
        [Display(Name = "Preço")]
        public Decimal Preco { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        //mapeia de outro jeito pq é um relacionamento
        [Column("id_categoria")]
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
    }
}
