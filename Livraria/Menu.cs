namespace Livraria;
public class Menu_interface// Classe da interface do menu
{
    public static void menu()// Método para exibir o menu
    {
        Console.Clear();
        // Inicializando variáveis
        bool sair = false;
        int opc, opc_sair;
        string escolha;
        
        Console.WriteLine("Bem-vindo ao menu!");
        Console.WriteLine("------------------");
        switch (Armazenamento.Cargo)// Verificar o cargo do usuário
        {
            case "Gerente":
                do
                {
                    // Opções para o Gerente
                    Console.WriteLine("1. Adicionar funcionário");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("2. Remover funcionário");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("3. Listar utilizadores");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("4. Vender livros");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("5. Ver receita");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("6. Sair");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Escolha uma opção: ");
                    escolha = Console.ReadLine();
                    if (int.TryParse(escolha, out opc))
                    {
                        switch (opc)
                        {
                            case 1:
                                Gerente.add_funcionario(); //Chamar o método de adicionar funcionarios
                                break;
                            case 2:
                                Gerente.remove_funcionario(); //Chamar o método de remover funcionarios
                                break;
                            case 3:
                                Console.Clear();
                                //Mostrar todos os utilizadores
                                foreach (var funcionario in Program.funcionarios)
                                {
                                    Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo);
                                }
                                break;
                            case 4:
                                Caixa.venderLivro();//Chamar o método de vender
                                break;
                            case 5:
                                Gerente.ver_receita();//Chamar o método de ver a receita
                                break;
                            case 6:// Opções para sair do programa ou fazer login
                                    Console.Clear();
                                    Console.WriteLine("Deseja fechar o pograma ou fazer login? (1 - Sair / 2 - Login)");// Mensagem a perguntar se deseja sair o programa ou fazer login.
                                    escolha = Console.ReadLine();
                                    if (int.TryParse(escolha, out opc_sair))// Verifica se a escolha pode ser convertida para um número inteiro.
                                    {
                                        if (opc_sair == 1)
                                        {
                                            // Se a escolha for 1, define a variável 'sair' como verdadeira e fecha o programa
                                            sair = true;
                                            Console.WriteLine("Saindo...");
                                        }
                                        else if (opc_sair == 2)
                                        {// Se a escolha for 2, também define 'sair' como verdadeira e chama o método Main() novamente.
                                            sair = true;
                                            Program.Main();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opção inválida. Escolha um número entre as opções dadas.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                                    }
                                    break;
                            default:
                                Console.WriteLine("Opção inválida. Escolha um número entre 1 e 6.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Escolha um número entre 1 e 6.");
                    }
                    Console.Clear();
                } while (!sair);

                break;
            case "Repositor":
                do
                {
                    Console.WriteLine("1. Adicionar livro");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("2. Remover livro");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("3. Listar livros");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("4. Procurar livros");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("5. Procurar por gênero");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("6. Procurar por autor");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("7. Comprar livros");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("8. Verificar stock");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("9. Atualizar preço livros");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("10. Sair");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Escolha uma opção: ");
                    escolha = Console.ReadLine();
                    if (int.TryParse(escolha, out opc))
                    {
                        switch (opc)
                        {
                            case 1:
                                Repositor.RegistrarLivro();
                                break;
                            case 2:
                                Repositor.RemoverLivro();
                                break;
                            case 3:
                                Livro.ListarLivro();
                                break;
                            case 4:
                                Livro.ConsultarLivroPorCodigo();
                                break;
                            case 5:
                                Repositor.ListarLivrosPorGenero();
                                break;
                            case 6:
                                Repositor.ListarLivrosPorAutor();
                                break;
                            case 7:
                                Repositor.AdicionarStock();
                                break;
                            case 8:
                                Repositor.Verificar_Stock();
                                break;
                            case 9:
                                Repositor.Atualizar_preco_livros();
                                break;
                            case 10:
                                Console.Clear();
                                Console.WriteLine("Deseja fechar o pograma ou fazer login? (1 - Sair / 2 - Login)");
                                escolha = Console.ReadLine();
                                if (int.TryParse(escolha, out opc_sair))
                                {
                                    if (opc_sair == 1)
                                    {
                                        sair = true;
                                        Console.WriteLine("Saindo...");
                                    }
                                    else if (opc_sair == 2)
                                    {
                                        sair = true;
                                        Program.Main();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção inválida. Escolha um número entre as opções dadas.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                                }
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Escolha um número entre 1 e 10.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Escolha um número entre 1 e 10.");
                    }
                    Console.Clear();
                } while (!sair);
                break;
            case "Caixa": 
                do
                {
                    Console.WriteLine("1. Vender");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("2. Sair");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Escolha uma opção: ");
                    escolha = Console.ReadLine();
                    if (int.TryParse(escolha, out opc))
                    {
                        switch (opc)
                        {
                            case 1:
                                Caixa.venderLivro();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Deseja fechar o pograma ou fazer login? (1 - Sair / 2 - Login)");
                                escolha = Console.ReadLine();
                                if (int.TryParse(escolha, out opc_sair))
                                {
                                    if (opc_sair == 1)
                                    {
                                        sair = true;
                                        Console.WriteLine("Saindo...");
                                    }
                                    else if (opc_sair == 2)
                                    {
                                        sair = true;
                                        Program.Main();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção inválida. Escolha um número entre as opções dadas.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                                }
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Escolha o número 1 ou 2.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Escolha o número 1 ou 2.");
                    }
                    Console.Clear();
                } while (!sair);
                break;
        }
    }
}