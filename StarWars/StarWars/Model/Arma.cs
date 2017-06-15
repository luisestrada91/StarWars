using Newtonsoft.Json;

namespace StarWars.Model
{
    public class Arma
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Descripcion { get; set; }

        public string Version { get; set; }
    }
}
