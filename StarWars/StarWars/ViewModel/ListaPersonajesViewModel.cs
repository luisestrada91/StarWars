using StarWars.Model;
using StarWars.Servicios;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StarWars.ViewModel
{
    public class ListaPersonajesViewModel : BaseViewModel
    {
        Conexion conexion;

        public ObservableCollection<Personaje> Personajes { get; set; }
        public Command CargarPersonajesCommand { get; set; }

        private string _pagina;

        public string Pagina {
            get { return _pagina; }
            set { SetProperty(ref _pagina, value); }
        }

        public ListaPersonajesViewModel()
        {
            conexion = new Conexion();
            Personajes = new ObservableCollection<Personaje>();
            CargarPersonajesCommand = new Command(async () => await ExecuteCargarPersonajesCommand("hola"));
        }

        async Task ExecuteCargarPersonajesCommand(string algo)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Personajes.Clear();
                //var datos = await conexion.ObtenerPersonajes();
                //var datos = await conexion.ObtenerPersonajes_Orden_Genero_Altura();
                //var datos = await conexion.ObtenerPersonajes_Busqueda("n");
                //var datos = await conexion.ObtenerPersonajes_Pelicula("Star Wars: The Clone Wars");
                //var datos = await conexion.ObtenerPersonajes_Armados();
                if (string.IsNullOrEmpty(Pagina))
                    Pagina = "1";

                var datos = await conexion.ObtenerPersonajes_Paginar(
                    StarWars.Helpers.Constantes.CuantosxPagina, int.Parse(Pagina));

                foreach (var item in datos)
                {
                    Personajes.Add(item);
                }
            }
            catch (Exception ex) { }
            finally { IsBusy = false; }
        }
    }
}
