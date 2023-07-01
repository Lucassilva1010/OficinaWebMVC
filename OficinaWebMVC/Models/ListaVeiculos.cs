using OficinaWebMVC.Atributos;
using OficinaWebMVC.Enums;

namespace OficinaWebMVC.Models
{
    public class ListaVeiculos
    {

        public Guid IdVeiculo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string CodChassi { get; set; }
        public PorteCarro? PorteCarro { get; set; }
        public PorteMoto? PorteMoto { get; set; }
        [NaoValidar]
        public ClienteModel? Cliente { get; set; }
        public string  Modelo { get; set; }
        public string Marca { get; set; }

    }
}
