namespace Livraria;

class Repositor
{
    public static void RegistrarLivro()// Método para registrar um livro
    {
        Console.Clear();
        
        string titulo, autor, genero, escolha;
        int cod_livro, isbn, stock;
        double preco, iva;
        
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
                            Console.WriteLine("Clique em qualquer tecla para continuar...");
                            Console.ReadKey();
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
                            Console.WriteLine("Clique em qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido!");
                        Console.WriteLine("Clique em qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido!");
                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Valor inválido!");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Valor inválido!");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
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
                Console.WriteLine("Livro removido com sucesso: " + livroParaRemover.Titulo);
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Livro com código " + codigoLivro + " não encontrado.");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Código inválido. Por favor, insira um código válido.");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
    
    public static void ListarLivrosPorGenero()// Método para listar os livros pelo genero
    {
        Console.Clear();
        Console.WriteLine("Digite o gênero que deseja listar:");
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
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
        else
        {
            // Exibe mensagem que nenhum livro do gênero foi encontrado
            Console.Clear();
            Console.WriteLine("Nenhum livro encontrado do gênero " + generoDesejado + ".");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
    public static void AdicionarStock()// Método para adicionar stock a um livro
    {
        Console.WriteLine("Digite o código do livro para adicionar stock: ");
        if (int.TryParse(Console.ReadLine(), out int codigoLivro))// Converter o código para um número inteiro
        {
            Livro livroParaAdicionarStock = Livro.livros.Find(livro => livro.Codigo == codigoLivro); // Procura na lista de livros um livro com o código fornecido

            if (livroParaAdicionarStock != null)// Verifica se o livro foi encontrado
            {
                Console.WriteLine("Livro encontrado: " + livroParaAdicionarStock.Titulo);
                    
                Console.WriteLine("Digite a quantidade de stock a ser adicionada: ");
                if (int.TryParse(Console.ReadLine(), out int quantidade))// Tenta converter a quantidade para um número inteiro
                {
                    livroParaAdicionarStock.Stock += quantidade;// Adiciona a quantidade de stock ao livro
                    Console.WriteLine("Stock adicionado com sucesso. Novo stock:  " + livroParaAdicionarStock.Stock); 
                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Código inválido. Por favor, insira um código válido.");
                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Livro com código " + codigoLivro + " não encontrado.");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void Verificar_Stock()// Método para verificar stock de um livro
    {
        Console.Clear();
        
        // Variáveis para guardar o código do livro
        int cod;
        string escolha;
        
        Console.WriteLine("Insira o código: ");
        escolha = Console.ReadLine();
        
        if (int.TryParse(escolha, out cod))// Tenta converter o codigo para um número inteiro
        {
            Livro livroStock = Livro.livros.Find(livro => livro.Codigo == cod);// Procura na lista de livros um livro com o código fornecido
            if (livroStock != null)// Verifica se o livro foi encontrado
            {
                Console.WriteLine("Há " + livroStock.Stock + " livros do " + livroStock.Titulo + " em stock");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Código inválido!");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void Atualizar_livro()// Método para atualizar preço de um livro
    {
        Console.Clear();
        bool veri = true;
        int cod;
        int iva;
        string escolha;
        
        Console.WriteLine("Insira o código: ");
        escolha = Console.ReadLine();
        if (int.TryParse(escolha, out cod))// Tenta converter o código para um número inteiro
        {
            Livro livroencontrado = Livro.livros.Find(livro => livro.Codigo == cod);// Procura na lista de livros um livro com o código fornecido
            if (livroencontrado != null)// Verifica se o livro foi encontrado
            {
                Console.WriteLine("Qual preço deseja colocar: ");
                escolha = Console.ReadLine();
                if (double.TryParse(escolha, out double preco))// Tenta converter o preço para um número inteiro
                {
                    livroencontrado.Preco = preco;// Atualiza o preço do livro
                    Console.WriteLine("Preço atualizado com sucesso!");
                    Console.WriteLine("Deseja atualizar o IVA? (S/N)");//Perguntar se quer atualizar o IVA
                    escolha = Console.ReadLine().ToUpper();
                    if (escolha == "S")
                    {
                        do
                        {
                            Console.WriteLine("Qual IVA deseja colocar: (6%/23%)");
                            escolha = Console.ReadLine();
                            if (int.TryParse(escolha, out iva)) // Tenta converter o iva para um número inteiro
                            {
                                if (iva == 6)// Alterar o iva para 6%
                                {
                                    livroencontrado.IVA = 0.06;
                                    Console.WriteLine("IVA alterado com sucesso!");
                                    veri = false;
                                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                                    Console.ReadKey();
                                }
                                else if (iva == 23)// Alterar o iva para 23%
                                {
                                    livroencontrado.IVA = 0.23;
                                    Console.WriteLine("IVA alterado com sucesso!");
                                    veri = false;
                                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Escolha um opção válida: ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Escolha um opção válida: ");
                            }
                        } while (veri);
                    }
                    else
                    {
                        Console.WriteLine("Clique em qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Preço inválido!");
                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Código inválido!");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void ListarLivrosPorAutor()// Método para listar os livros pelo autor
    {
        Console.Clear();
        Console.WriteLine("Digite o autor que deseja procurar:");
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
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nenhum livro encontrado do autor " + autorDesejado + ".");
            Console.WriteLine("Clique em qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}