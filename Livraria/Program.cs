using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
namespace Livraria;


class Funcionarios // Classe para os funcionários
{
    public string Nome { get; set; } // Nome do funcionário
    public string Cargo { get; set; } // Cargo do funcionário
    public string Senha { get; set; } // Senha do funcionário
}


class Program // Classe principal
{
    private static bool veri = true;     // Variável para o verificar se o utlizador quer sair do loop
    private static bool veri_sai = true; // Variável para o loop se o utlizador quer continuar ou não
    public static string cargo;          // Variável para armazenar o cargo do funcionário
    private static string resposta; // Variável temporária para a resposta do utilizador
    
    public static List<Funcionarios> funcionarios = new List<Funcionarios>// Lista de funcionários
    {
        new Funcionarios { Nome = "Mario", Cargo = "Gerente", Senha = "1234"},
        new Funcionarios { Nome = "Rui", Cargo = "Repositor", Senha = "1313"},
        new Funcionarios { Nome = "Maria", Cargo = "Gerente", Senha = "Lindu11"},
        new Funcionarios { Nome = "Joao", Cargo = "Caixa", Senha = "JA12"},
        new Funcionarios { Nome = "Antonio", Cargo = "Repositor", Senha = "4422"}
    };
    
    public static bool verificar_funcionario(string nome, string senha)// Função para verificar se o funcionário existe
    {
        
        for (int i = 0; i < funcionarios.Count; i++)
        {
            if (funcionarios[i].Nome == nome && funcionarios[i].Senha == senha)
            {
                Armazenamento.Cargo = funcionarios[i].Cargo;// Armazenar o cargo do funcionário
                Armazenamento.Nome = funcionarios[i].Nome;// Armazenar o nome do funcionário
                return true;
            }
        }
        return false;
    }


// Função principal
    public static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Insira o seu nome: ");
            string ver_nome = Console.ReadLine();
            Console.WriteLine("Insira a senha: ");
            string ver_senha = Console.ReadLine();
            
            // Verificar se o funcionário existe
            bool verificar = verificar_funcionario(ver_nome, ver_senha);
            
            if (verificar)
            {
                Console.WriteLine("Acesso permitido!");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.WriteLine(cargo);
                Console.ReadKey();
                veri = false; // Não é necessário tentar novamente se a verificação for bem-sucedida
                Menu_interface.menu();// Ir para o menu
            }
            else
            {
                Console.WriteLine("Acesso negado!");
                Console.WriteLine("Quer tentar novamente? (S/N)");
                do
                {
                    resposta = Console.ReadLine().ToUpper(); // Converter a resposta para maiúsculas
                    if (resposta == "S")
                    {
                        veri_sai = true;
                        veri = true;
                    }
                    else if(resposta == "N")
                    {
                        veri_sai = true;
                        veri = false;
                    }
                    else
                    {
                        Console.WriteLine("Escolha um opção válida: ");
                    }
                } while (!veri_sai);
            }
        } while (veri);
    }
}