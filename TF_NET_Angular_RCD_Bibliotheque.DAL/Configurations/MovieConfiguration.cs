using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Title).HasMaxLength(100);
            builder.HasIndex(m => m.Title).IsUnique();
            builder.HasMany(m => m.Notices).WithOne(n => n.Movie).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
