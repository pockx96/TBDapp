using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBDapp.ViewModels;
using TBDapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBDapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        String user { get; set; }
        String pass { get; set; }
       
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            Entry_user.Text = "";
            Entry_pass.Text = "";
            Carga_de_datos();
            user = Usuario.nombre_usuario;
            pass = Usuario.pass_usuario;

        }

        

        Usuarios Usuario = new Usuarios()
        {
            nombre_usuario = "admin",
            pass_usuario = "pass"

        };


        private async void Carga_de_datos()
        {
            
            await App.SQLiteDB.SaveUsuarios(Usuario);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (validador())
            {
                if (Entry_user.Text == user && Entry_pass.Text == pass)
                {
                    await Shell.Current.GoToAsync($"//{nameof(MaterialesPage)}");
                }
                else
                {
                    await DisplayAlert("Advertencia","Usuario o contraseña incorrectos","ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "rellene todos los campos", "ok");
            }
           
        }
        
        private bool validador()
        {
            if (string.IsNullOrEmpty(Entry_user.Text))
            {
                return false;

            }
            else if (string.IsNullOrEmpty(Entry_pass.Text))
            {
                return false;
            }
            return true;

        }

        
    }
}