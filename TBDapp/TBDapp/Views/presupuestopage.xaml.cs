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
            
        }
    }
}