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

                LimpiarDatos();
                await DisplayAlert("Registro", "Se guardo de manera exitosa", "ok");

                Lista_Clientes.ItemsSource = null;
                CargarLista();

                SaveclientesLayout.IsVisible = false;
                BuscadorLayout.IsVisible = true;

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


        private void Btn_ocultar_cliente_Clicked(object sender, EventArgs e)
        {
            SaveclientesLayout.IsVisible = false;
            BuscadorLayout.IsVisible = true;
            CargarLista();
            LimpiarDatos();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            SaveclientesLayout.IsVisible = true;
            Entry_id.IsVisible = false;
            BuscadorLayout.IsVisible = false;

        }

        private async void Btn_actualizar_cliente_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Entry_id.Text))
            {
                Clientes clientes = new Clientes()
                {
                    id_cliente = Convert.ToInt32(Entry_id.Text),
                    nombre_cliente = Entry_Cliente.Text,
                    Auto_cliente = Entry_Autos.Text,
                    Telefono_cliente = Entry_Telefono.Text,
                    Servicio_cliente = Entry_Servicio.Text,
                    Fecha_entrada_cliente = Entry_Fecha_entrada.Text,
                    Fecha_salida_cliente = Entry_Fecha_Salida.Text
                };
                await App.SQLiteDB.SaveClientes(clientes);
                LimpiarDatos();
                await DisplayAlert("Registro", "Se guardo de manera exitosa", "ok");

                Lista_Clientes.ItemsSource = null;
                CargarLista();
                SaveclientesLayout.IsVisible = false;
                Btn_actualizar_cliente.IsVisible = false;
                Entry_id.IsVisible = false;
                BuscadorLayout.IsVisible = true;
            }

        }

        private async void Lista_Clientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Entry_id.IsVisible = true;
            SaveclientesLayout.IsVisible = true;
            Btn_agregar_cliente.IsVisible = false;
            Btn_actualizar_cliente.IsVisible = true;
            BuscadorLayout.IsVisible = false;

            var obj = (Clientes)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.id_cliente.ToString()))
            {
                var clientes = await App.SQLiteDB.GetClientesByid(obj.id_cliente);
                if (clientes != null)
                {
                    Entry_id.Text = Convert.ToString(clientes.id_cliente);
                    Entry_Cliente.Text = clientes.nombre_cliente;
                    Entry_Autos.Text = clientes.Auto_cliente;
                    Entry_Telefono.Text = clientes.Telefono_cliente;
                    Entry_Servicio.Text = clientes.Servicio_cliente;
                    Entry_Fecha_entrada.Text = clientes.Fecha_entrada_cliente;
                    Entry_Fecha_Salida.Text = clientes.Fecha_salida_cliente;
                }

            }
            
        }

        private async void Btnbusqueda_Clicked(object sender, EventArgs e)
        {
            Clientes obj = new Clientes()
            {
                nombre_cliente = searchbar.Text
            };

            var materiales = await App.SQLiteDB.GetClientesByname(obj.nombre_cliente);
            if (!string.IsNullOrEmpty(searchbar.Text))
            {
                Lista_Clientes.ItemsSource = materiales;

            }
            else
            {
                CargarLista();
            }

        }

        public void LimpiarDatos()
        {
            Entry_id.Text = "";
            Entry_Cliente.Text = "";
            Entry_Autos.Text = "";
            Entry_Telefono.Text = "";
            Entry_Servicio.Text = "";
            Entry_Fecha_entrada.Text = "";
            Entry_Fecha_Salida.Text = "";
        }
    }
}