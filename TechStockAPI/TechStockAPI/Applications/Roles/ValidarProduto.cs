using TechStockAPI.Exceptions;
using TechStockAPI.Interfaces;

namespace TechStockAPI.Applications.Roles
{
    public class ValidarProduto
    {
        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new DomainException("Nome é obrigatório!");
            }
        }

        public static void ValidarPreco(decimal preco)
        {
            if (preco <= 0)
            {
                throw new DomainException("Digite um Preço valido!");
            }
        }
    }
}
