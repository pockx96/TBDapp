using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBDapp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBDapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            
            
            btntest.Clicked += (sender, e) =>
            {
                string error;
                LoginViewModel conexion = new LoginViewModel(entry_user.Text,entry_pass.Text);
                if (conexion.TryConnection(out error))
                {
                    DisplayAlert("Lo logramos","somos la mera verga","apoco no?");
                }
                else
                {
                    DisplayAlert("Error","falla en la coneccion","ok");
                }
            };
        }

      
    }
}