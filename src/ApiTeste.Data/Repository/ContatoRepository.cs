using ApiTeste.Business.Interfaces;
using ApiTeste.Business.Models;
using ApiTeste.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ApiTesteDbContext context) : base(context) { }
        public async Task<Contato> DisableActive(Guid id)
        {
            var listcontato = await Db.Contatos.ToListAsync();
            var contato = listcontato.Where(c=>c.Id ==id).FirstOrDefault();
            if (contato.IsAtivo == true) { contato.IsAtivo = false; }
            else { contato.IsAtivo = true; }
            Db.Update(contato);
            await Db.SaveChangesAsync();
            return contato;
        }
        public async Task<IEnumerable<Contato>> GetContatoAtivoList()
        {
            return await Db.Contatos.Where(c => c.IsAtivo == true).ToListAsync();
        }
    }
}
