namespace Comex_Modelos.Modelos;

public class ItemDePedido
{
    public Produto Produto { get; }
    public int Quantidade { get; }
    public decimal PrecoUnitario { get; }
    public decimal Subtotal { get; set; }

    public ItemDePedido(Produto produto, int quantidade, decimal precoUnitario)
    {
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public decimal CalculaSubtotal()
    {
        Subtotal = Quantidade * PrecoUnitario;
        return Subtotal;
    }

    public override string ToString()
    {
        return $"Produto: {Produto} - Quantidade: {Quantidade} - Preço Unitário: {PrecoUnitario} - Subtotal: {CalculaSubtotal()}";
    }
}
