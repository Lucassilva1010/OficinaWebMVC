using OficinaWebMVC.Database.Entities;
using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Models
{
    public class OrcamentoModel
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public Guid IdVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public decimal ValorTotal { get; set; }
        public string Responsavel { get; set; }
        public string CpfResponsavel { get; set; }
        public StatusOrcamento StatusOrcamento { get;  set; }
        public List<ServicoModel> Servicos { get; set; }
        public DateTime PrazoOrcamento { get; set; }

    }
}
