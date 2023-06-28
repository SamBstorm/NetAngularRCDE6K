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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Firstname).IsRequired();
            builder.Property(c => c.Firstname).HasMaxLength(50);
            builder.Property(c => c.Lastname).IsRequired();
            builder.Property(c => c.Lastname).HasMaxLength(50);
            builder.Property(c => c.Pseudo).IsRequired();
            builder.Property(c => c.Pseudo).HasMaxLength(50);
            builder.HasIndex(c => c.Pseudo).IsUnique();
            builder.HasMany(c => c.Notices).WithOne(n => n.Customer).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
