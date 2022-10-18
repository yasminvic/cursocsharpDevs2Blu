using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models
{
    public class Compromisso
    {
        public Int32 Id { get; set; }
        public Contato Contato { get; set; }
        public Endereco Endereco { get; set; }
        public String Titulo { get; set; }
        public String Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public FlStatusCompromisso Status { get; set; }

        public Compromisso()
        {
            Contato = new Contato();
            Endereco = new Endereco();
            Status = FlStatusCompromisso.A;
        }

        public Compromisso(Contato contato, string titulo, string descricao, DateTime dataInicio, DateTime dataFim)
        {
            Contato = contato;
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}
