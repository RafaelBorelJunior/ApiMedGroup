using ApiTeste.Business.Interfaces;
using ApiTeste.Business.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Business.Services
{
    public class UtilsServices : IUtilsServices
    {

        public DateTime DataAtual { get; set; } = DateTime.Now;

        public int CalculateAge(DateTime dataNascimento)
        {
            var checkYear = GetYear(dataNascimento);

            return checkYear;
        }
        public IEnumerable<Contato> CalculateAgeList(IEnumerable<Contato> contatosList)
        {
            var ageCalculeteList = new List<Contato>();
            foreach (var contact in contatosList)
            {
                contact.Idade = GetYear(contact.DataNascimento);
                ageCalculeteList.Add(contact);
            }
            return ageCalculeteList;
        }
        public bool CheckDateBirday(DateTime dataNascimento)
        {
            if (dataNascimento > DataAtual) { return false; }
            else { return true; }   
        }
        public bool CheckMajority(DateTime dataNascimento)
        {
            if (GetYear(dataNascimento) < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private int GetYear(DateTime dataNascimento)
        {
            var diference = DataAtual - dataNascimento;
            return diference.Days/365;
        }
    }
}
