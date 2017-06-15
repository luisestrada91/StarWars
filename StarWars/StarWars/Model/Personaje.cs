using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace StarWars.Model
{
    public class Personaje
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Genero { get; set; }

        [JsonProperty(PropertyName = "biography")]
        public string Bio { get; set; }

        [JsonProperty(PropertyName = "height")]
        public float Altura { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string FotoUrl { get; set; }

        [JsonProperty(PropertyName = "weapons")]
        public ObservableCollection<Arma> Armas { get; set; }

        [JsonProperty(PropertyName = "appearances")]
        public ObservableCollection<Pelicula> Peliculas { get; set; }

        public string Version { get; set; }
    }
}
