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

        public int Id { get; set; }

        public string Description { get; set; }
        public bool IsComplite { get; set; }

        public int PeopleId { get; set; }
        public People People { get; set; }

    }
}
