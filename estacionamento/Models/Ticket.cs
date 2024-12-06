using System.ComponentModel.DataAnnotations.Schema;
using estacionamento.Repositorios;

namespace estacionamento.Models
{
    [Table("tickets")]
    public class Ticket
    {
        [IgnoreInDapper]
        public int Id { get; set; } = default!;
        public DateTime DataEntrada { get; set; } = default!;
        public DateTime? DataSaida { get; set; }
        public float Valor { get; set; }= default!;
        [IgnoreInDapper]
        public int VeiculoId { get; set; }= default!;
        public int VagaId { get; set; }= default!;
    }
}