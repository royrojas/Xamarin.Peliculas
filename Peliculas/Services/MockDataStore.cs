using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peliculas.Models;

namespace Peliculas.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        private string _apiKey = "a690bf18050ecf2071cd98b5c42f514a";
        private string _language = "es-ES";

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Titulo = "Actualmente en Cines", Api="/3/movie/now_playing?api_key=" + _apiKey + "&language=" + _language },
                new Item { Id = Guid.NewGuid().ToString(), Titulo = "Películas Populares", Api = "/3/movie/popular?api_key=" + _apiKey + "&language=" + _language},
                new Item { Id = Guid.NewGuid().ToString(), Titulo = "Mejores Películas del 2019", Api="/3/discover/movie?api_key=" + _apiKey + "&language=" + _language + "&primary_release_year=2019&sort_by=vote_average.desc" },
                new Item { Id = Guid.NewGuid().ToString(), Titulo = "Mejor Rankeado", Api="/3/movie/top_rated?api_key=" + _apiKey + "&language=" + _language },
                new Item { Id = Guid.NewGuid().ToString(), Titulo = "Próximas Películas", Api="3/movie/upcoming?api_key=" + _apiKey + "&language=" + _language },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}