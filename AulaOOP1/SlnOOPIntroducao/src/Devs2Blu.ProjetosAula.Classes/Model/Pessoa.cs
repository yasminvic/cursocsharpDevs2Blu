using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Classes.Model
{
    public abstract class Pessoa
    {
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public String DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
    }
}
