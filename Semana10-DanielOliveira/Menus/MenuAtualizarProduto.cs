using Comex_Modelos.Banco;
using Comex_Modelos.Modelos;

namespace Comex_Modelos.Menus;

internal class MenuAtualizarProduto : MenuPrincipal
{
    public async override Task Executar()
    {
        Console.WriteLine("\nDigite o id do produto a ser atualizado:");
        string leIdProduto = Console.ReadLine()!;
        int leIdProdutoNumerico = int.Parse(leIdProduto);

        Console.WriteLine("\nDigite o novo nome do produto:");
        string leNomeProduto = Console.ReadLine()!;

        Console.WriteLine("\nDigite o novo preço do produto:");
        string lePrecoProduto = Console.ReadLine()!;
        decimal lePrecoProdutoNumerico = decimal.Parse(lePrecoProduto);

        Console.WriteLine("\nDigite a nova quantidade do produto:");
        string leQuantidadeProduto = Console.ReadLine()!;
        int leQuantidadeProdutoNumerico = int.Parse(leQuantidadeProduto);

        Produto produto = new Produto(leNomeProduto, leQuantidadeProdutoNumerico, lePrecoProdutoNumerico) { Id = leIdProdutoNumerico }; ;

        var context = new ComexContext(); 
        new ProdutoDAL(context).Atualizar(produto);
        
        Console.WriteLine("\nProduto Atualizado com Sucesso!");
        Thread.Sleep(1000);
        Console.Clear();
    }
}
