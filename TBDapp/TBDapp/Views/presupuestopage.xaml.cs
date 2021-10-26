using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBDapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class presupuestopage : ContentPage
    {
        private static List<string> materiales = new List<string>
        {
            "tinner","bondo","primer","pintura bicapa","masking tape"
        };

        
        

        public presupuestopage()
        {
            InitializeComponent();


            string buscador = buscador_materiales.Text;


            if (buscador!= null)
            {
                lista_materiales.ItemsSource = from material in materiales where material.StartsWith(buscador) select material;
            }

            lista_materiales.ItemsSource = materiales;
   
            
        }
    }
}