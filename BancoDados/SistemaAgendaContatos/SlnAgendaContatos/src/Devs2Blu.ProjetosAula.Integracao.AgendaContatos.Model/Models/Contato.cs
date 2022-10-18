using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model
{
    public class Contato
    {
        public Int32 Id { get; set; }
        public Endereco Endereco { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public FlStatus Status { get; set; }

        public Contato()
        {
            Endereco = new Endereco();
            Status = FlStatus.A;
        }
        public Contato(Endereco endereco, string name, string email, string telefone)
        {
            Endereco = endereco;
            Name = name;
            Email = email;
            Telefone = telefone;
        }
    }
}
