using System.ComponentModel.DataAnnotations.Schema;
using estacionamento.Repositorios;

namespace estacionamento.Models
{
    [Table("veiculos")]
    public class Veiculo
    {
        [IgnoreInDapper]
        public int Id { get; set; } = default!;
        public string Placa { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public string Marca { get; set; } = default!;
        [IgnoreInDapper]
        public int ClienteId { get; set; } = default!;

    }
}