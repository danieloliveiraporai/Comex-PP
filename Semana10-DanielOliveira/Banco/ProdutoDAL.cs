using Comex_Modelos.Modelos;

namespace Comex_Modelos.Banco;

public class ProdutoDAL
{
    private readonly ComexContext context;

    public ProdutoDAL(ComexContext context)
    {
        this.context = context;
    }

    public IEnumerable<Produto> Listar()
    {
        return context.Produtos.ToList();       
    }

    public void Adicionar(Produto produto)
    {
        context.Produtos.Add(produto);
        context.SaveChanges();      
    }

    public void Atualizar(Produto produto)
    {
        context.Produtos.Update(produto);
        context.SaveChanges();
    }

    public void Deletar(Produto produto)
    {
        context.Produtos.Remove(produto);
        context.SaveChanges();
    }
}
