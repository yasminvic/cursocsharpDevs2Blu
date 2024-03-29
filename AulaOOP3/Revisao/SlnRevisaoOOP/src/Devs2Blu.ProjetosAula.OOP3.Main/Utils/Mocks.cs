﻿using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Utils
{
    public class Mocks // classe para testar as outras classes, gera vários objetos
    {
        public List<Paciente> ListaPacientes { get; set; }
        public  List<Medico> ListaMedicos { get; set; }
        public  List<Fornecedor> ListaFornecedor { get; set; }
        public  List<Recepcionista> ListaRecepcionistas { get; set; }
       
        public Mocks()
        {
            ListaPacientes = new List<Paciente>();
            ListaMedicos = new List<Medico>();
            ListaRecepcionistas = new List<Recepcionista>();
            ListaFornecedor = new List<Fornecedor>();

            CargaMock(); // chama todos os metodos que geram os objetos
        }
        public void CargaMock()
        {
            CargaPaciente();
            CargaMedico();
            CargaRecepcionista();
            CargaFornecedor();
        }

        public void CargaPaciente()
        {
            for (int i = 0; i < 10; i++)
            {
                Paciente paciente = new Paciente(i, $"Paciente {i}", $"{i}23{i}56{i}7891{i}", "Unimed");
                ListaPacientes.Add(paciente);
            }
        }
        public void CargaMedico()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Medico medico = new Medico(i, $"Medico {i}", $"{i}23{i}56{i}7891{i}", random.Next(100000, 999999), "Pediatra");
                ListaMedicos.Add(medico);
            }

        }
        public void CargaRecepcionista()
        {
            for (int i = 0; i < 10; i++)
            {
                Recepcionista recepcionista = new Recepcionista(i, $"Recepcionista {i}", $"{i}23{i}56{i}7891{i}", "Ala Leste");
                ListaRecepcionistas.Add(recepcionista);
            }  
            
        }
        public void CargaFornecedor()
        {
            for (int i = 0; i < 10; i++)
            {
                Fornecedor fornecedor = new Fornecedor(i, $"Fornecedor {i}", $"{i}23{i}56{i}7891{i}", "Alimentício");
                ListaFornecedor.Add(fornecedor);
            }
        }
    }
}
