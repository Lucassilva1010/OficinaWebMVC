using OficinaWebMVC.Database.Entities;
using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Models
{
    public class VeiculoMotoModel
    {

        public string Placa { get; set; }
        public int Ano { get; set; }
        public string CodChassi { get; set; }
        public ModeloMoto ModeloMoto { get; set; }
        public Guid IdCliente { get; set; }

    }
}
