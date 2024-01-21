namespace Livraria;
public class Menu_interface
{
    public static Gerente ger_func = new Gerente();
    public static void menu()
    {
        Console.Clear();
        bool sair = false;
        int opc, opc_sair;
        string escolha;
        Console.WriteLine("Bem-vindo ao menu!");
        Console.WriteLine("------------------");
        switch (ArmazenamentoCargo.Cargo)
        {
            case "Gerente":
                do
                {
                    Console.WriteLine("1. Adicionar funcionário");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("2. Remover funcionário");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("3. Listar");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("4. Sair");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Escolha uma opção: ");
                    escolha = Console.ReadLine();
                    if (int.TryParse(escolha, out opc))
                    {
                        switch (opc)
                        {
                            case 1:
                                Gerente.add_funcionario();
                                break;
                            case 2:
                                Gerente.remove_funcionario();
                                break;
                            case 3:
                                foreach (var funcionario in Program.funcionarios)
                                {
                                    Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo);
                                }
                                break;
                            case 4:
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
                                Console.WriteLine("Opção inválida. Escolha um número entre 1 e 4.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
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
                    Console.WriteLine("6. Comprar livros");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("7. Sair");
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
                                Repositor.AdicionarStock();
                                break;
                            case 7:
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
                                Console.WriteLine("Opção inválida. Escolha um número entre 1 e 4.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Escolha um número entre 1 e 4.");
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                } while (!sair);
                break;
            case "Caixa": 
                break;
        }
    }
}