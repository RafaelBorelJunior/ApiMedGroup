using ApiTeste.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Data.Data
{
    public class ApiTesteDbContext : DbContext
    {
        public ApiTesteDbContext(DbContextOptions<ApiTesteDbContext> options) : base(options) 
        {
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}

