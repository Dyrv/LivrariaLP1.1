namespace Livraria;

public class Caixa
{
    public static double codigoLivro;
    public static double total, total_iva, lucro, qnt_livros;
    public static double iva;
    public static double desconto;
    public static int qnt;
    public static bool veri;
    
    public static void venderLivro()
    {
        total = 0;
        total_iva = 0;
        veri = true;
        Console.Clear();
        do
        {
            Console.WriteLine("Insira o código do livro: (Caso não queira inserir mais nenhum, insira 0)");
            codigoLivro = Convert.ToDouble(Console.ReadLine());
            if (codigoLivro != 0)
            {
                Livro livroEncontrado = Livro.livros.Find(livro => livro.Codigo == codigoLivro);

                if (livroEncontrado != null)
                {
                    if (livroEncontrado.Stock != 0)
                    {
                        Console.WriteLine("Quantos quer vender: ");
                        qnt = Convert.ToInt32(Console.ReadLine());
                        if (qnt <= livroEncontrado.Stock)
                        {
                            qnt_livros += qnt;
                            livroEncontrado.Stock = livroEncontrado.Stock - qnt;
                            iva = livroEncontrado.IVA * livroEncontrado.Preco;
                            total = total + (livroEncontrado.Preco * qnt);
                            total_iva = total_iva + (iva * qnt);
                            Console.WriteLine("*" + qnt + " ," + livroEncontrado.Titulo + ", " + livroEncontrado.IVA * 100 + "%, " + livroEncontrado.Preco);
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
                else if (livroEncontrado == null)
                {
                    Console.WriteLine("O livro não existe!");
                }
            }
            else
            {
                veri = false;
            }
        } while (veri);
        if (total >= 50)
        {
            desconto = total * 0.1;
            total = total - desconto;
            lucro += total;
            Console.WriteLine("Venda concluida!");
            Console.WriteLine("O desconto foi de " + desconto);
            Console.WriteLine("O valor do IVA foi de: " + total_iva);
            Console.WriteLine("O valor final foi de " + total);
            Console.WriteLine("Pressione qualquer tecla...");
            Console.ReadKey();
        }
        else
        {
            lucro += total;
            Console.WriteLine("Venda concluida!");
            Console.WriteLine("O valor do IVA foi de: " + total_iva);
            Console.WriteLine("O valor final foi de " + total);
            Console.ReadKey();
        }
    }
}