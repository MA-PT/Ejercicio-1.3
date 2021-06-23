using SQLiteApp.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalles : ContentPage
    {
        public Detalles()
        {
            InitializeComponent();
        }

        private async void userUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id.Text))
            {
                Persona persona = new Persona()
                {
                    Id = Convert.ToInt32(id.Text),
                    Nombre = nombre.Text,
                    Apellidos = apellido.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Correo = correo.Text,
                    Direccion = direccion.Text,
                    Fechanac = FNacimiento.Date
                };

                await App.SQLiteDB.SavePersonaAsync(persona);
                await DisplayAlert("Registro", "Datos actualizados correctamente", "Ok");
                id.IsVisible = false;
            }
        }

        private async void userDelete_Clicked(object sender, EventArgs e)
        {
            var persona = await App.SQLiteDB.GetPersonaByIdAsync(Convert.ToInt32(id.Text));

            if (persona != null)
            {
                await App.SQLiteDB.DeletePersonaAsync(persona);
                await DisplayAlert("Exitoso", "Datos eliminado correctamente", "Ok");
                LimpiarControles();
                await Navigation.PopAsync();
                id.IsVisible = false;
            }
        }

        public void LimpiarControles()
        {
            id.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            correo.Text = "";
            direccion.Text = "";
            FNacimiento.Date = DateTime.Now;
        }
    }
}