using ApiTeste.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Business.Interfaces
{
    public interface IUtilsServices
    {
        public IEnumerable<Contato> CalculateAgeList(IEnumerable<Contato> contatosList);
        bool CheckMajority(DateTime dataNascimento);
        public bool CheckDateBirday(DateTime dataNascimento);
        int CalculateAge(DateTime dataNascimento);
    }
}
