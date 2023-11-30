using BlazorApp1Demo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1Demo.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heros { get; set; }
        List<Comic> Comics { get; set; }

        Task GetComics();
        Task GetSuperHero();
        Task<SuperHero> GetSingleHero(int id);
       // Task<Comic> GetSingleComic(int id);


    }
}