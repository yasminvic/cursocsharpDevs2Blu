using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Aula5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            
        }

        static void ExemploSwitch()
        {
            string codigo;


            Console.WriteLine("MENU");

            Console.WriteLine("- A23");
            Console.WriteLine("- A35");
            Console.WriteLine("- Z16");


            Console.WriteLine("Escolha um código para ver a descrição: ");
            codigo = Console.ReadLine();

            switch (codigo)//testando os casos dessa variavel
            {
                case "A23":
                    Console.WriteLine("A23: Materiais");
                    break; //sempre tem que ter break no final
                           // senao ele vai rodar o default tbm

                case "1": //dá de colocar vários cases juntos
                case "A35":
                    Console.WriteLine("A35: Produtos Perecíveis");
                    break;


                case "Z16":
                    Console.WriteLine("Z16: Produtos Químicos");
                    break;
                default: //tipo um else
                    Console.WriteLine("Código inválido");
                    break;



            }
        }


        static void Exercicio1S()
        {
            string fruta;
            const string MACA = "MAÇÃ", KIWI = "KIWI", MELANCIA = "MELANCIA";

            Console.WriteLine("*** VENDINHA DA YASMIN ***\n");

            Console.WriteLine("Informe qual fruta deseja comprar: ");
            fruta = Console.ReadLine();

            switch (fruta.ToUpper())
            {
                case MACA:
                    Console.WriteLine("Desculpa, mas não vendemos esta fruta aqui.\n");
                    break;

                case KIWI:
                    Console.WriteLine("Neste momento, estamos com escassez de kiwis.\n");
                    break;

                case MELANCIA:
                    Console.WriteLine("Aqui está, são 3 reais o quilo.\n");
                    break;

                default:
                    Console.WriteLine("Essa fruta está em falta agora, mas te avisaremos quando chegar.\n");
                    break;

            }
        }


        static void Exercicio2S()
        {
            string opcao;

            Console.WriteLine("*** CONCESSIONÁRIA DA YASMIN ***\n");

            Console.WriteLine(" -------MENU-------");
            Console.WriteLine("| Carro Hatch      | ");
            Console.WriteLine("| Carro Sedan      | ");
            Console.WriteLine("| Motocicletas     | ");
            Console.WriteLine("| Caminhonetes     | ");
            Console.WriteLine(" ------------------\n");

            Console.WriteLine("Informe o carro que deseja comprar: ");
            opcao = Console.ReadLine();

            switch (opcao.ToUpper())
            {
                case "HATCH":
                    Console.WriteLine("Compra efetuada com sucesso\n");
                    break;
                case "SEDAN":
                case "MOTOCICLETA":
                case "CAMINHONETE":
                    Console.WriteLine("Tem certeza que não prefere outro modelo\n");
                    break;
                default:
                    Console.WriteLine("Não trabalhamos com este tipo de automóvel aqui\n");
                    break;
            }
        }

        static void Exercicio5S()
        {
            Console.WriteLine("**************");
            Console.WriteLine("* Jogo do 21 *");
            Console.WriteLine("**************");

            int numUser, numComp, numSor, pontosUser, pontosComp = 0;

            Random rd = new Random();

            //número do usuário
            Console.WriteLine("Escolha um número entre 1-20: ");
            string numSTR = Console.ReadLine();
            Int32.TryParse(numSTR, out numUser);

            //número do computador 
            numComp = rd.Next(1, 20);

            Console.WriteLine($"\nO número do seu adversário (computador) é {numComp}");

            //número sorteado
            numSor = rd.Next(1, 20);

            Console.WriteLine($"\n*** O número sorteado é {numSor} ***\n");

            numUser += numSor;
            numComp += numSor;

            switch (numUser)
            {
                case 7:
                    pontosUser = 10;
                    break;

                case 14:
                    pontosUser = 20;
                    break;

                case 21:
                    pontosUser = 30;
                    break;


                // case int i when (i >= 6): 
                //essa linha de cima diz que tal caso (CASE) será executado quando (WHEN)...
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    pontosUser = 1;
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    pontosUser = 5;
                    break;

                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    pontosUser = 6;
                    break;

                default:
                    pontosUser = 0;
                    break;
            }



            switch (numComp)
            {
                case 7:
                    pontosComp = 10;
                    break;

                case 14:
                    pontosComp = 20;
                    break;

                case 21:
                    pontosComp = 30;
                    break;

                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    pontosComp = 1;
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    pontosComp = 5;
                    break;

                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    pontosComp = 6;
                    break;

                default:
                    pontosComp = 0;
                    break;
            }

            if (pontosUser > pontosComp)
            {
                Console.WriteLine(" -------------------------------------------");
                Console.WriteLine("| PARABÉNS !!! Você venceu o jogo!         |");
                Console.WriteLine($"| Sua pontuação foi {pontosUser} e do computador foi {pontosComp}|");
                Console.WriteLine(" -------------------------------------------");
            }
            else if (pontosUser == pontosComp)
            {
                Console.WriteLine(" --------------------------------------");
                Console.WriteLine($"| EMPATE ! Vocês dois fizeram {pontosUser} pontos|");
                Console.WriteLine(" --------------------------------------");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"| DERROTA ! O computador venceu com {pontosComp} e você com {pontosUser} pontos|");
                Console.WriteLine("----------------------------------------------------------");
            }
        }
    }
}
