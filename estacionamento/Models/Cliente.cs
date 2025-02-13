using System.ComponentModel.DataAnnotations.Schema;
using estacionamento.Repositorios;

namespace estacionamento.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [IgnoreInDapper]
        public int Id { get; set; } = default!;
        [Column("nome")]
        public string Nome { get; set; } =  default!;
        [Column("cpf")]
        public string Cpf { get; set; } =  default!;
    }
}