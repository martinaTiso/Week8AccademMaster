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
    public class ConfigurationCorso : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {

            builder.ToTable("Corso");

            builder.HasKey(k => k.CodiceCorso);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Descrizione).IsRequired();

            builder.HasMany(e => e.Studenti).WithOne(e => e.Corso).HasForeignKey(e => e.CorsoCodice);
            builder.HasMany(e => e.Lezioni).WithOne(e => e.Corso).HasForeignKey(e => e.CorsoCodice);
        }

    }
}
