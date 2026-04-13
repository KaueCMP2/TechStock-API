using TechStockAPI.Contexts;
using TechStockAPI.Domains;
using TechStockAPI.Interfaces;

namespace TechStockAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly TechStockDbContext _context;
        public ProdutoRepository(TechStockDbContext context)
        {
            _context = context;
        }

        public List<Produto> Listar()
        {
            return _context.Produto.OrderBy(p => p.Nome).ToList();
        }

        public Produto ObterPorId(int id)
        {
            return _context.Produto.Find(id);
        }

        public bool ProdutoExiste(string? nome = null, int? id = null)
        {
            return _context.Produto.FirstOrDefault(p => p.Nome == nome || p.ProdutoId == id) != null;
        }

        public void Adicionar(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            if (produto == null) return;

            Produto produtoBanco = _context.Produto.FirstOrDefault(p => p.ProdutoId == produto.ProdutoId);
            if (produtoBanco == null) return;

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Descricao = produto.Descricao;
            produtoBanco.Quantidade = produto.Quantidade;
            produtoBanco.Preco = produto.Preco;

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null) return;
            _context.Remove(produto);
            _context.SaveChanges();
        }
    }
}
