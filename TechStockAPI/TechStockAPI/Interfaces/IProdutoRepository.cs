using System.Collections.Generic;
using TechStockAPI.Domains;

namespace TechStockAPI.Interfaces
{
    public interface IProdutoRepository
    {
        public List<Produto> Listar();
        public Produto ObterPorId(int id);
        public bool ProdutoExiste(string? nome = null, int? id = null);
        public void Adicionar(Produto produto);
        public void Atualizar(Produto produto);
        public void Deletar(int id);
    }
}
