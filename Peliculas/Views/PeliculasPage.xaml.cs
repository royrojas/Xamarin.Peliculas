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
    public partial class PeliculasPage : ContentPage
    {
        PeliculasViewModel viewModel;

        public PeliculasPage(PeliculasViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        //public PeliculasPage()
        //{
        //    InitializeComponent();

        //    var item = new Item
        //    {
        //        Titulo = "Categoría",
        //        Api = "Api"
        //    };

        //    viewModel = new PeliculasViewModel(item);
        //    BindingContext = viewModel;
        //}

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Pelicula)layout.BindingContext;
            await Navigation.PushAsync(new PeliculaPage(new PeliculaViewModel(item)));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.CargarDatos();
        }
    }
}