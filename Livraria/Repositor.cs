namespace Livraria;

class Repositor
{
    public static void RegistrarLivro()
    {
        Console.Clear();
        string titulo, autor, genero;
        int cod_livro, isbn, stock;
        double preco, iva;
        
        Console.WriteLine("Qual é o nome do novo livro? \n");
        titulo = Console.ReadLine();
        Console.WriteLine("Qual é o autor do livro? \n");
        autor = Console.ReadLine();
        Console.WriteLine("Qual é o código do livro? \n");
        cod_livro = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("ISBN do livro? \n");
        isbn = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual é o Género do livro? \n");
        genero = Console.ReadLine();
        Console.WriteLine("Qual é o Preço do livro? \n");
        preco = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Qual é o IVA do livro? \n");
        iva = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Quantidade de stock? \n");
        stock = Convert.ToInt32(Console.ReadLine());

        Livro novoLivro = new Livro
        {
            Titulo = titulo,
            Autor = autor,
            Codigo = cod_livro,
            ISBN = isbn,
            Genero = genero,
            Preco = preco,
            IVA = iva,
            Stock = stock
        };

        Livro.livros.Add(novoLivro);
        Console.WriteLine("Livro registrado com sucesso!");
    }
    
    public static void RemoverLivro()
    {
        Console.Clear();
        Console.WriteLine("Digite o código do livro que deseja remover:");
        if (int.TryParse(Console.ReadLine(), out int codigoLivro))
        {
            Livro livroParaRemover = Livro.livros.Find(livro => livro.Codigo == codigoLivro);

            if (livroParaRemover != null)
            {
                Livro.livros.Remove(livroParaRemover);
                Console.WriteLine("Livro removido com sucesso: " + livroParaRemover.Titulo);
            }
            else
            {
                Console.WriteLine("Livro com código " + codigoLivro + " não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Código inválido. Por favor, insira um código válido.");
        }
    }
    
    public static void ListarLivrosPorGenero()
    {
        Console.Clear();
        Console.WriteLine("Digite o gênero que deseja listar:");
        string generoDesejado = Console.ReadLine();

        var livrosDoGenero = Livro.livros.Where(livro => livro.Genero.Equals(generoDesejado, StringComparison.OrdinalIgnoreCase)).ToList();

        if (livrosDoGenero.Any())
        {
            Console.Clear();
            Console.WriteLine("Livros do gênero  " + generoDesejado + ":");
            Console.WriteLine("------------------------");
            foreach (var livro in livrosDoGenero)
            {
                Console.WriteLine("Título: " + livro.Titulo + "\n Autor: " + livro.Autor + "\n Código: " + livro.Codigo + "\n");
                Console.WriteLine("------------------------");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nenhum livro encontrado do gênero " + generoDesejado + ".");
        }
    }
    public static void AdicionarStock()
    {
        Console.WriteLine("Digite o código do livro para adicionar stock: ");
        if (int.TryParse(Console.ReadLine(), out int codigoLivro))
        {
            Livro livroParaAdicionarStock = Livro.livros.Find(livro => livro.Codigo == codigoLivro);

            if (livroParaAdicionarStock != null)
            {
                Console.WriteLine("Livro encontrado: " + livroParaAdicionarStock.Titulo);
                    
                Console.WriteLine("Digite a quantidade de stock a ser adicionada: ");
                if (int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    livroParaAdicionarStock.Stock += quantidade;
                    Console.WriteLine("Stock adicionado com sucesso. Novo stock:  " + livroParaAdicionarStock.Stock);
                }
                else
                {
                    Console.WriteLine("Código inválido. Por favor, insira um código válido.");
                }
            }
            else
            {
                Console.WriteLine("Livro com código " + codigoLivro + " não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        }
    }
}