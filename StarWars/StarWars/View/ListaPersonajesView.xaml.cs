using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StarWars.ViewModel;
using StarWars.Model;

namespace StarWars.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPersonajesView : ContentPage
    {
        ListaPersonajesViewModel viewModel;

        public ListaPersonajesView()
        {
            InitializeComponent();

            viewModel = new ListaPersonajesViewModel();
            BindingContext = viewModel; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Personajes.Count == 0)
                viewModel.CargarPersonajesCommand.Execute("valor");
        }

        private async void lsvPersonajes_ItemSelected(object sender, 
            SelectedItemChangedEventArgs e)
        {
            var personaje = e.SelectedItem as Personaje;

            if (personaje != null)
            {
                DetallePersonajeViewModel viewModel = 
                    new DetallePersonajeViewModel(personaje);

                await Navigation.PushAsync(new DetallePersonajeView(viewModel));
            }

            lsvPersonajes.SelectedItem = null;
        }
    }
}
