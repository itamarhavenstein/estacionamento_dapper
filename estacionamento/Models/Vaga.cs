using System.ComponentModel.DataAnnotations.Schema;
using estacionamento.Repositorios;

namespace estacionamento.Models
{
    [Table("vagas")]
    public class Vaga
    {
        [IgnoreInDapper]
        public int Id { get; set; } = default!;
        public string CodigoLocalizacao { get; set; }= default!;
        public bool Ocupada { get; set; } = default!;
    }
}