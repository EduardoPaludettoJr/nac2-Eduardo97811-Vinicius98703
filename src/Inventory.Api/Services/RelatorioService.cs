using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Api.Models;
using Inventory.Api.Data;

namespace Inventory.Api.Services
{
    public class RelatorioService
    {
        private readonly InventoryDbContext _context;
        public RelatorioService(InventoryDbContext context)
        {
            _context = context;
        }

        public decimal ValorTotalEstoque()
        {
            return _context.Produtos.Sum(p => p.QuantidadeMinimaEstoque * p.PrecoUnitario);
        }

        public IEnumerable<Produto> ProdutosVencendoEm7Dias()
        {
            var hoje = DateTime.Now;
            var limite = hoje.AddDays(7);
            return _context.Produtos.Where(p => p is ProdutoPerecivel perecivel && perecivel.DataValidade.HasValue && perecivel.DataValidade.Value <= limite);
        }

        public IEnumerable<Produto> ProdutosAbaixoMinimo()
        {
            return _context.Produtos.Where(p => p.QuantidadeMinimaEstoque > 0 && p.QuantidadeMinimaEstoque > p.QuantidadeMinimaEstoque);
        }
    }
}
