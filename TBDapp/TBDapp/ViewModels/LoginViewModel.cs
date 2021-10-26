using System;
using System.Collections.Generic;
using System.Text;
using TBDapp.Views;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

namespace TBDapp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        string user;
        string pass;
        public LoginViewModel(string us, string pas)
        {
            us = user;
            pas = pass;
            

        }



        MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
        public bool TryConnection(out string error)
        {
            Builder.Port = 3306;
            //Al ser una BD Online debes usar la ip de tu servidor y no localhost
            Builder.Server = "127.0.0.1";
            Builder.Database = "classicbd";
            Builder.UserID = user; //Es el usuario de la base de datos
            Builder.Password = pass; //La contraseña del usuario

            try
            {
                MySqlConnection ms = new MySqlConnection(Builder.ToString());
                ms.Open();
                error = "";
                return true;
            }
            catch (Exception ex)
            {
                error = ex.ToString()+" valio verga";
                return false;
            }
        }
    }
}
