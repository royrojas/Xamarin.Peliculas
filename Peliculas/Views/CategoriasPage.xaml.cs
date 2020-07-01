using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peliculas.Models;
using Peliculas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Peliculas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriasPage : ContentPage
    {
        CategoriasViewModel viewModel;

        public CategoriasPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriasViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new PeliculasPage(new PeliculasViewModel(item)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
