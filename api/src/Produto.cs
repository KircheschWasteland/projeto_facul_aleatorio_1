namespace ProjetoWeb;

public class Produto
{
    public Produto(string codigo, int quantidade)
    {
        Codigo = codigo;
        Quantidade = quantidade;
    }

    public string Codigo { get; set; } = "";
    public int Quantidade { get; set; }
}