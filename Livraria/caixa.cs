namespace Livraria;

public class Caixa
{
    public static double codigoLivro;
    public static double dinheiro;
    public double lucro;
    public double iva;
    
    public void venderLivro()
    {
        
        Livro livroEncontrado = Livro.livros.Find(livro => livro.Codigo == codigoLivro);

        if (livroEncontrado != null)
        {
            if (livroEncontrado.Stock > 0)
            {
                dinheiro = dinheiro + livroEncontrado.Preco;
                lucro = lucro + ((1 - livroEncontrado.IVA) * dinheiro);
                iva = iva + (livroEncontrado.IVA * dinheiro);

            }
        }
        else
        {
            Console.WriteLine("O livro " + livroEncontrado.Titulo + " Nao esta em stock");
        }
        
        
    }
    
}