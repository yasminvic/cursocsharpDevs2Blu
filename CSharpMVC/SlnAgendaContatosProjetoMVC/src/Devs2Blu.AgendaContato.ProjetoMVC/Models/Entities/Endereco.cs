namespace Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Num { get; set; }
        public string Cidade { get; set; }
        public UF UF { get; set; }
    }
}