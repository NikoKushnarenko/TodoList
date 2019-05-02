using Newtonsoft.Json;

namespace TodoList.BLL.DTO
{
    public class PeopleDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

    }
}
