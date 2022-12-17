using ApiTeste.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTeste.ViewModels
{
    public class ContatoViewModel : Entity
    {
        [Display(Name = "Nome do Contato")]
        public string? NomeContato { get; set; }
        [Display(Name = "Data de Nascimento")]
        public string? Sexo { get; set; }
        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }
        [Display(Name = "Idade")]
        public int Idade { get; set; }
    }
}
