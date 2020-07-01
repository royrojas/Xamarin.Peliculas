using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peliculas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Peliculas.Models;
using Peliculas.ViewModels;

namespace Peliculas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeliculaPage : ContentPage
    {
        PeliculaViewModel viewModel;

        public PeliculaPage()
        {
            InitializeComponent();

            var item = new Pelicula
            {
                Title = "Item 1"
            };

            viewModel = new PeliculaViewModel(item);
            BindingContext = viewModel;
        }

        public PeliculaPage(PeliculaViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}