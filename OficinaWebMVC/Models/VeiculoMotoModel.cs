using OficinaWebMVC.Database.Entities;
using OficinaWebMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace OficinaWebMVC.Models
{
    public class VeiculoMotoModel
    {

        public string Placa { get; set; }
        public int Ano { get; set; }
        public string CodChassi { get; set; }
       
        public PorteMoto PorteMoto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Guid IdCliente { get; set; }

    }
}
