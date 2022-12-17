using ApiTeste.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Business.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<IEnumerable<Contato>> GetContatoAtivoList();
        Task<Contato> DisableActive(Guid id);
    }

}
