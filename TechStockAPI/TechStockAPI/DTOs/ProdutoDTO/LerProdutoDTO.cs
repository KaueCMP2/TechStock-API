namespace TechStockAPI.DTOs.ProdutoDTO
{
    public class LerProdutoDTO
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int? Quantidade { get; set; }
    }
}
