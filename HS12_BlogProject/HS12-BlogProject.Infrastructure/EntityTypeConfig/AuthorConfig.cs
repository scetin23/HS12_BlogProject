using HS12_BlogProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Infrastructure.EntityTypeConfig
{
    internal class AuthorConfig: BaseEntityConfig<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.ID); 
			builder.Property(x => x.FirstName).IsRequired(); 
			builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired(false); 
			base.Configure(builder);
        }

    }
}
