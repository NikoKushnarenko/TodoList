
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
            builder.ToTable("TodoTask", "TodoList");
            builder.HasKey(task => task.Id);

            builder.Property(p => p.IsComplite).IsRequired();
            builder.Property(p => p.Description).HasColumnName("nvarchar(200)").IsRequired();

            builder.HasOne<People>(people => people.People).WithMany(tesk => tesk.Tasks).HasForeignKey(people => people.PeopleId);
        }
    }
}
