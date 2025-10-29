# Sistema de Gestão de Estoque

Este projeto implementa um sistema de gestão de estoque para produtos perecíveis e não-perecíveis.

## Regras de Negócio
- Produtos perecíveis devem ter lote e data de validade
- Não é permitido entrada/saída de quantidade negativa
- Saída só é permitida se houver estoque suficiente
- Produtos abaixo da quantidade mínima geram alerta
- Produto perecível não pode movimentar após data de validade

## Diagrama das Entidades
- Produto: SKU, Nome, Categoria, Preço, Quantidade mínima, Data de criação
- ProdutoPerecivel: herda Produto, adiciona Lote e Data de Validade
- MovimentacaoEstoque: Tipo (ENTRADA/SAIDA), Quantidade, Data, SKUProduto, Lote, DataValidade

## Exemplos de Requisições API
- POST /api/produto
- POST /api/movimentacao
- GET /api/relatorio/valor-total
- GET /api/relatorio/vencendo-em-7-dias
- GET /api/relatorio/abaixo-minimo

## Como Executar
1. Instale o .NET 6 ou superior
2. Execute `dotnet run --project src/Inventory.Api/Inventory.Api.csproj`
3. Acesse a documentação Swagger em `/swagger`

## Evidências
- Todos os commits das etapas estão no repositório
- Tag "versao-final" criada
