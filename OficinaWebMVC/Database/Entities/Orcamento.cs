using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Database.Entities;

public class Orcamento:Entidade
{
    public Veiculo Veiculo { get; set; }
    public DateTime DataInicialOrcamento { get; set; }
    public DateTime? DataAprovacaoCliente { get; set; }
    public DateTime DataFinalOrcamento { get; set; }
   public DateTime DataPrazoOrcamento { get; set; }
    public decimal ValorTotal { get; set; }
    public Cliente Cliente { get; set; }
    public string  Responsavel { get; set; }
    public string CpfResponsavel { get; set; }
    public StatusOrcamento StatusOrcamento { get; set; }
    public List<Servico> Servicos { get; set; }


}
