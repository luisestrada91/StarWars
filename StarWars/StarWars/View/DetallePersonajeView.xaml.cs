using StarWars.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarWars.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePersonajeView : ContentPage
    {
        DetallePersonajeViewModel viewModel;

        public DetallePersonajeView(DetallePersonajeViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            BindingContext = this.viewModel;
        }
    }
}
