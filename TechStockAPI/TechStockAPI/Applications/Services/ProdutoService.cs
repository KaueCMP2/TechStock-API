using TechStockAPI.Applications.Roles;
using TechStockAPI.Domains;
using TechStockAPI.DTOs.ProdutoDTO;
using TechStockAPI.Exceptions;
using TechStockAPI.Interfaces;

namespace TechStockAPI.Applications.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository) => _repository = repository;

        public List<LerProdutoDTO> Listar()
        {
            List<Produto> produtos = _repository.Listar();
            if (produtos == null)
                throw new DomainException("Nenhum produto encontrado");

            List<LerProdutoDTO> produtosDTOs = produtos.Select(produto => new LerProdutoDTO
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            }).ToList();

            return produtosDTOs;
        }

        public LerProdutoDTO ObterPorId(int id)
        {
            Produto produto = _repository.ObterPorId(id);
            if (produto == null)
                throw new DomainException("Produto não encontrado!");

            LerProdutoDTO produtoDTO = new LerProdutoDTO
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            };

            return produtoDTO;
        }

        public void Adicionar(CriarProdutoDTO dto)
        {
            ValidarProduto.ValidarNome(dto.Nome);
            ValidarProduto.ValidarPreco(dto.Preco);
            Produto produtoCriado = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Quantidade = dto.Quantidade
            };

            _repository.Adicionar(produtoCriado);
        }

        public void Atualizar(int id, AtualizarProdutoDTO dto)
        {
            ValidarProduto.ValidarNome(dto.Nome);
            ValidarProduto.ValidarPreco(dto.Preco);

            Produto produtoBanco = _repository.ObterPorId(id);

            if (produtoBanco == null)
                throw new DomainException("Produto não encontrado!");

            produtoBanco.Nome = dto.Nome;
            produtoBanco.Preco = dto.Preco;
            produtoBanco.Descricao = dto.Descricao;
            produtoBanco.Quantidade = dto.Quantidade;

            _repository.Atualizar(produtoBanco);
        }

        public void Deletar(int id)
        {
            if (id < 0)
                throw new DomainException("Digite um id valido");

            if (!_repository.ProdutoExiste(null, id))
                throw new DomainException("Produto não encontrado!");

            _repository.Deletar(id);
        }
    }
}
