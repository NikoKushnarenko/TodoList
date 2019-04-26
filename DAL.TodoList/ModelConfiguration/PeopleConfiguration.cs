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
            builder.ToTable("People", "TodoList");

            builder.HasKey(people => people.Id);

            builder.Property(people => people.FullName).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
