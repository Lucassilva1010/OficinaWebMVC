using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Models
{
    public class ListaVeiculos
    {

        public Guid IdVeiculo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string CodChassi { get; set; }
        public ModeloCarro? ModeloCarro { get; set; }
        public ModeloMoto? ModeloMoto { get; set; }
      
    }
}
