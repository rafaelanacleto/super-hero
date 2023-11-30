using BlazorApp1Demo.Client.Pages;
using BlazorApp1Demo.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BlazorApp1Demo.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public List<SuperHero> Heros { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public async Task GetComics()
        {
            var retorno = await _httpClient.GetFromJsonAsync<List<Comic>>("superhero/comics");

            if (retorno != null)
                Comics = retorno;
        }

        public async Task GetSuperHero()
        {
            var retorno = await _httpClient.GetFromJsonAsync<List<SuperHero>>("superhero");

            if (retorno != null)
                Heros = retorno;

        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SuperHero>($"superhero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task CreateHero(SuperHero hero)
        {
            var result = await _httpClient.PostAsJsonAsync("superhero", hero);
            await SetHeroes(result);
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var result = await _httpClient.PutAsJsonAsync($"superhero/{hero.Id}", hero);
            await SetHeroes(result);
        }

        public async Task DeleteHero(int id)
        {
            var result = await _httpClient.DeleteAsync($"superhero/{id}");
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Heros = response;
            _navigationManager.NavigateTo("superhero");
        }

    }
}