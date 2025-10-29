using System;
using System.Linq;
using Inventory.Api.Models;
using Inventory.Api.Data;

namespace Inventory.Api.Services
{
    public class MovimentacaoService
    {
        private readonly InventoryDbContext _context;
        public MovimentacaoService(InventoryDbContext context)
        {
            _context = context;
        }

        public void RegistrarMovimentacao(MovimentacaoEstoque mov)
        {
            if (mov.Quantidade <= 0)
                throw new Exception("Quantidade deve ser positiva");

            var produto = _context.Produtos.FirstOrDefault(p => p.SKU == mov.SKUProduto);
            if (produto == null)
                throw new Exception("Produto não encontrado");

            if (mov.Tipo == TipoMovimentacao.SAIDA)
            {
                // Verifica estoque suficiente
                // ...implementar lógica de saldo...
            }

            if (produto.Categoria == CategoriaProduto.PERECIVEL)
            {
                if (!mov.DataValidade.HasValue || string.IsNullOrEmpty(mov.Lote))
                    throw new Exception("Movimentação de perecível requer lote e validade");
                if (mov.DataValidade.Value < DateTime.Now)
                    throw new Exception("Produto perecível não pode movimentar após validade");
            }

            _context.Movimentacoes.Add(mov);
            _context.SaveChanges();
        }
    }
}
