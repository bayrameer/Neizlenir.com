using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework.Mapping
{
    public class FilmMap : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.Property(x => x.Name).HasColumnName("FilmName").HasColumnType("nvarchar(50)").IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
