using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.TodoList.Models
{ 
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsComplite { get; set; }
        [ForeignKey("TaskInfoKey")]
        public int PeopleId { get; set; }
        public People People { get; set; }

    }
}
