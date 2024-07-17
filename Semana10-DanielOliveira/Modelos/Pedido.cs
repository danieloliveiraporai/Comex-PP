using Comex_Modelos.Ordenacoes;

namespace Comex_Modelos.Modelos;

internal class Pedido
{
    public Cliente Cliente { get; }
    public DateTime Data { get; }

    public List<ItemDePedido> Itens = new List<ItemDePedido>();
    public decimal Total { get; set; }

    public static List<Pedido> ListaDePedidos = new List<Pedido>();

    public Pedido(Cliente cliente, DateTime data)
    {
        Cliente = cliente;
        Data = data;
    }

    public void AdcionarItem(ItemDePedido itemDePedido)
    {
        Itens.Add(itemDePedido);
    }

    public decimal CalculaTotal()
    {
        decimal total = 0;

        foreach (var item in Itens)
        {
            total += item.CalculaSubtotal();
        }

        return total;
    }

    public void ListarItens()
    {
        foreach (var item in Itens)
        {
            Console.WriteLine(item);
        }

    }

    public void AdcionarPedidoNaLista(Pedido pedido)
    {
        ListaDePedidos.Add(pedido);
    }

    public static void ListarPedidos()
    {
        var pedidos = ListaDePedidos;
        LinqOrder.OrdenarPedidosPorCliente(pedidos);
    }

    public static decimal CalculaTotalDaListaDePedidos()
    {
        decimal total = 0;

        foreach (var listaDePedidos in ListaDePedidos)
        {
            total += listaDePedidos.CalculaTotal();
        }

        return total;
    }

    public override string ToString()
    {
        Console.WriteLine($"\nCliente: {Cliente} - Data: {Data}");
        ListarItens();
        return $"Total: {CalculaTotal()}";
    }


}
