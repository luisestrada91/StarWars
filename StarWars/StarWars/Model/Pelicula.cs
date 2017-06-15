using Newtonsoft.Json;

namespace StarWars.Model
{
    public class Pelicula
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Titulo { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Descripcion { get; set; }

        public string Version { get; set; }
    }
}
