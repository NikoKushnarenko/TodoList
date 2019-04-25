using Newtonsoft.Json;

namespace TodoList.ViewModels
{
    public class PeopleViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        //public List<TodoTask> Tasks { get; set; }
    }
}
