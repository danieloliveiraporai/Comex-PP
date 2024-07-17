using Comex_Modelos.Modelos;

namespace Comex_Modelos.Menus;

internal class MenuCriarPedido : MenuPrincipal
{
    public async override Task Executar()
    {
        Console.WriteLine("\nDigite o nome do cliente:");
        string leNomeDoCliente = Console.ReadLine()!;

        Console.WriteLine("\nDigite o nome do produto:");
        string leNomeProduto = Console.ReadLine()!;

        Console.WriteLine("\nDigite a quantidade do produto:");
        string leQuantidadeProduto = Console.ReadLine()!;
        int leQuantidadeProdutoNumerico = int.Parse(leQuantidadeProduto);

        Console.WriteLine("\nDigite o preço do produto:");
        string lePrecoProduto = Console.ReadLine()!;
        decimal lePrecoProdutoNumerico = decimal.Parse(lePrecoProduto);

        Cliente cliente = new Cliente(leNomeDoCliente);
        Produto produto = new Produto(leNomeProduto, leQuantidadeProdutoNumerico, lePrecoProdutoNumerico);
        ItemDePedido itemDePedido = new ItemDePedido(produto, produto.Quantidade, produto.Preco);
        Pedido pedido = new(cliente, DateTime.Now);
        pedido.AdcionarItem(itemDePedido);

        bool opcao = true;

        while (opcao == true)
        {
            Console.WriteLine("\nDeseja adcionar mais um item na lista?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não\n");
            string resposta = Console.ReadLine()!;
            int respostaNumerica = int.Parse(resposta);

            if (respostaNumerica == 1)
            {
                Console.WriteLine("\nDigite o nome do produto:");
                string leNomeProduto2 = Console.ReadLine()!;

                Console.WriteLine("\nDigite a quantidade do produto:");
                string leQuantidadeProduto2 = Console.ReadLine()!;
                int leQuantidadeProdutoNumerico2 = int.Parse(leQuantidadeProduto2);

                Console.WriteLine("\nDigite o preço do produto:");
                string lePrecoProduto2 = Console.ReadLine()!;
                decimal lePrecoProdutoNumerico2 = decimal.Parse(lePrecoProduto2);

                Produto produto2 = new Produto(leNomeProduto2, leQuantidadeProdutoNumerico2, lePrecoProdutoNumerico2);
                ItemDePedido itemDePedido2 = new ItemDePedido(produto2, produto2.Quantidade, produto2.Preco);
                pedido.AdcionarItem(itemDePedido2);
            }
            else
            {
                opcao = false;
            }
        }

        pedido.CalculaTotal();
        pedido.AdcionarPedidoNaLista(pedido);
        Console.WriteLine("\nPedido Criado com Sucesso!");
        var pedidos = pedido.ListarItens;
        Thread.Sleep(1000);
        Console.Clear();
    }
}

