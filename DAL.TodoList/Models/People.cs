using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.TodoList.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public List<TodoTask> Tasks { get; set; }

    }
}
