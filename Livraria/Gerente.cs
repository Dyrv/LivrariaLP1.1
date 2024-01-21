namespace Livraria;
    public class Gerente
    {
        private static string nome;
        private static string senha;
        private static string cargo;
        private static int opc;
        //Funcao para adicionar funcionarios 
        public static void add_funcionario()
        {
            string escolha;
            Console.Clear();
            
                //Escolha de cargo do funcionario
                Console.WriteLine("Qual é o cargo do Funcionario? \n 1-Gerente \n 2-Caixa \n 3-Repositor \n");
                escolha = Console.ReadLine();
                if (int.TryParse(escolha, out opc))
                {
                    switch (opc)
                    {
                        case 1:
                            cargo = "Gerente";
                            break;
                        case 2:
                            cargo = "Caixa";
                            break;
                        case 3:
                            cargo = "Repositor";
                            break;

                    }

                    //Inscricao do nome do funcionario
                    Console.WriteLine("Qual é o nome do novo funcionário? \n");
                    nome = Console.ReadLine();
                    //Inscricao da senha do funcionario
                    Console.WriteLine("Qual é a Senha do novo funcionário? \n");
                    senha = Console.ReadLine();
                    if (String.IsNullOrEmpty(nome))
                    {
                        Console.WriteLine("Valor não inserido!");
                        Console.WriteLine("Clique em qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    else if (String.IsNullOrEmpty(senha))
                    {
                        Console.WriteLine("Valor não inserido!");
                        Console.WriteLine("Clique em qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Funcionarios novoFuncionario = new Funcionarios
                        {
                            Nome = nome,
                            Cargo = cargo,
                            Senha = senha
                        };
                        Program.funcionarios.Add(novoFuncionario);
                        Console.WriteLine("Funcionário adicionado com sucesso!");
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
        //Funcao para remover funcionarios
        public static void remove_funcionario()
        {
            Console.Clear();
            foreach (var funcionario in Program.funcionarios)
            {
                Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo);
            }
            Console.WriteLine("Qual quer remover? ");
            string nomeParaRemover = Console.ReadLine();
            if (String.IsNullOrEmpty(nomeParaRemover))
            {
                Console.WriteLine("Valor não inserido!");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                if (nomeParaRemover == Armazenamento.Nome)
                {
                    Console.WriteLine("Não pode remover a si mesmo!");
                    Console.WriteLine("Clique em qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    // Encontrar o funcionário na lista pelo nome
                    Funcionarios result = Program.funcionarios.Find(n => n.Nome == nomeParaRemover);
                    if (result != null)
                    {
                        Program.funcionarios.Remove(result);
                        foreach (var funcionario in Program.funcionarios)
                        {
                            Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo);
                            Console.WriteLine("Clique em qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Elemento não encontrado");
                        Console.WriteLine("Clique em qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
        }
        //Funcao para ver a receita e quantidade de livros vendidos
        public static void ver_receita()
        {
            Console.Clear();
            if (Caixa.qnt_livros != 0)
            {
                Console.WriteLine("Quantidade de livros vendidos: " + Caixa.qnt_livros);
                Console.WriteLine("Lucro de vendas: " + Math.Round(Caixa.lucro, 2));
                Console.WriteLine("\nClique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nenhum livro vendido!");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }