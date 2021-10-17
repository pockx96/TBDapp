using System.ComponentModel;
using TBDapp.ViewModels;
using Xamarin.Forms;

namespace TBDapp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}