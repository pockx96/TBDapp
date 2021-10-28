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

        public async void CargarLista()
        {
            var MaterialesList = await App.SQLiteDB.GetMateriales();
            if (MaterialesList != null)
            {
                Lista_Materiales.ItemsSource = MaterialesList;
            }
        }
    }
}