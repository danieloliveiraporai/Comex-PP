using Comex_Modelos.Modelos;

namespace Comex_Modelos.Ordenacoes;

internal class LinqOrder
{
    public static void OrdenarProdutosPorNome(List<Produto> produtos)
    {

        Console.Clear();

        var produtosOrdenados = produtos.OrderBy(produto => produto.Nome).ToList();

        foreach (var produto in produtosOrdenados)
        {
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Preço: {produto.Preco}");
            Console.WriteLine($"Quantidade: {produto.Quantidade}\n");
        }
    }

    public static void OrdenarProdutosPorPreco(List<Produto> produtos)
    {
        Console.Clear();

        var produtosOrdenados = produtos.OrderBy(produto => produto.Preco).ToList();

        foreach (var produto in produtosOrdenados)
        {
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Preço: {produto.Preco}");
            Console.WriteLine($"Quantidade: {produto.Quantidade}\n");
        }
    }

    public static void OrdenarPedidosPorCliente(List<Pedido> pedidos)
    {
        var pedidosOrdenados = pedidos.OrderBy(pedido => pedido.Cliente.Nome).ToList();
        Console.WriteLine("Lista de Pedidos Ordenados Por Cliente:");

        foreach (var pedido in pedidosOrdenados)
        {
            Console.WriteLine(pedido);
        }
    }
}
