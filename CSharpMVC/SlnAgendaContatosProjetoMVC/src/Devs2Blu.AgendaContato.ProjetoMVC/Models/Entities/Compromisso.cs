namespace Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime HoraInicio { get; set; }
        public Endereco Endereco { get; set; }

        public Contato? Contato { get; set; }
    }
}
