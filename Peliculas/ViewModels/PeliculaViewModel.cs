using System;
using System.Collections.Generic;
using System.Text;
using Peliculas.Models;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class PeliculaViewModel : BaseViewModel
    {
        public Pelicula Item { get; set; }
        public PeliculaViewModel(Pelicula item = null)
        {
            Title = item?.Title;
            Item = item;
        }

    }
}
