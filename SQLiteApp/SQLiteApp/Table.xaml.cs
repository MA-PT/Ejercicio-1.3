using SQLiteApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table : ContentPage
    {
        public Table()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var lista = await App.SQLiteDB.GetPersonaAsync();
            if (lista != null)
            {
                lstPersonas.ItemsSource = lista;
            }

        }

        private async void lstPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Persona)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.Id.ToString()))
            {
                var persona = await App.SQLiteDB.GetPersonaByIdAsync(obj.Id);
                if (persona != null)
                {

                    Persona person = new Persona
                    {
                        Id = persona.Id,
                        Nombre = persona.Nombre,
                        Apellidos = persona.Apellidos,
                        Edad = persona.Edad,
                        Correo = persona.Correo,
                        Direccion = persona.Direccion,
                        Fechanac = persona.Fechanac
                    };

                    var detalles = new Detalles();
                    detalles.BindingContext = person;
                    await Navigation.PushAsync(detalles);
                }
            }
        }
    }
}