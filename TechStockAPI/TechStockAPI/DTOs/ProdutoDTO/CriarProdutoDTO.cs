namespace TechStockAPI.DTOs.ProdutoDTO
{
    public class CriarProdutoDTO
    {
        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int? Quantidade { get; set; }
    }
}
