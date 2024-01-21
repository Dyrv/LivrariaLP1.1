namespace Livraria;

public class Caixa
{
    public static int codigoLivro;
    public static double total, total_iva, lucro, qnt_livros;
    public static double iva;
    public static double desconto;
    public static int qnt, cont;
    public static bool veri;
    
    //Funcao para vender livros
    public static void venderLivro()
    {
        cont = 1;
        total = 0;
        total_iva = 0;
        veri = true;
        Console.Clear();
        do
        {
            Console.WriteLine("Insira o código do livro: (Caso não queira inserir mais nenhum, insira 0)");
            string escolha = Console.ReadLine();
            if (int.TryParse(escolha, out codigoLivro))
            {
                if (codigoLivro == 0)
                {
                    if (cont == 1)
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
                    Livro livroEncontrado = Livro.livros.Find(livro => livro.Codigo == codigoLivro);

                    if (livroEncontrado != null)
                    {
                        if (livroEncontrado.Stock != 0)
                        {
                            Console.WriteLine("Quantos quer vender: ");
                            if (int.TryParse(Console.ReadLine(), out qnt))
                            {
                                if (qnt <= livroEncontrado.Stock)
                                {
                                    qnt_livros += qnt;
                                    livroEncontrado.Stock = livroEncontrado.Stock - qnt;
                                    iva = livroEncontrado.IVA * livroEncontrado.Preco;
                                    total = total + (livroEncontrado.Preco * qnt);
                                    total_iva = total_iva + (iva * qnt);
                                    Console.WriteLine("*" + qnt + " ," + livroEncontrado.Titulo + ", " +
                                                      livroEncontrado.IVA * 100 + "%, " + livroEncontrado.Preco);
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
                    else if (livroEncontrado == null)
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

        if (cont > 1)
        {
            if (total >= 50)
            {
                desconto = total * 0.1;
                total = total - Math.Round(desconto, 2);
                lucro += total;
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