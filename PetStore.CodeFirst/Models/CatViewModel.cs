using Newtonsoft.Json;

namespace PetStore.CodeFirst.Models
{
    [JsonObject("Cat")]
    public class CatViewModel : PetViewModel
    {
        public double? WhiskersLength { get; set; }
    }
}
