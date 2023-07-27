using LibrarySystem;
using System;
using static LibrarySystem.Cliente;


namespace LibrarySystem
{
    public class Program
    {
        static List<Cliente> listarClientes = new List<Cliente>();

        static void Main(string[] args)
        {
          int op;

            while(true)
            {

                Console.Write($"\n\n[1]-Alugar um livro \n[2]-Devolver livro \n[3]-Listar clientes \n[4]-Sair do sistema");

                Console.Write("\n\nDigite uma das opções acima: ");
                op = int.Parse(Console.ReadLine());

                switch(op)
                {
                    case 1:
                        Console.Clear();
                        ClienteAlugar();
                        Thread.Sleep(4000);
                        break;
                    case 2:
                        Console.Clear();
                        ClienteDevolver();
                        Thread.Sleep(4000);
                        break;
                    case 3:
                        Console.Clear();
                        listarClientesAl();
                        Thread.Sleep(6000);
                        break;
                }
            }

        }

        static void ClienteAlugar()
        {
            Cliente cliente = new Cliente();
            Livros livro = new Livros();
            string Book;
            int QtdCliente, i, j;

            Console.Write("Digite a quantidade de clientes que desejam alugar: ");
            QtdCliente = int.Parse(Console.ReadLine());
            for (i = 1; i <= QtdCliente; i++)
            {
                Console.Write("Digite um código para o cliente: ");
                cliente.Codigo = int.Parse(Console.ReadLine());
                Console.Write("Digite o nome do cliente: ");
                cliente.Nome = Console.ReadLine();
                Console.Write("Digite a quantidade de livros que o cliente gostaria de alugar: ");
                cliente.QtdeLivros = int.Parse(Console.ReadLine());

                for (j = 1; j <= cliente.QtdeLivros; j++)
                {
                    Console.Write("\nDigite o nome do livro que o cliente deseja alugar: ");
                    Book = Console.ReadLine();

                    if (livro.catalogo.ContainsKey(Book))
                    {
                        int valorAtual = livro.catalogo[Book];
                        int novoValor = valorAtual - 1;
                        livro.catalogo[Book] = novoValor;
                        livro.listaAlugados.Add(Book);
                        Console.WriteLine($"Parabéns, o cliente alugou o livro '{Book}', portanto estoque atual deste livro é {novoValor} unidades");
                    }
                    else
                    {
                        Console.WriteLine($"\nO livro '{Book}' não existe no catalogo.");
                    }

                }
            }
        }
        static void ClienteDevolver()
        {
            Cliente cliente = new Cliente();
            Livros livro = new Livros();
            string Book;
            int QtdCliente, i, j;
            int count = livro.listaAlugados.Count();

            Console.Clear();

            Console.Write("Digite o código do cliente: ");
            cliente.Codigo = int.Parse(Console.ReadLine());
            Console.Write("\nDigite a quantidade de livros que você gostaria de devolver: ");
            cliente.QtdeLivros = int.Parse(Console.ReadLine());

            if (cliente.QtdeLivros > count)
            {
                Console.WriteLine("\nLamento, mas a quantidade digitada excede a quantidade de livros alugados.");
            }
            else
            {
                for (i = 1; i <= cliente.QtdeLivros; i++)
                {

                    Console.Write("\nDigite o nome do livro que gostaria de devolver: ");
                    Book = Console.ReadLine();

                    bool localizado = livro.listaAlugados.Contains(Book);
                    if (localizado)
                    {

                        if (livro.catalogo.ContainsKey(Book))
                        {
                            int valorAtual = livro.catalogo[Book];
                            int novoValor = valorAtual + 1;
                            livro.catalogo[Book] = novoValor;
                            livro.listaAlugados.Remove(Book);

                            Console.Write($"\nO livro devolvido foi '{Book}', obrigado por devolvê-lo volte sempre!");
                            Console.Write($"\nO estoque atual do livro devolvido é {novoValor} unidades");
                        }
                    }
                    else
                    {
                        Console.Write("\nLamento este livro não foi alugado.");
                    }
                }
            }
        }
        static void listarClientesAl()
        {
            Cliente cliente = new Cliente();
            Livros livro = new Livros();
            foreach(Cliente clientes in listarClientes)
            {
                Console.Write($"Código do cliente: {cliente.Codigo}\nNome do cliente: {cliente.Nome}\nQuantidade de livros alugados: {cliente.QtdeLivros}");
            }
            /*foreach (string livros in livro.listaAlugados)
            {
                Console.Write("\nLivros alugados: ", livros);
            }*/
        }
    }

}