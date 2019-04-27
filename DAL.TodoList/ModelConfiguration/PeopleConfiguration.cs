using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.TodoList.ModelConfiguration
{
    class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("People").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(people => people.FullName).HasColumnType("nvarchar(50)").IsRequired();

        }
    }
}
