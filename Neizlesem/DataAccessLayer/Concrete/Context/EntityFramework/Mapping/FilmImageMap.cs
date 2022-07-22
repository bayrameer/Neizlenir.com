using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework.Mapping
{
    public class FilmImageMap
        : IEntityTypeConfiguration<FilmImage>
    {
        
        public void Configure(EntityTypeBuilder<FilmImage> builder)
        {
            builder
               .HasOne(x => x.Film)
               .WithMany(x => x.FilmImages)
               .HasForeignKey(x => x.FilmId);
        }
    }
}
