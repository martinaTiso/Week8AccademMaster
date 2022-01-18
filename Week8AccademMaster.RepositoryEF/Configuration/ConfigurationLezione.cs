using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AccademMaster.Core.Entities;

namespace Week8AccademMaster.RepositoryEF
{
    internal class ConfigurationLezione : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {

            builder.ToTable("Lezione");

            builder.HasKey(k => k.LezioneID);
         
            builder.Property(c => c.OrarioInizio).IsRequired();
            builder.Property(c => c.Durata).IsRequired();
            builder.Property(c => c.Aula).IsRequired();


            builder.HasOne(e => e.Corso).WithMany(s => s.Lezioni).HasForeignKey(s => s.CorsoCodice).HasConstraintName("Fk_Corso");
            builder.HasOne(e => e.Docente).WithMany(s => s.Lezione).HasForeignKey(s => s.CorsoCodice).HasConstraintName("Fk_Docente");
            
        }
    }
}

        
    

