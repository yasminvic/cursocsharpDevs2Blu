﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models
{
    public class Endereco
    {
        public Int32 Id { get; set; }
        public String CEP { get; set; }
        public String Rua { get; set; }
        public Int32 Numero { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }

        public Endereco()
        {
        }

        public Endereco(string cEP, string rua, int numero, string bairro, string cidade, string uF)
        {
            CEP = cEP;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }
    }
}
