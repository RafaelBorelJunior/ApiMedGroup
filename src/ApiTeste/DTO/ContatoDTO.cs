using ApiTeste.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiTeste.DTO
{
    public class ContatoDTO : Entity
    {
        [Display(Name = "Nome do Contato")]
        public string? NomeContato { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Sexo")]
        public string? Sexo { get; set; }
        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }
    }
}
