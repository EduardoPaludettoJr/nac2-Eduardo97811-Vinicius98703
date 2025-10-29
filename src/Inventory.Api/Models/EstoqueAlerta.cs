namespace Inventory.Api.Models
{
    public class EstoqueAlerta
    {
        public string SKUProduto { get; set; }
        public int QuantidadeAtual { get; set; }
        public int QuantidadeMinima { get; set; }
        public bool Alerta { get; set; }
    }
}
