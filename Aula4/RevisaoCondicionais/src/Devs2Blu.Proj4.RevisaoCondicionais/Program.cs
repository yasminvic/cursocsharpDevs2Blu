using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.Proj4.RevisaoCondicionais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("oii, usuário");

                Console.WriteLine("Escolha o programa desejado: ");

                Console.WriteLine("1 - Exemplo 1");
                Console.WriteLine("2 - Exemplo 2");
                Console.WriteLine("3 - Exemplo 3");
                Console.WriteLine("4 - Exemplo 4");
                Console.WriteLine("5 - Exemplo 5");
                Console.WriteLine("6 - Exemplo 6");
                Console.WriteLine("7 - Exemplo 7");
                Console.WriteLine("9 - Exemplo 9");
                Console.WriteLine("10 - Exemplo 10");
                Console.WriteLine("0 - Sair");

                string opcSTR = Console.ReadLine();

                //maneira simples de converter str para int
                Int32.TryParse(opcSTR, out opcao);

                if (opcao == 1)
                {
                    Exemplo1();
                }
                else if (opcao == 2)
                {
                    Exemplo2();
                }
                else if (opcao == 3)
                {
                    Exemplo3();
                }
                else if (opcao == 4)
                {
                    Exemplo4();
                }
                else if (opcao == 5)
                {
                    Exemplo5();
                }
                else if (opcao == 6)
                {
                    Exemplo6();
                }else if (opcao == 7)
                {
                    Exemplo7();
                }
                else if (opcao == 9)
                {
                    Exemplo9();
                }
                else if (opcao == 10)
                {
                    Exemplo10();
                }
                else if (opcao == 0)
                {
                    Console.WriteLine("\nTchau, usuário <3");
                }

            }while(opcao != 0);
            

                // control + h substitui um termo no código

                // not é !

            }

        static void Exemplo1()
        {

            Console.Clear(); //limpa o console

            Console.WriteLine("\n*** Programa exemplo 1 ***\n");
            Console.WriteLine("Gerar 2 números aleatórios (1 - 100)");
            Console.WriteLine("Mostrar o maior entre eles\n");

            int n1, n2;

            Random rd = new Random();

            n1 = rd.Next(1, 100);
            n2 = rd.Next(1, 100);

            Console.WriteLine($"O número 1 é: {n1}\nO número 2 é: {n2}\n");

            if (n1 > n2)
            {
                Console.WriteLine($"O número 1 é o maior - N1 = {n1}");
            }else if(n2 > n1)
            {
                Console.WriteLine($"O número 2 é o maior - N2 = {n2}");
            }
            else
            {
                Console.WriteLine("Os números são iguais");
            }
        }

        static void Exemplo2()
        {
            Console.WriteLine("\n*** Programa exemplo 2 ***\n");

            Console.WriteLine("Gerar 3 números aleatórios");
            Console.WriteLine("Escrevê-los em ordem crescente\n");

            int n1, n2, n3;

            Random rd = new Random();
        }

        static void Exemplo3()
        {

            Console.Clear();

            Console.WriteLine("\n*** Programa exemplo 3 ***");
            Console.WriteLine("*** Verifica se um número é ímpar ***\n");

            int n;

            //Random rd = new Random();


            Console.Write("Digite um número: ");
            string nSTR = Console.ReadLine();
            Int32.TryParse(nSTR, out n);

            //Console.WriteLine($"\n*** O número sorteado é: {n} ***");

            int formula = n - n / 2 * 2;

            if (formula == 0)
            {
                Console.WriteLine($"\nO número {n} é par.\n");
            }
            else
            {
                Console.WriteLine($"\nO número {n} é ímpar.\n");
            }

            


        }

        static void Exemplo4()
        {

            Console.Clear();

            Console.WriteLine("\n*** Programa exemplo 4 ***");
            Console.WriteLine("*** Exibir produto ***\n");


            string opcao;

            Console.WriteLine("*** MENU ***\n");
            Console.WriteLine("001 - Arroz");
            Console.WriteLine("002 - Feijão");
            Console.WriteLine("003 - Farinha");

            Console.Write("\nEscolha uma das opções do menu: ");
            opcao = Console.ReadLine(); 

            if (opcao == "001")
            {
                Console.WriteLine("\nO produto escolhido foi o ARROZ.\n");
            }else if(opcao == "002")
            {
                Console.WriteLine("\nO produto escolhido foi o FEIJÃO.\n");
            }else if (opcao == "003")
            {
                Console.WriteLine("\nO produto escolhido foi a FARINHA.\n");
            }
            else
            {
                Console.WriteLine("\nCódigo inválido.\n");
            }

        }

        static void Exemplo5()
        {
            Console.Clear();

            Console.WriteLine("\n*** Programa exemplo 5 ***");
            Console.WriteLine("*** Verifica se alguém está apto a votar ***\n");

            int ano;

            Console.Write("Informe o seu ano de nascimento: ");
            string anoSTR = Console.ReadLine();
            Int32.TryParse(anoSTR, out ano);

            int idade = DateTime.Now.Year - ano;

            if (idade >= 16)
            {
                Console.WriteLine($"\nVocê tem {idade} anos, já pode votar.\n");
            }
            else
            {
                Console.WriteLine($"\nVocê tem {idade} anos, ainda não pode votar.\n");
            }



        }

        static void Exemplo6()
        {
            Console.Clear();

            Console.WriteLine("\n*** Programa exemplo 6 ***");
            Console.WriteLine("*** Verificar a validade de uma senha fornecida pelo usuário. ***\n");

            const string SENHA = "1234";

            Console.Write("Digite a senha para acessar: ");
            string input = Console.ReadLine();

            string texto = (input == SENHA) ? "\nACESSO PERMITIDO\n" : "\nACESSO NEGADO\n";

            Console.WriteLine(texto);

            Console.WriteLine("********************\n");



        }

        static void Exemplo7()
        {
            Console.Clear();

            Console.WriteLine("\n*** Programa exemplo 7 ***");
            Console.WriteLine("*** As maçãs custam R$ 0,30 cada se forem compradas menos do que uma dúzia ***");
            Console.WriteLine("*** R$ 0,25 se forem compradas pelo menos doze ***");
            Console.WriteLine("*** Calcular o valor da compra. ***\n");

            int quantMaca;
            double preco, total;

            Console.Write("Informe a quantidade de maçãs compradas: ");
            string quantSTR = Console.ReadLine();
            Int32.TryParse(quantSTR, out quantMaca);

            if (quantMaca <= 11)
            {
                preco = 0.3;
            }
            else
            {
                preco = 0.25;
            }

            total = quantMaca * preco;

            Console.WriteLine($"\nO preço das maçãs é R$ {preco}");
            Console.WriteLine($"O valor total da compra é R$ {total}\n");
            


        }

        static void Exemplo9()
        {
            int idade;
            bool permissao;
            string nome;

            Console.Write("Informe seu nome: ");
            nome = Console.ReadLine();

            Console.Write("Informe sua idade: ");
            string idadeSTR = Console.ReadLine();
            Int32.TryParse(idadeSTR, out idade);

            permissao = (idade >= 18) ? true : false;
            //variavel = (condição) ? oq acontece se for vdd : oq acontece se for falsa

            if (permissao)
            {
                Console.WriteLine($"\nSeja bem vindo(a), {nome}! (+18)\n");

            }
            else
            {
                Console.WriteLine("\nVocê não pode entrar. Idade menor de 18 anos.\n");
            }
        }

        static void Exemplo10()
        {
            Console.Clear();

            Console.WriteLine("\n*** Programa exemplo 10 ***");
            Console.WriteLine("*** Verificar a pessoa pode se aposentar. ***\n");

            int idade, tempoTrabalho;

            Random rand = new Random();

            idade = rand.Next(50, 80);
            tempoTrabalho = rand.Next(15, 40);

            Console.WriteLine($"A sua idade é: {idade}");
            Console.WriteLine($"O seu tempo de trabalho é: {tempoTrabalho}");

            if((idade > 65) || (tempoTrabalho > 25))
            {
                Console.WriteLine("\nEBAAA ! Você pode se aposentar\n");
            }
            else
            {
                Console.WriteLine("\nLamentamos, mas ainda não pode se aposentar\n");
            }
        }
        
    }
}
