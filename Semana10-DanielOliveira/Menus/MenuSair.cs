namespace Comex_Modelos.Menus
{
    internal class MenuSair : MenuPrincipal
    {
        public async override Task Executar()
        {
            Console.WriteLine("Até mais!");
            Thread.Sleep(1000);
        }
    }
}
