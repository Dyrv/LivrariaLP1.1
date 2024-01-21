namespace Livraria;

public class Caixa
{
    public static int codigoLivro;
    public static double total, total_iva, lucro, qnt_livros;
    public static double iva;
    public static double desconto;
    public static int qnt, cont;
    public static bool veri;
    
    
    public static void venderLivro() //Método para vender livros
    {
        cont = 0;
        total = 0;
        total_iva = 0;
        veri = true;
        Console.Clear();
        do //Estrutura ciclica de verificação/conclusão de venda
        {
            Console.WriteLine("Insira o código do livro: (Caso não queira inserir mais nenhum, insira 0)");
            string escolha = Console.ReadLine();
            if (int.TryParse(escolha, out codigoLivro))// Verifica se o código é um número inteiro válido
            {
                if (codigoLivro == 0)
                {
                    if (cont == 0)
                    {
                        veri = false;
                        Console.WriteLine("Venda cancelada!");
                    }
                    else
                    {
                        veri = false;
                    }
                }
                if (codigoLivro != 0)
                {
                    Livro livroEncontrado = Livro.livros.Find(livro => livro.Codigo == codigoLivro);//Função que procura o livro pelo codigo na lista de livros

                    if (livroEncontrado != null)
                    {
                        if (livroEncontrado.Stock != 0)
                        {
                            Console.WriteLine("Quantos quer vender: ");
                            if (int.TryParse(Console.ReadLine(), out qnt)) //Funcao que testa se o numero inserido de livros é um inteiro
                            {
                                if (qnt <= livroEncontrado.Stock)//Se a quantidade pedida para vender for menor ou igual á do stock do livro 
                                {
                                    qnt_livros += qnt;//adiciona a quantidade de livros a quantidade de livros vendidos
                                    livroEncontrado.Stock = livroEncontrado.Stock - qnt;//Retira os livros que serão vendidos ao stock
                                    iva = livroEncontrado.IVA * livroEncontrado.Preco;//Calcula o iva do preço do livro
                                    total = total + (livroEncontrado.Preco * qnt);//Calcula o preço total da quantidade de livros pedida do mesmo
                                    total_iva = total_iva + (iva * qnt);//Calcula o total do iva que está incluso nos livros
                                    Console.WriteLine("*" + qnt + " ," + livroEncontrado.Titulo + ", " +
                                                      livroEncontrado.IVA * 100 + "%, " + livroEncontrado.Preco);//Mostra o titulo o iva do livro e o preço
                                    cont++;
                                }
                                else if (qnt == 0)
                                {
                                    Console.WriteLine("A quantidade tem que ser maior que 0");
                                }
                                else
                                {
                                    Console.WriteLine("Não existe stock o sufciente!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("O livro " + livroEncontrado.Titulo + " Nao esta em stock");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido!");
                        }
                    }
                    else if (livroEncontrado == null)//se o livro não existir imprimir não existe
                    {
                        Console.WriteLine("O livro não existe!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Código inválido");
            }
        } while (veri);

        if (cont > 0) //Se for inserido algum livro
        {
            if (total >= 50) //verificar se o total é maior que 50€, se sim, vai fazer um desconto de 10%
            {
                desconto = total * 0.1; //calcular o desconto
                total = total - Math.Round(desconto, 2);//aplicar o desconto
                lucro += total;//acrecentar o total ao lucro 
                Console.WriteLine("Venda concluida!");
                Console.WriteLine("O desconto foi de " + Math.Round(desconto, 2));
                Console.WriteLine("O valor do IVA foi de: " + Math.Round(total_iva, 2));
                Console.WriteLine("O valor final foi de " + total);
            }
            else
            {
                lucro += total;
                Console.WriteLine("Venda concluida!");
                Console.WriteLine("O valor do IVA foi de: " + Math.Round(total_iva, 2));
                Console.WriteLine("O valor final foi de " + total);
            }
        }
    }
}