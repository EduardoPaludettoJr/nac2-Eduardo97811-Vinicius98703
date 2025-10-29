using System;

namespace Inventory.Api.Models
{
    public enum TipoMovimentacao
    {
        ENTRADA,
        SAIDA
    }

    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string SKUProduto { get; set; }
        // Para perecíveis
        public string Lote { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}
