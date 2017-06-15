using System.Threading.Tasks;
using StarWars.Model;
using System.IO;
using System.Reflection;
using StarWars.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarWars.Servicios
{
    public class Conexion
    {
        private async Task<List<Personaje>> ObtenerPersonajesArchivo()
        {
            var assembly = typeof(Conexion).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(Constantes.Archivo);
            string json;

            using (var streamReader = new StreamReader(stream))
            {
                json = await streamReader.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<List<Personaje>>(json);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes()
        {
            var datos = await ObtenerPersonajesArchivo();
            var personajes = datos;
            return new ObservableCollection<Personaje>(personajes);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes_Orden_Alfabetico()
        {
            var datos = await ObtenerPersonajesArchivo();

            /*var personajes = (from p in datos
                             orderby p.Nombre descending
                             select p).ToList();*/
            var personajes = datos.OrderByDescending(p => p.Nombre).ToList();

            return new ObservableCollection<Personaje>(personajes);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes_Orden_Genero_Altura()
        {
            var datos = await ObtenerPersonajesArchivo();

            /*var personajes = (from p in datos
                             orderby p.Genero, p.Altura descending
                             select p).ToList();*/

            var personajes = datos.OrderBy(p => p.Genero).ThenByDescending(p => p.Altura).ToList();

            return new ObservableCollection<Personaje>(personajes);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes_Busqueda(string busqueda)
        {
            var datos = await ObtenerPersonajesArchivo();

            var personajes = datos.Where(x => x.Nombre.Contains(busqueda)).ToList();
            //var personajes = datos.Where(x => x.Nombre == busqueda).ToList();
            //var personajes = datos.Where(x => x.Nombre.StartsWith(busqueda)).ToList();
            //var personajes = datos.Where(x => x.Nombre.EndsWith(busqueda)).ToList();
            /*var personajes = (from x in datos
                             where x.Nombre.Contains(busqueda) // Busqueda LIKE '%abc%'
                             //where x.Nombre == busqueda  //Busqueda Exacta
                             //where x.Nombre.StartsWith(busqueda) // Busqueda LIKE 'abc%'
                             //where x.Nombre.EndsWith(busqueda) // Busqueda LIKE '%abc'
                              select x).ToList();*/

            return new ObservableCollection<Personaje>(personajes);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes_Pelicula(string pelicula)
        {
            var datos = await ObtenerPersonajesArchivo();
            //var personajes = datos.Where(p => p.Peliculas.Any(t => t.Titulo == pelicula)).ToList();
            var personajes = datos.Where(
                                        p => p.Peliculas
                                            .Where(t => t.Titulo == pelicula).Count() 
                                        > 0).ToList();

            //var personajes = datos.Where(p => p.Peliculas == pelicula).ToList();

            return new ObservableCollection<Personaje>(personajes);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes_Armados()
        {
            var datos = await ObtenerPersonajesArchivo();

            var personajes = datos.Where(x => x.Armas.Count > 0).ToList();
            /*var personajes = (from x in datos
                              where x.Armas.Count > 0
                              select x).ToList();*/

            return new ObservableCollection<Personaje>(personajes);
        }

        public async Task<ObservableCollection<Personaje>> ObtenerPersonajes_Paginar(int cuantos, int pagina)
        {
            var datos = await ObtenerPersonajesArchivo();
            var personajes = datos.Skip(cuantos * (pagina - 1)).Take(cuantos).ToList();
            return new ObservableCollection<Personaje>(personajes);
        }








    }
}
