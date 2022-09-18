using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Devs2Blu.ProjetosAula3.ProjetoCondicionais
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*string nome, cidade;

            Console.Write("Digite seu nome: ");
            nome = Console.ReadLine();

            Console.Write("Digite sua cidade: ");
            cidade = Console.ReadLine();


            Console.WriteLine("\n****************************");

            Console.WriteLine($"*Seja bem vindo(a), {nome}.*\n*Sua cidade é: {cidade}    *");

            Console.WriteLine("****************************");*/

            int n1, n2, n3, n4;
            int menorNum = 99999999;

            Console.WriteLine("Verifica o menor número entre 4");

            Console.Write("Digite o valor 1: ");
            string n1STR = Console.ReadLine();
            Int32.TryParse(n1STR, out n1);


            Console.Write("Digite o valor 2: ");
            string n2STR = Console.ReadLine();
            Int32.TryParse(n2STR, out n2);


            Console.Write("Digite o valor 3: ");
            string n3STR = Console.ReadLine();
            Int32.TryParse(n3STR, out n3);


            Console.Write("Digite o valor 4: ");
            string n4STR = Console.ReadLine();
            Int32.TryParse(n4STR, out n4);

            if(n1 < menorNum)
            {
                menorNum = n1;
            }
            if (n2 < menorNum)
            {
                menorNum = n2;
            }
            if(n3 < menorNum)
            {
                menorNum=n3;
            }
            if(n4 < menorNum)
            {
                menorNum = n4;
            }

            Console.WriteLine($"\n\nO menor número informado é: {menorNum}\n");

            /*if (n1 < n2 &&
                n1 < n3 &&
                n1 < n4)
            {
                Console.WriteLine($"O menor valor é: {n1}");
            }else if (n2 < n3 &&
                        n2 < n4)
            {
                Console.WriteLine($"O menor valor é: {n2}");
            }else if (n3 < n4)
            {
                Console.WriteLine($"O menor valor é: {n3}");
            }
            else
            {
                Console.WriteLine($"O menor valor é: {n4}");
            }*/



        }


        static void Exemplo2()
        {
            int valor1, valor2;
            string textFormat;

            Console.WriteLine("*** Bem vindo, usuário :)\n");

            Console.Write("Digite um valor: ");
            string valor1STR = Console.ReadLine();

            if (valor1STR.Equals(""))
            {
                Console.WriteLine("Valor inválido!");
                return; // encerrra o código
            }
            else
            {
                valor1 = Int16.Parse(valor1STR);
            }



            Console.Write("Digite outro valor: ");
            string valor2STR = Console.ReadLine();

            if (valor2STR.Equals(""))
            {
                Console.WriteLine("Valor inválido!");
                return; // encerrra o código
            }
            else
            {
                valor2 = Int16.Parse(valor2STR);
            }



            textFormat = "\n************************************\n\n";
            textFormat += $"Entre {valor1} e {valor2}, o maior número é: \n";


            if (valor1 > valor2)
            {
                textFormat += $"\n              {valor1}                ";
            }
            else if (valor1 < valor2)
            {
                textFormat += $"\n              {valor2}                    ";
            }
            else
            {
                textFormat += "\nNenhum, pois os dois números são iguais";
            }

            textFormat += "\n************************************\n\n";

            Console.WriteLine(textFormat);
        }

        

        static void Exemplo1()
        {
            string textoFormat;
            string nome;
            int idade, nota;

            Console.WriteLine("*** oi, usuário ***");

            Console.Write("Digite seu nome, candidato: ");
            nome = Console.ReadLine();

            Console.Write("Digite sua idade, candidato: ");
            string idadeSTR = Console.ReadLine();

            if (idadeSTR.Equals(""))
            {
                Console.WriteLine("Valor inválido para idade!");
                return; // encerrra o código
            }
            else
            {
                idade = Int16.Parse(idadeSTR);
            }



            Console.Write("Informe sua nota, candidato: ");
            string notaSTR = Console.ReadLine();


            if (notaSTR.Equals(""))
            {
                Console.WriteLine("Valor inválido para nota!");
                return; // encerrra o código
            }
            else
            {
                nota = Int16.Parse(notaSTR);
            }

            // formatação saída de dados
            textoFormat = $"Candidato: {nome}\n";
            textoFormat += $"Idade: {idade}";


            if (idade < 18)
            {
                textoFormat += " - Menor de idade\n\n";
            }
            else
            {
                textoFormat += " - Maior de idade\n\n";
            }

            textoFormat += $"Nota final: {nota}\n";

            if (nota < 6)
            {
                textoFormat += "Você foi REPROVADO :(";
            }
            else
            {
                textoFormat += "Parabéns você foi APROVADO !! :)";
            }

            Console.WriteLine("\n*******************************\n");

            Console.WriteLine(textoFormat);

            Console.WriteLine("\n*******************************\n");
        }
    }
}
