using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities
{
    //são propertys
    [Table("categorias")]//nome da tabela
    public class Categoria
    {
        [Column("id")]//nome da coluna
        [Display(Name = "Código")]// é o nome que apresentamos ao usuário, tipo aquele AS
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        //podemos procurar uma catogoria dentro do produto
        //ou produtos dentro de uma categoria
        //é isso que esse prop ta fazendo, procurando produtos dentro de uma categoria
        public ICollection<Produto> Produtos { get; set; }
    }
}
