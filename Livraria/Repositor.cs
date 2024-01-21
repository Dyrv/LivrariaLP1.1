namespace Livraria;

class Repositor
{
    public static void RegistrarLivro()// Método para registrar um livro
    {
        Console.Clear();
        
        // Variáveis para guardar informações do livro
        string titulo, autor, genero, escolha;
        int cod_livro, isbn, stock;
        double preco, iva;
        
        // Solicitar informações sobre o livro
        Console.WriteLine("Qual é o nome do novo livro? \n");
        titulo = Console.ReadLine();
        Console.WriteLine("Qual é o autor do livro? \n");
        autor = Console.ReadLine();
        Console.WriteLine("Qual é o código do livro? \n");
        escolha = Console.ReadLine();
        if (int.TryParse(escolha, out cod_livro))// Verifica se o código é um número inteiro válido
        {
            Console.WriteLine("ISBN do livro? \n");
            escolha = Console.ReadLine();
            if (int.TryParse(escolha, out isbn))// Verifica se o ISBN é um número inteiro válido
            {
                Console.WriteLine("Qual é o Género do livro? \n");
                genero = Console.ReadLine();
                Console.WriteLine("Qual é o Preço do livro? \n");
                escolha = Console.ReadLine();
                if (double.TryParse(escolha, out preco))// Verifica se o preço é um número decimal válido
                {
                    Console.WriteLine("Qual é o IVA do livro? \n");
                    escolha = Console.ReadLine();
                    if (double.TryParse(escolha, out iva))// Verifica se o IVA inserido é um número decimal válido
                    {
                        stock = 0;// Define o stock como 0
                        if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(autor) || String.IsNullOrEmpty(genero))// Verifica se os campos não estão vazios
                        {
                            Console.WriteLine("Valor inválido!");
                        }
                        else
                        {
                            // Cria um novo objeto Livro
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
                            
                            Livro.livros.Add(novoLivro);// Adiciona o novo livro à lista de livros
                            Console.WriteLine("Livro registrado com sucesso!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido!");
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido!");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido!");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido!");
        }
    }
    
    public static void RemoverLivro()// Método para remover um livro
    {
        Console.Clear();
        Console.WriteLine("Digite o código do livro que deseja remover:");// Solicitar o código do livro a ser removido
        if (int.TryParse(Console.ReadLine(), out int codigoLivro))// Verifica se o código é um número inteiro válido
        {
            Livro livroParaRemover = Livro.livros.Find(livro => livro.Codigo == codigoLivro);// Procura na lista de livros um livro com o código fornecido

            if (livroParaRemover != null)// Verifica se o livro foi encontrado
            {
                Livro.livros.Remove(livroParaRemover);// Remove o livro da lista
                Console.WriteLine("Livro removido com sucesso: " + livroParaRemover.Titulo);// Mensagem de sucesso, indicando o título do livro removido
            }
            else
            {
                Console.WriteLine("Livro com código " + codigoLivro + " não encontrado.");// Mensagem indicando que o código fornecido não foi encontrado
            }
        }
        else
        {
            Console.WriteLine("Código inválido. Por favor, insira um código válido.");// Mensagem caso o código não seja um número inteiro válido
        }
    }
    
    public static void ListarLivrosPorGenero()// Método para listar os livros pelo genero
    {
        Console.Clear();
        Console.WriteLine("Digite o gênero que deseja listar:");// Solicita o gênero que deseja listar
        string generoDesejado = Console.ReadLine();
        
        // Obter apenas livros do gênero desejado, ignorando maiúsculas e minúsculas
        var livrosDoGenero = Livro.livros.Where(livro => livro.Genero.Equals(generoDesejado, StringComparison.OrdinalIgnoreCase)).ToList();

        if (livrosDoGenero.Any())// Verifica se há livros do gênero especificado
        {
            Console.Clear();
            Console.WriteLine("Livros do gênero  " + generoDesejado + ":");
            Console.WriteLine("------------------------");
            foreach (var livro in livrosDoGenero)// Mostrar os livros do gênero
            {
                Console.WriteLine("Título: " + livro.Titulo + "\n Autor: " + livro.Autor + "\n Código: " + livro.Codigo + "\n");
                Console.WriteLine("------------------------");
            }
        }
        else
        {
            // Exibe mensagem que nenhum livro do gênero foi encontrado
            Console.Clear();
            Console.WriteLine("Nenhum livro encontrado do gênero " + generoDesejado + ".");
        }
    }
    public static void AdicionarStock()// Método para adicionar stock a um livro
    {
        Console.WriteLine("Digite o código do livro para adicionar stock: ");// Solicita o código do livro para o qual quer adicionar stock
        if (int.TryParse(Console.ReadLine(), out int codigoLivro))// Converter o código para um número inteiro
        {
            Livro livroParaAdicionarStock = Livro.livros.Find(livro => livro.Codigo == codigoLivro); // Procura na lista de livros um livro com o código fornecido

            if (livroParaAdicionarStock != null)// Verifica se o livro foi encontrado
            {
                Console.WriteLine("Livro encontrado: " + livroParaAdicionarStock.Titulo);// Verifica se o livro foi encontrado
                    
                Console.WriteLine("Digite a quantidade de stock a ser adicionada: ");// Solicita a quantidade de stock a ser adicionado
                if (int.TryParse(Console.ReadLine(), out int quantidade))// Tenta converter a quantidade para um número inteiro
                {
                    livroParaAdicionarStock.Stock += quantidade;// Adiciona a quantidade de stock ao livro
                    Console.WriteLine("Stock adicionado com sucesso. Novo stock:  " + livroParaAdicionarStock.Stock); // Mensagem de sucesso
                }
                else
                {
                    Console.WriteLine("Código inválido. Por favor, insira um código válido.");// Mensagem caso a quantidade não seja um número inteiro válido
                }
            }
            else
            {
                Console.WriteLine("Livro com código " + codigoLivro + " não encontrado.");// Mensagem que o livro com o código fornecido não foi encontrado
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");// Mensagem caso o código do livro não seja um número inteiro válido
        }
    }

    public static void Verificar_Stock()// Método para verificar stock de um livro
    {
        Console.Clear();
        
        // Variáveis para guardar o código do livro
        int cod;
        string escolha;
        
        Console.WriteLine("Insira o código: ");// Solicita o código do livro
        escolha = Console.ReadLine();
        
        if (int.TryParse(escolha, out cod))// Tenta converter o codigo para um número inteiro
        {
            Livro livroStock = Livro.livros.Find(livro => livro.Codigo == cod);// Procura na lista de livros um livro com o código fornecido
            if (livroStock != null)// Verifica se o livro foi encontrado
            {
                Console.WriteLine("Há " + livroStock.Stock + " livros do " + livroStock.Titulo + " em stock");// Mensagem da quantidade de livros em stock para o livro encontrado
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");// Mensagem se o livro com o código fornecido não foi encontrado
            }
        }
        else
        {
            Console.WriteLine("Código inválido!");// Mensagem caso o código do livro não seja um número inteiro válido
        }
    }

    public static void Atualizar_preco_livros()// Método para atualizar preço de um livro
    {
        Console.Clear();
        
        // Variáveis para armazenar o código do livro
        int cod;
        string escolha;
        
        Console.WriteLine("Insira o código: ");// Solicitar o código do livro
        escolha = Console.ReadLine();
        if (int.TryParse(escolha, out cod))// Tenta converter o código para um número inteiro
        {
            Livro livroencontrado = Livro.livros.Find(livro => livro.Codigo == cod);// Procura na lista de livros um livro com o código fornecido
            if (livroencontrado != null)// Verifica se o livro foi encontrado
            {
                Console.WriteLine("Qual preço deseja colocar: ");// Solicita um novo preço
                escolha = Console.ReadLine();
                if (int.TryParse(escolha, out int preco))// Tenta converter o preço para um número inteiro
                {
                    livroencontrado.Preco = preco;// Atualiza o preço do livro
                    Console.WriteLine("Preço atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Preço inválido!");// Mensagem caso o novo preço não seja um número inteiro válido
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");// Mensagem indicando que o livro com o código fornecido não foi encontrado
            }
        }
        else
        {
            Console.WriteLine("Código inválido!");// Mensagem caso o código do livro não seja um número inteiro válido
        }
    }

    public static void ListarLivrosPorAutor()// Método para listar os livros pelo autor
    {
        Console.Clear();
        Console.WriteLine("Digite o autor que deseja procurar:");// Solicita o autor que deseja procurar
        string autorDesejado = Console.ReadLine();

        // Filtra a lista de livros para obter apenas aqueles do autor desejado, ignorando maiúsculas e minúsculas
        var livrosDoAutor = Livro.livros.Where(livro => livro.Autor.Equals(autorDesejado, StringComparison.OrdinalIgnoreCase)).ToList();

        if (livrosDoAutor.Any())// Verifica se há livros do autor especificado
        {
            Console.Clear();
            Console.WriteLine("Livros do autor  " + autorDesejado + ":");
            Console.WriteLine("------------------------");
            foreach (var livro in livrosDoAutor)// Mostrar os livros do autor
            {
                Console.WriteLine("Título: " + livro.Titulo + "\n Género: " + livro.Genero + "\n Código: " + livro.Codigo + "\n");
                Console.WriteLine("------------------------");
            }
        }
        else
        {
            // Mensagem informando que nenhum livro do autor foi encontrado
            Console.Clear();
            Console.WriteLine("Nenhum livro encontrado do autor " + autorDesejado + ".");
        }
    }
}