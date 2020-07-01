using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Peliculas.Models;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class PeliculasViewModel : BaseViewModel
    {
        private string _urlApiBase = "https://api.themoviedb.org";
        //private string _apiKey = "a690bf18050ecf2071cd98b5c42f514a";
        //private string _language = "es-ES";

        public Item Item { get; set; }

        public ObservableCollection<Pelicula> Datos { get; } = new ObservableCollection<Pelicula>(
            new Pelicula[] { CARGANDO }
        );

        public PeliculasViewModel(Item item = null)
        {
            Title = item?.Titulo;
            Item = item;

            RefrescarCommand = new Command(async () => {

                IsBusy = true;
                await CargarDatos();
                IsBusy = false;
            });
        }

        public Command RefrescarCommand { get; set; }

        private static Pelicula CARGANDO = new Pelicula { Title = "Cargando" };

        public async Task CargarDatos()
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                Datos.Clear();

                var http = new HttpClient()
                {
                    BaseAddress = new Uri(_urlApiBase)
                };
                
                string json = await http.GetStringAsync(Item.Api);
                
                var data = JsonConvert.DeserializeObject<Models.Peliculas>(json);

                foreach (var item in data.Results)
                {
                    Datos.Add(item);
                }
            }
            catch (Exception ex)
            {
                // Evita la caida de la aplicacion
                Console.WriteLine(ex.Message);
            }
        }

	}
}
