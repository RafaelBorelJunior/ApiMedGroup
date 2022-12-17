using ApiTeste.Business.Interfaces;
using ApiTeste.Business.Models;
using ApiTeste.Data.Repository;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi
{
    public class CadastroTestApi : IClassFixture<IContatoRepository>
    {
        private readonly Mock<IContatoRepository> _mock;
        public CadastroTestApi()
        {
            _mock = new Mock<IContatoRepository>();
        }

        [Fact]
        public async Task Create()
        {
            var contato = new Contato
            {
                NomeContato = "Test",
                DataNascimento = DateTime.Now,
                IsAtivo = true
            };
            
            _mock.Setup(x => x.Add(contato));

            var repo = _mock.Object;

            await repo.Add(contato);
        }
        //[Fact]
        //public async Task GetAll()
        //{
        //    var contatos = await _contatoRepository.GetAll();
        //    var firstContact = contatos.FirstOrDefault();
        //    var product = GetById(firstContact.Id);
        //}
        //private async Task GetById(Guid id)
        //{
        //    await _contatoRepository.GetById(id);
        //}
    }
}
