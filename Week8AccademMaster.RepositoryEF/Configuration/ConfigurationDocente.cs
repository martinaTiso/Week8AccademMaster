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
    internal class ConfigurationDocente : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {

            builder.ToTable("Docente");

            builder.HasKey(k => k.ID);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Cognome).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Telefono).IsRequired();
           

            builder.HasMany(e => e.Lezione).WithOne(e => e.Docente).HasForeignKey(e => e.DocenteID);
        }

    }
  
    }

