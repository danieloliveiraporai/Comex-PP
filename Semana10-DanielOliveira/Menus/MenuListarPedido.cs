using Comex_Modelos.Modelos;

namespace Comex_Modelos.Menus;

internal class MenuListarPedido : MenuPrincipal
{
    public async override Task Executar()
    {
        Console.Clear();
        Pedido.ListarPedidos();
        Console.WriteLine($"\nTotal Geral: {Pedido.CalculaTotalDaListaDePedidos()}");
        Console.WriteLine("");
        Console.WriteLine("Presione uma tecla para voltar ao menu principal");
        Console.ReadKey();
    }
}
