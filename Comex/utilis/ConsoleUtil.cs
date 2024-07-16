namespace Comex.Utils;

public class ConsoleUtil
{
    public static void PausaELimpaATela()
    {
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
