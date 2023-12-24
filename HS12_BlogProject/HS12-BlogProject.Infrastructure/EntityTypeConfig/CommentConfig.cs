using HS12_BlogProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Infrastructure.EntityTypeConfig
{
    internal class CommentConfig : BaseEntityConfig<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.AppUser) 
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Post) 
                .WithMany(x=> x.Comments)
                .HasForeignKey(x=>x.PostID)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
