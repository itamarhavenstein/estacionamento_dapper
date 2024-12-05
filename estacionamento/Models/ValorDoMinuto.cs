using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamento.Models
{
    [Table("valores")]
    public class ValorDoMinuto
    {
        public int Id { get; set; } = default!;
        public int Minutos { get; set; } = default!;
        public float Valor { get; set; } = default!;
    }
}