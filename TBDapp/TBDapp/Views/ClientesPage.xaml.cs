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
    public partial class presupuestopage : ContentPage
    {




        public presupuestopage()
        {
            InitializeComponent();
            BindingContext = new Materiales();
            CargarLista();

        }

        private async void Btn_agregar_cliente_Clicked(object sender, EventArgs e)
        {
            if (validar_datos())
            {
                Clientes clientes = new Clientes()
                {
                    nombre_cliente = Entry_Cliente.Text,
                    Telefono_cliente = Entry_Telefono.Text,
                    Auto_cliente = Entry_Autos.Text,
                    Servicio_cliente = Entry_Servicio.Text,
                    Fecha_entrada_cliente = Entry_Fecha_entrada.Text,
                    Fecha_salida_cliente = Entry_Fecha_Salida.Text
                 
                };
                await App.SQLiteDB.SaveClientes(clientes);

                Entry_Cliente.Text = "";
                Entry_Telefono.Text = "";
                Entry_Servicio.Text = "";
                Entry_Fecha_entrada.Text = "";
                Entry_Fecha_Salida.Text = "";
                await DisplayAlert("Registro", "Se guardo de manera exitosa", "ok");

                Lista_Clientes.ItemsSource = null;
                CargarLista();

                SaveclientesLayout.IsVisible = false;
                BtnSaveclientes.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Advertencia", "Completa todos los campos", "ok");
            }

        }

        public bool validar_datos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(Entry_Cliente.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(Entry_Telefono.Text))
            {
                respuesta = false;

            }
            else if (string.IsNullOrEmpty(Entry_Servicio.Text))
            {
                respuesta = false;

            }
            else if (string.IsNullOrEmpty(Entry_Fecha_entrada.Text))
            {
                respuesta = false;

            }
            else if (string.IsNullOrEmpty(Entry_Fecha_Salida.Text))
            {
                respuesta = false;

            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async void CargarLista()
        {
            var ClientesList = await App.SQLiteDB.GetClientes();
            if (ClientesList != null)
            {
                Lista_Clientes.ItemsSource = ClientesList;
            }
        }

        private void BtnSaveclientes_Clicked(object sender, EventArgs e)
        {
            BtnSaveclientes.IsVisible = false;
            SaveclientesLayout.IsVisible = true;


        }

        private void Btn_ocultar_cliente_Clicked(object sender, EventArgs e)
        {
            SaveclientesLayout.IsVisible = false;
            BtnSaveclientes.IsVisible = true;
        }
    }
}