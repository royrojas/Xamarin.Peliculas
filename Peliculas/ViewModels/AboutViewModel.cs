using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Peliculas.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About - Películas";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://royrojas.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}