namespace Livraria
{
    public class Gerente
    {
        private static string nome;
        private static string senha;
        private static string cargo;
        private static int opc;
        //Funcao para adicionar funcionarios 
        public static void add_funcionario()
        {
            Console.Clear();
            Console.WriteLine("Tem a certeza? S/N");
            char a = Convert.ToChar(Console.ReadLine().ToUpper());
            if (a == 'S')
            {
                //Escolha de cargo do funcionario
                Console.WriteLine("Qual é o cargo do Funcionario? \n 1-Gerente \n 2-Caixa \n 3-Repositor \n");
                opc = int.Parse(Console.ReadLine());
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
                
                Funcionarios novoFuncionario = new Funcionarios
                {
                    Nome = nome,
                    Cargo = cargo,
                    Senha = senha
                };

                Program.funcionarios.Add(novoFuncionario);
            }
        }
        public static void remove_funcionario()
        {
            Console.WriteLine("Tem a certeza? S/N");
            char a = Convert.ToChar(Console.ReadLine().ToUpper());
            if (a == 'S')
            {
                foreach (var funcionario in Program.funcionarios)
                {
                    Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo);
                }
                Console.WriteLine("Qual quer remover? ");
                string nomeParaRemover = Console.ReadLine();
        
                // Encontrar o funcionário na lista pelo nome
                Funcionarios result = Program.funcionarios.Find(n => n.Nome == nomeParaRemover);

                if (result!= null)
                {
                    Program.funcionarios.Remove(result);
                }
                else
                {
                    Console.WriteLine("Elemento não encontrado");
                }
            }
            foreach (var funcionario in Program.funcionarios)
            {
                Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo);
            }
        }
    }
}//