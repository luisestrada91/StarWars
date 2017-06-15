using StarWars.Model;

namespace StarWars.ViewModel
{
    public class DetallePersonajeViewModel : BaseViewModel
    {
        public Personaje Personaje { get; set; }

        public DetallePersonajeViewModel(Personaje personaje)
        {
            Title = personaje.Nombre;
            Personaje = personaje;
        }
    }
}
