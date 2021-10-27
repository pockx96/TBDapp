using System;
using TBDapp.Services;
using TBDapp.Views;
using TBDapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace TBDapp
{
    public partial class App : Application
    {
        static SqliteHelper bd; 

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }


        public static SqliteHelper SQLiteDB
        {

            get
            {
                if (bd == null)
                {
                    bd = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Taller.db3"));

                }
                return bd;
            }
            
            
        }

       

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
