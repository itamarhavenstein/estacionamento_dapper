using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamento.Models
{
    [Table("clientes")]
    public class Cliente
    {
        public int Id { get; set; } = default!;
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
    }
}