using OficinaWebMVC.Database.Entities;
using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Models
{
    public class VeiculoCarroModel
    {

        public string Placa { get; set; }
        public int Ano { get; set; }
        public string CodChassi { get; set; }
        public ModeloCarro ModeloCarro { get; set; }
        public Guid IdCliente { get; set; }

    }
}
