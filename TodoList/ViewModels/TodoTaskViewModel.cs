using DAL.TodoList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.ViewModels
{
    public class TodoTaskViewModel
    {

        [JsonProperty("desc")]
        public string Description { get; set; }
        [JsonProperty("complite")]
        public bool IsComplite { get; set; }
        [JsonProperty("peopleId")]
        public int PeopleId { get; set; }
    }
}
