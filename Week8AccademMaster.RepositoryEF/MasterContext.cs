using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;

namespace Week8AccademMaster.RepositoryEF
{
    internal class MasterContext : DbContext
    {
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }


        public MasterContext()
        {

        }

        public MasterContext(DbContextOptions<MasterContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Scuola;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating ( ModelBuilder  modelBuilder )
        {
            modelBuilder.ApplyConfiguration<Corso>(new ConfigurationCorso());
            modelBuilder.ApplyConfiguration<Studente>(new ConfigurationStudente());
            modelBuilder.ApplyConfiguration<Docente>(new ConfigurationDocente());
            modelBuilder.ApplyConfiguration<Lezione>(new ConfigurationLezione());

        }
    }
}
