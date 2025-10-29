using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Api.Models;
using Inventory.Api.Data;

namespace Inventory.Api.Services
{
    public class ProdutoService
    {
        private readonly InventoryDbContext _context;
        public ProdutoService(InventoryDbContext context)
        {
            _context = context;
        }

        public void ValidarProduto(Produto produto)
        {
            if (produto.Categoria == CategoriaProduto.PERECIVEL && produto is ProdutoPerecivel perecivel)
            {
                if (string.IsNullOrEmpty(perecivel.Lote) || !perecivel.DataValidade.HasValue)
                    throw new Exception("Produtos perecíveis devem ter lote e data de validade");
            }
        }

        public IEnumerable<Produto> ProdutosAbaixoMinimo()
        {
            return _context.Produtos.Where(p => p.QuantidadeMinimaEstoque > 0 && p.QuantidadeMinimaEstoque > p.QuantidadeMinimaEstoque);
        }

        public void CadastrarProduto(Produto produto)
        {
            ValidarProduto(produto);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
    }

    public class ProdutoPerecivel : Produto
    {
        public string Lote { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}
