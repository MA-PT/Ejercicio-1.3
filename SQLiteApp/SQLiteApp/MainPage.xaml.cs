using SQLiteApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table());

        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Persona persona = new Persona
                {
                    Nombre = nombre.Text,
                    Apellidos = apellido.Text,
                    Edad = Convert.ToInt32(edad.Text),
                    Correo = correo.Text,
                    Direccion = direccion.Text,
                    Fechanac = FNacimiento.Date
                };
                await App.SQLiteDB.SavePersonaAsync(persona);
                nombre.Text = "";
                apellido.Text = "";
                edad.Text = "";
                correo.Text = "";
                direccion.Text = "";
                FNacimiento.Date = DateTime.Now;

                await DisplayAlert("Registro", "Datos guardados correctamente", "Ok");

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(nombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(apellido.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(edad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(correo.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(direccion.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
