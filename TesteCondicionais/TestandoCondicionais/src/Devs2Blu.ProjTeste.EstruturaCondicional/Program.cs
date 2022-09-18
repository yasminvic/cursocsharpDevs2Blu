using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjTeste.EstruturaCondicional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opc;

            do
            {
                Console.WriteLine("6 - Exercicio 6");
                Console.WriteLine("7 - Exercicio 7");
                Console.WriteLine("6 - Exercicio 6");
                Console.WriteLine("6 - Exercicio 6");
                Console.WriteLine("6 - Exercicio 6");

                Console.Write("Escolha uma opção do menu: ");
                opc = Console.ReadLine();

                if (opc == "6")
                {
                    Exercicio6();
                }else if(opc == "7")
                {
                    //Exercicio7();
                }




            } while (opc != "0");
        }


        static void Exercicio6()
        {
            Console.Clear();

            Console.WriteLine("*** Programa 6 ***\n");
            Console.WriteLine("Calcula o peso ideal\n");

            string sexo;
            double altura, formula;

            Console.WriteLine("Informe a sua altura: ");
            string altSTR = Console.ReadLine();
            Double.TryParse(altSTR, out altura);

            Console.WriteLine("Informe o seu sexo: (1 - Feminino, 2 - Masculino)");
            sexo = Console.ReadLine();

            /*formula = (sexo == "1") ? (62.1 * altura) - 44.7 : 72.7 * altura - 58;

            Console.WriteLine(formula); */

            if (sexo == "1")
            {
                Console.WriteLine($"O seu peso ideal é: {(62.1 * altura) - 44.7}\n");
            }else if (sexo == "2")
            {
                Console.WriteLine($"O seu peso ideal é: {72.7 * altura - 58}\n");
            }
            else
            {
                Console.WriteLine("Código inválido para altura\n");
            }

            

        }

        static void Exercicio7()
        {
            Console.Clear();

            Console.WriteLine("*** Programa 7 ***\n");
            Console.WriteLine("Calcular a área do polígono\n");

            int lado;
            double medida;

            Console.Write("informe quantos lados tem o polígono");
            string ladoSTR = Console.ReadLine();
            Int32.TryParse(ladoSTR, out lado);

            Console.Write("Informe a medida dos lados do polígono");
            string medidaSTR = Console.ReadLine();
            Double.TryParse(medidaSTR, out medida);

            if (lado == 3)
            {
                Console.WriteLine("O seu polígono é um TRIÂNGULO");
                Console.WriteLine($"A área do triângulo é: ");
           }else if (lado == 4)
            {
                Console.WriteLine("O seu polígono é um QUADRADO");
                Console.WriteLine($"A área desse quadrado é: {lado * lado}");

            }
            



        }

        }
}
