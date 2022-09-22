using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums
{
    public enum MenuEnum
    {
        // menu Cadastro
        SAIR = 0,
        LISTAR = 1,
        CADASTRO = 2,
        ALTERAR = 3,
        EXCLUIR = 4,

        //menu principal
        CD_PACIENTE = 10,
        CD_MEDICO = 20,
        CD_RECEPCIONISTA = 30,
        CD_FORNCEDOR = 40,
        AGENDA = 50,
        PRONTUARIO = 60,
        FINANCEIRO = 70,

        //validação
        SIM = 100,
        NAO = 200
    }
}
