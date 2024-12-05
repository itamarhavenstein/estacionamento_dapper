using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamento.Models
{
    [Table("vagas")]
    public class Vaga
    {
        public int Id { get; set; } = default!;
        public string CodigoLocalizacao { get; set; }= default!;
        public bool Ocupada { get; set; } = default!;
    }
}