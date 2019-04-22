using Newtonsoft.Json;

namespace PetStore.CodeFirst.Models
{
    [JsonObject("Dog")]
    public class DogViewModel : PetViewModel
    {
        public int? PackSize { get; set; }
    }
}
