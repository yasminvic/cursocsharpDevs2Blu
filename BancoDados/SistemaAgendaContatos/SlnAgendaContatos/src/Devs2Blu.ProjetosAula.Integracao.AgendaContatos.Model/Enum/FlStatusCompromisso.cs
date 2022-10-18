using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum
{
    public enum FlStatusCompromisso
    { 
        [Description("Aberto")]
        A = 0, 

        [Description("Concluído")]
        C = 1, 

        [Description("Remarcado")]
        R = 2, 

        [Description("Inativo")]
        I = 3 
    }
}
