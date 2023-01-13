using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities
{
    [Table("compromissos")]
    public class Compromisso
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("titulo")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //[Column("data")]
        //[Display(Name = "Data")]
        //public DateTime Data { get; set; }

        [Column("ContatoId")]
        [Display(Name = "Contato")]
        public int ContatoId { get; set; }
        
        public virtual Contato? Contato { get; set; }

        //ENDEREÇO
        [Column("cep")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Column("rua")]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Column("bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Column("num")]
        [Display(Name = "Número")]
        public string Num { get; set; }

        [Column("cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("uf")]
        [Display(Name = "UF")]
        public string UF { get; set; }
    }
}
