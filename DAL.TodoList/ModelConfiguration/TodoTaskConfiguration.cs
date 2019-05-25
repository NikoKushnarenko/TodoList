
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.TodoList.ModelConfiguration
{
    class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.ToTable("TodoTask").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.IsComplite).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            builder.HasOne<AppUser>(people => people.AppUser).WithMany(tesk => tesk.Tasks).HasForeignKey(people => people.AppUserId);

        }
    }
}
