using System;

namespace Inventory.Api.Models
{
    public enum CategoriaProduto
    {
        PERECIVEL,
        NAO_PERECIVEL
    }

    public class Produto
    {
        public string SKU { get; set; }
        public string Nome { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeMinimaEstoque { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
