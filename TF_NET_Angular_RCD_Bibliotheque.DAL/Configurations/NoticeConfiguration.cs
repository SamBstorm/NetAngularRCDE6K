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
    public class NoticeConfiguration : IEntityTypeConfiguration<Notice>
    {
        public void Configure(EntityTypeBuilder<Notice> builder)
        {
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Title).HasMaxLength(100);
            builder.Property(n => n.Note).IsRequired();
            builder.HasOne<Customer>(n => n.Customer).WithMany(c => c.Notices).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Movie>(n => n.Movie).WithMany(m => m.Notices).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
