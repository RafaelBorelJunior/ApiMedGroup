using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Business.Models
{
    public class Contato : Entity
    {
        public string? NomeContato { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public bool IsAtivo { get; set; }
        [NotMapped]
        public int Idade { get; set; }
    }
}
