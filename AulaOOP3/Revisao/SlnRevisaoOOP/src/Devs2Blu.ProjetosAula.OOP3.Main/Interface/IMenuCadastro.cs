<<<<<<< HEAD
﻿using System;
=======
﻿using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
>>>>>>> 3272320514e59a70c1273e00a87c1067a7192dfb
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Interface
{

   public interface IMenuCadastro

    {
        //metodos obrigatórios, que nao importa como tem que ser implementado
        //tudo que estiver na interface tem que estar na classe

        Int32 MenuCadastro();
        void Listar();
        void Cadastrar();
        void Alterar();
        void Excluir();
    }
}
