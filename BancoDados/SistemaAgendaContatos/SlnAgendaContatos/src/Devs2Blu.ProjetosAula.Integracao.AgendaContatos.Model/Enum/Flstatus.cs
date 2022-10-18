using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum
{

    public enum FlStatus
    {
        [Description("Excluído")]
        E = 0, //excluído

        [Description("Ativo")]
        A = 1, // ativo

        [Description("Inativo")]
        I = 2 // inativo
     }
   
}
