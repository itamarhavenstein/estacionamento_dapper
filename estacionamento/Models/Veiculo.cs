using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamento.Models
{
    [Table("veiculos")]
    public class Veiculo
    {
        public int Id { get; set; } = default!;
        public string Placa { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public string Marca { get; set; } = default!;
        public int ClienteId { get; set; } = default!;

    }
}