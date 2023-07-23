using System;

namespace LibrarySystem
{ 
    class Program
    {
        static void Main(string[] args)
        {

            int op = 0;
            string Livro;
            int id;

            Cliente cliente = new Cliente();

            Dictionary<string, int> catalogo = new Dictionary<string, int>() // Nome dos livros e seu estoque
            {
                {"Pai rico, pai pobre", 250 },
                {"Rápido e devagar: maneiras de pensar", 300 },
                {"A arte da guerra", 450 },
                {"Mindset", 350 },
                {"Como hackear seu cérebro", 500 },
                {"O alquimista", 225 },
                {"Manual de persuasão do FBI", 330 },
                {"As 48 leis do poder", 325 },
                {"A lei da atração", 450 },
                {"O que é impossível para você?", 425 }
            };

            List<string> listaAlugados = new List<string>();
            
            while(op!=4)
            {
                int QtdeLivros, i;
                
                Console.Write($"\n\n\n[1]-Alugar um livro \n[2]-Devolver livro \n[3]-Listar livros alugados \n[4]-Sair do sistema");

                Console.Write("\n\nDigite uma das opções acima: ");
                op = int.Parse(Console.ReadLine());
                
                switch(op)
                {
                    case 1:

                        Console.Clear();

                        Console.Write("Digite o nome do cliente: ");
                        cliente.nome = Console.ReadLine();
                        Console.Write("\nDigite a quantidade de livros que você gostaria de alugar: ");
                        QtdeLivros = int.Parse(Console.ReadLine());

                    for(i = 1; i <= QtdeLivros; i++)
                    {
                        Console.Write("\n\nDigite o nome do livro que deseja alugar: ");
                        Livro = Console.ReadLine();

                        if (catalogo.ContainsKey(Livro))
                        {
                            int valorAtual = catalogo[Livro];
                            int novoValor = valorAtual - 1;
                            catalogo[Livro] = novoValor;
                            listaAlugados.Add(Livro);
                            Console.WriteLine($"Parabéns, você alugou o livro '{Livro}', portanto estoque atual deste livro é {novoValor} unidades");
                        }
                        else
                        {
                            Console.WriteLine($"\nO Livro '{Livro}' não existe no catalogo.");
                        }

                    }
                        Thread.Sleep(4000);
                        break;
                    
                    case 2:

                        int count = listaAlugados.Count();

                        Console.Clear();

                        Console.Write("Digite a quantidade de livros que você gostaria de devolver: ");
                        QtdeLivros = int.Parse(Console.ReadLine());
                        
                        if(QtdeLivros > count)
                        {
                            Console.WriteLine("\nLamento, mas a quantidade digitada excede a quantidade de livros alugados.");
                        }
                        else
                        {

                        for(i = 1; i <= QtdeLivros; i++)
                        {

                        Console.Write("\n\nDigite o nome do livro que gostaria de devolver: ");
                        Livro = Console.ReadLine();

                        bool localizado = listaAlugados.Contains(Livro);
                        if(localizado)
                        {

                            if (catalogo.ContainsKey(Livro))
                            {
                                int valorAtual = catalogo[Livro];
                                int novoValor = valorAtual + 1;
                                catalogo[Livro] = novoValor;
                                listaAlugados.Remove(Livro);

                                Console.Write($"\nO livro devolvido foi '{Livro}', obrigado por devolvê-lo volte sempre!");
                                Console.Write($"\n\nO estoque atual do livro devolvido é {novoValor} unidades");
                            }
                        }
                        else
                        {
                            Console.Write("\nLamento este livro não foi alugado.");
                        }
                        }
                        }

                        Thread.Sleep(4000);
                        break;
                    case 3:

                        Console.Clear();

                        foreach(string livros in listaAlugados)
                        {
                            Console.Write("\nLivro alugado: ");
                            Console.WriteLine(livros);
                        }

                        Thread.Sleep(5000);
                        break;
                }
            }
        }
    }
}
