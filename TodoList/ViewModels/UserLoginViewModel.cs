using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.ViewModels
{
    public class UserLoginViewModel
    {
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }
        [JsonProperty("pass")]
        [Required]
        public string Password { get; set; }
    }
}
