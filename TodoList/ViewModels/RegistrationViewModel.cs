using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TodoList.ViewModels
{
    public class RegistrationViewModel
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }
        [JsonProperty("pass")]
        [Required]
        public string Password { get; set; }

    }
}
