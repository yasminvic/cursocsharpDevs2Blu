using System;
﻿using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Interface
{

   public interface IMenuCadastro

    {
        //metodos obrigatórios
        //tudo que estiver na interface tem que estar na classe

        Int32 MenuCadastro();
        void Listar();
        void Cadastrar();
        void Alterar();
        void Excluir();
    }
}
