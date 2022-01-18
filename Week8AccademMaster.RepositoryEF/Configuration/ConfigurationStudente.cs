using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;

namespace Week8AccademMaster.RepositoryEF
{
    internal class ConfigurationStudente : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {

            builder.ToTable("Studente");

            builder.HasKey(k => k.ID);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Cognome).IsRequired();
            builder.Property(c => c.DataNascita).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.TitoloStudio).IsRequired();

            builder.HasOne(r => r.Corso).WithMany(p => p.Studenti).HasForeignKey(k => k.CorsoCodice);
        }

    }
}
