using Microsoft.EntityFrameworkCore;
using Practica4.Models;

namespace Practica4.Data
{
    public class AgendaDbContexc : DbContext
    {
        public AgendaDbContexc(DbContextOptions<AgendaDbContexc> options) : base(options)
        { 
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
       

    }
}
