using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Database.Entities;

public class Servico:Entidade
{
    public string Descricao { get; set; }
    public string Observacao { get; set; }
    public decimal Preco { get; set; }
    public TipoServico TipoServico { get; set; }
    public List<Orcamento> Orcamentos { get; set; }
}
