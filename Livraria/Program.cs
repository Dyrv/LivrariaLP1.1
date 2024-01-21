using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
namespace Livraria;
class Funcionarios
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string Senha { get; set; }
}

class Program
{
    private static string res;
    private static bool veri = true, veri_sai = true;
    public static string cargo;
    private static string resposta; 
    
    public static List<Funcionarios> funcionarios = new List<Funcionarios>
    {
        new Funcionarios { Nome = "Mario", Cargo = "Gerente", Senha = "1234"},
        new Funcionarios { Nome = "Rui", Cargo = "Repositor", Senha = "1313"},
        new Funcionarios { Nome = "Maria", Cargo = "Gerente", Senha = "Lindu11"},
        new Funcionarios { Nome = "Joao", Cargo = "Caixa", Senha = "JA12"},
        new Funcionarios { Nome = "Antonio", Cargo = "Repositor", Senha = "4422"}
    };
    
    public static bool verificar_funcionario(string nome, string senha)
    {
        
        for (int i = 0; i < funcionarios.Count; i++)
        {
            if (funcionarios[i].Nome == nome && funcionarios[i].Senha == senha)
            {
                ArmazenamentoCargo.Cargo = funcionarios[i].Cargo;
                return true;
            }
        }
        return false;
    }



    public static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Insira o seu nome: ");
            string ver_nome = Console.ReadLine();
            Console.WriteLine("Insira a senha: ");
            string ver_senha = Console.ReadLine();

            bool verificar = verificar_funcionario(ver_nome, ver_senha);
            
            if (verificar)
            {
                Console.WriteLine("Acesso permitido!");
                Console.WriteLine("Clique em qualquer tecla para continuar...");
                Console.WriteLine(cargo);
                Console.ReadKey();
                veri = false; // Não é necessário tentar novamente se a verificação for bem-sucedida
                Menu_interface.menu();
            }
            else
            {
                Console.WriteLine("Acesso negado!");
                Console.WriteLine("Quer tentar novamente? (S/N)");
                do
                {
                    resposta = Console.ReadLine().ToUpper(); // Converter a resposta para maiúsculas para facilitar a verificação
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
}//