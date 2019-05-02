using Newtonsoft.Json;

namespace TodoList.BLL.DTO
{
    public class TodoTaskDTO
    {
        [JsonProperty("desc")]
        public string Description { get; set; }
        [JsonProperty("complite")]
        public bool IsComplite { get; set; }
        [JsonProperty("peopleId")]
        public int PeopleId { get; set; }
    }
}
