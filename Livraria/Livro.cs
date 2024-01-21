﻿namespace Livraria;

class Livro
{
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public long ISBN { get; set; }
    public string Genero { get; set; }
    public double Preco { get; set; }
    public double IVA { get; set; }
    public int Stock{ get; set; }
     
    public static List<Livro> livros = new List<Livro>
    {
        new Livro
        {
            Codigo = 560071624,
            Titulo = "As Aventuras de Noddy",
            Autor = "Rodrigo Faria",
            ISBN = 1234567890,
            Genero = "Aventura",
            Preco = 12.99,
            IVA = 0.06,
            Stock = 50
        },
        new Livro
        {
            Codigo = 550392624,
            Titulo = "As Aventuras do Pou",
            Autor = "Luís Vaz de Camões",
            ISBN = 1234567890,
            Genero = "Aventura",
            Preco = 22.99,
            IVA = 0.06,
            Stock = 25
        },
        new Livro
        {
            Codigo = 560071236,
            Titulo = "O homicidio perfeito",
            Autor = "Holly Jackson",
            ISBN = 9789722367301,
            Genero = "Ação",
            Preco = 15.99,
            IVA = 0.23,
            Stock = 15
        }
    };

    public static void ListarLivro()
    {
        Console.Clear();
        foreach (var livro in Livro.livros)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Nome: " + livro.Titulo);
            Console.WriteLine("Autor: " + livro.Autor);
            Console.WriteLine("Código: " + livro.Codigo);
            Console.WriteLine("ISBN: " + livro.ISBN);
            Console.WriteLine("Género: " + livro.Genero);
            Console.WriteLine("Preço: " + livro.Preco);
            Console.WriteLine("IVA: " + livro.IVA);
            Console.WriteLine("Stock: " + livro.Stock);
        }
    }
    
    public static void ConsultarLivroPorCodigo() // Rever - Alterar se for preciso
    {
        int codigoLivro;
        Console.WriteLine("Qual é o código do livro que procura?");
        codigoLivro = Convert.ToInt32(Console.ReadLine());
        
        Livro livroEncontrado = Livro.livros.Find(livro => livro.Codigo == codigoLivro);

        if (livroEncontrado != null)
        {
            Console.WriteLine($"Livro encontrado: {livroEncontrado.Titulo}");
        }
        else
        {
            Console.WriteLine($"Livro com código {codigoLivro} não encontrado.");
        }
    }
}