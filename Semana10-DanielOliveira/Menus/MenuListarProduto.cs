using Comex_Modelos.Banco;
using Comex_Modelos.Modelos;

namespace Comex_Modelos.Menus;

internal class MenuListarProduto : MenuPrincipal
{
    public async override Task Executar()
    {
        try
        {
            Console.WriteLine("\nLista de Produtos:\n");

            var context = new ComexContext();
            var listaProdutos = new ProdutoDAL(context).Listar();

            foreach (var produto in listaProdutos)
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine("\nPresione uma tecla para voltar ao menu principal");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
