using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Aula6Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string controle;


            do
            {
                
                Console.WriteLine("Escolha um programa para rodar (0 - sair): ");
                controle = Console.ReadLine();

                switch (controle)
                {
                    case "0":
                        Console.WriteLine("Fim do programa");
                        break;

                    case "1":
                        Exemplo1W();
                        break;

                    case "2":
                        Exemplo2W();
                        break ;

                    case "3":
                        Exercicio3W();
                        break;

                    case "4":
                        Exercicio4W();
                        break;

                    case "7":
                        Exercicio7W();
                        break;

                    default:
                        Console.WriteLine("Programa inexistente");
                        break;
                }


            } while (controle != "0");

                
            
        }

        static void Exemplo1W()
        {

            Console.Clear();

            Console.WriteLine("*** Programa 1 ***");

            int contador = 1;

            Console.WriteLine("Entre 1 e 100, esses números são ímpares: \n");

            Console.WriteLine(" ------");

            while (contador < 100)
            {
                if (contador % 2 != 0)
                {
                    

                    if (contador > 10)
                    {
                        Console.WriteLine($"|  {contador} |");
                    }
                    else
                    {
                        Console.WriteLine($"|  {contador}  |");
                    }
                }
                
                contador++;
            }

            Console.WriteLine(" ------");
        }

        static void Exemplo2W()
        {
            Console.Clear();

            Console.WriteLine("*** Programa 2 ***");

            int contador = 1;

            Console.WriteLine("Entre 1 e 100, esses números são pares: \n");

            Console.WriteLine(" ------");

            while (contador <= 100)
            {
                if (contador % 2 == 0)
                {

                    if (contador >= 10)
                    {
                        Console.WriteLine($"|  {contador} |");
                    }
                    else
                    {
                        Console.WriteLine($"|  {contador}  |");
                    }
                }

                contador++;
            }

            Console.WriteLine(" ------");
        }

        static void Exercicio3W()
        {
            Console.Clear();

            Console.WriteLine("*** Programa 3 ***");

            int numUser, contador = 1;

            Console.WriteLine("Informe um número: ");
            Int32.TryParse(Console.ReadLine(), out numUser);

            Console.WriteLine($"Entre 1 e {numUser}, esses números são pares: \n");

            Console.WriteLine(" ------");

            while (contador <= numUser)
            {
                // par
                if (contador % 2 == 0)
                {

                    if (contador >= 10)
                    {
                        Console.WriteLine($"|  {contador} |");
                    }
                    else
                    {
                        Console.WriteLine($"|  {contador}  |");
                    }
                }

                contador++;
            }

            Console.WriteLine(" ------");

            Console.WriteLine($"Entre 1 e {numUser}, esses números são ímpares: \n");

            contador = 0;

            Console.WriteLine(" ------");

            while (contador <= numUser)
            {
                if (contador % 2 != 0)
                {

                    if (contador >= 10)
                    {
                        Console.WriteLine($"|  {contador} |");
                    }
                    else
                    {
                        Console.WriteLine($"|  {contador}  |");
                    }
                }

                contador++;
            }

            Console.WriteLine(" ------");



        }

        static void Exercicio4W()
        {
            Console.Clear();

            Console.WriteLine("*** Programa 4 ***");

            Console.WriteLine("\n*** Calcula a média aritmética das notas ***\n");

            int alunoUser, contador = 1;
            double nota, soma = 0, media;

            Console.WriteLine("Informe quantos alunos há na sala: ");
            Int32.TryParse(Console.ReadLine(), out alunoUser);

            while (contador <= alunoUser)
            {
                Console.WriteLine($"Digite a nota do aluno {contador}: ");
                Double.TryParse(Console.ReadLine(), out nota);

                soma += nota;
                contador++;
            }

            media = soma / alunoUser;

            Console.WriteLine("\n --------------------------------------");
            Console.WriteLine($"| A média das notas da sala é {media:F1}     |");//esse F1 é o número de casas, F2 seria 2 casas
            Console.WriteLine(" --------------------------------------\n");

        }

        static void Exercicio7W()
        {
            Console.Clear();

            Console.WriteLine("*** Programa 7 ***");

            Console.WriteLine("Jogo: acerte o número");

            int chance = 3, numComp, numUser;

            Random rd = new Random();
            numComp = rd.Next(1, 20);

            while (chance > 0)
            {
                Console.WriteLine("Digite um número entre 1 e 20: ");
                Int32.TryParse(Console.ReadLine(), out numUser);

                chance--;

                if (numUser == numComp)
                {
                    Console.WriteLine(" ------------------------------------------------------");
                    Console.WriteLine($"| PARABÉNS !! Você acertou o número e ganhou o jogo !! |");
                    Console.WriteLine(" ------------------------------------------------------\n");
                    break;
                }
                else
                {
                    if (chance > 0)
                    {
                        Console.WriteLine("OPSS ! Você errou o número");
                        Console.WriteLine($"Você ainda tem {chance} chance(s)\n");
                    }
                    else
                    {
                        Console.WriteLine(" ----------------------------------------------------------------");
                        Console.WriteLine("| DERROTA ! Você gastou todas as suas chances e perdeu o jogo    |");
                        Console.WriteLine($"| A resposta correta era {numComp}                                      |");
                        Console.WriteLine(" ----------------------------------------------------------------\n");
                    }
                }                                  
                              
            }          

        }
    }
}
