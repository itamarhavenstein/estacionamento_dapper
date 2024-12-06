using System.ComponentModel.DataAnnotations.Schema;
using estacionamento.Repositorios;

namespace estacionamento.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [IgnoreInDapper]
        public int Id { get; set; } = default!;
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
    }
}