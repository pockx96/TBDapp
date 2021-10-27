using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBDapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBDapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialesPage : ContentPage
    {
        
       

        public MaterialesPage()
        {
            InitializeComponent();
        }

        private async void Btn_agregar_material_Clicked(object sender, EventArgs e)
        {
            if (validar_datos())
            {
                Materiales material = new Materiales()
                {
                    nombre_material = Entry_nombre.Text,
                    precio_material = Entry_precio.Text

                };
                await App.SQLiteDB.Savemateriales(material);
                Entry_nombre.Text = "";
                Entry_precio.Text = "";
                await DisplayAlert("Registro", "Se guardo de manera exitosa", "ok");

            }
            else
            {
                await DisplayAlert("Advertencia","Completa todos los campos","ok");
            }
        }

        public bool validar_datos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(Entry_nombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(Entry_precio.Text))
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