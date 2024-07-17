namespace Comex_Modelos.Menus;

/// <summary>
/// Classe que comtém o método executar que cria o menu principal
/// </summary>
public class MenuPrincipal
{
    /// <summary>
    /// Método que cria o menu principal e chama todos os menus para o usúario poder utilizar todas as funcionalidaades da aplicação.
    /// </summary>
    public async virtual Task Executar()
    {
        await ExibeMenuPrincipal();
    }

    async Task ExibeMenuPrincipal()
    {
        Console.Clear();

        Dictionary<int, MenuPrincipal> opcao = new();
        opcao.Add(1, new MenuCriarProduto());
        opcao.Add(2, new MenuListarProduto());
        opcao.Add(3, new MenuAtualizarProduto());
        opcao.Add(4, new MenuDeletarProduto());
        opcao.Add(5, new MenuListarProdutosDaApiExterna());
        opcao.Add(6, new MenuCriarPedido());
        opcao.Add(7, new MenuListarPedido());
        opcao.Add(8, new MenuSair());

        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Criar Produto");
        Console.WriteLine("2 - Listar Produtos");
        Console.WriteLine("3 - Atualizar Produto");
        Console.WriteLine("4 - Deletar Produto");
        Console.WriteLine("5 - Listar Produtos da API Externa");
        Console.WriteLine("6 - Criar Pedido");
        Console.WriteLine("7 - Listar Pedidos");
        Console.WriteLine("8 - Sair\n");
        string leOpcao = Console.ReadLine()!;
        int leOpcaoNumerica = int.Parse(leOpcao);

        if (opcao.ContainsKey(leOpcaoNumerica))
        {
            MenuPrincipal menuPrincipal = opcao[leOpcaoNumerica];
            await menuPrincipal.Executar();

            if (leOpcaoNumerica != 8)
            {
                await Executar();
            }
        }
        else
        {
            Console.WriteLine("Opção Inválida");
        }
    }
}
