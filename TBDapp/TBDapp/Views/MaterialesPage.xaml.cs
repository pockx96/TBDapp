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
            cargarlista();
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
                LimpiarCampos();
                await DisplayAlert("Registro", "Se guardo de manera exitosa", "ok");
                Entry_id.IsVisible = false;
                Lista_Materiales1.ItemsSource = null;
                cargarlista();
                SavematerialesLayout.IsVisible = false;
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

     

        private void Btn_ocultar_Clicked(object sender, EventArgs e)
        {
            SavematerialesLayout.IsVisible = false;
            BuscadorLayout.IsVisible = true;
            LimpiarCampos();
            cargarlista();
        }

        public async void cargarlista()
        {
            var MaterialesList = await App.SQLiteDB.GetMateriales();
            if (MaterialesList != null)
            {
                Lista_Materiales1.ItemsSource = MaterialesList;
            }
        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            SavematerialesLayout.IsVisible = true;
            Btn_actualizar_material.IsVisible = false;
            Btn_agregar_material.IsVisible = true;
            BuscadorLayout.IsVisible = false;
        }

        private async void Btn_actualizar_material_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Entry_id.Text))
            {
                Materiales material = new Materiales()
                {
                    id_material = Convert.ToInt32(Entry_id.Text),
                    nombre_material = Entry_nombre.Text,
                    precio_material = Entry_precio.Text

                };
                await App.SQLiteDB.Savemateriales(material);
                LimpiarCampos();
                await DisplayAlert("Registro", "Se guardo de manera exitosa", "ok");

                Lista_Materiales1.ItemsSource = null;
                cargarlista();
                SavematerialesLayout.IsVisible = false;
                Btn_actualizar_material.IsVisible = false;
                BuscadorLayout.IsVisible = true;
            }

        }

        private async void Lista_Materiales1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BuscadorLayout.IsVisible = false;
            Entry_id.IsVisible = true;
            SavematerialesLayout.IsVisible = true;
            Btn_agregar_material.IsVisible = false;
            Btn_actualizar_material.IsVisible = true;
            var obj = (Materiales)e.SelectedItem;
            if(!string.IsNullOrEmpty(obj.id_material.ToString()))
            {
                var materiales = await App.SQLiteDB.GetMaterialesByid(obj.id_material);
                if (materiales!=null)
                {
                    Entry_id.Text = Convert.ToString(materiales.id_material);
                    Entry_nombre.Text = materiales.nombre_material;
                    Entry_precio.Text = materiales.precio_material;
                }
                
            }
        }

        private async  void Btnbusqueda_Clicked(object sender, EventArgs e)
        {
            Materiales obj = new Materiales()
            {
                nombre_material = searchbar.Text
            };

            var materiales = await App.SQLiteDB.GetMaterialesByname(obj.nombre_material);
            if (!string.IsNullOrEmpty(searchbar.Text))
            {
                Lista_Materiales1.ItemsSource = materiales;

            }
            else
            {
                cargarlista();
            }
        }

        public void LimpiarCampos()
        {
            Entry_id.Text = "";
            Entry_nombre.Text = "";
            Entry_precio.Text = "";
        }
    }
}