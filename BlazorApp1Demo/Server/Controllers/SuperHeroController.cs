using BlazorApp1Demo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1Demo.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;

        public static List<Comic> comics = new List<Comic> {
            new Comic{ Id = 1, Name = "Marvel"},
            new Comic{ Id = 2, Name = "DC"},
            new Comic{ Id = 3, Name = "Wanley"}
        };

        public static List<SuperHero> heroes = new List<SuperHero> {
            new SuperHero{
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Miranha",
                ComicId = 1,
                Comic = comics[0]
            },
            new SuperHero{
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                ComicId = 2,
                Comic = comics[1]
            },
            new SuperHero{
                Id = 3,
                FirstName = "Tony",
                LastName = "Stark",
                HeroName = "Iron Man",
                ComicId = 1,
                Comic = comics[0]
            }
        };

        public SuperHeroController(ILogger<SuperHeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(heroes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {
            var hero = heroes.FirstOrDefault(x => x.Id == id);

            if (hero == null)
            {
                return NotFound("Sorry, not found");
            }

            return Ok(hero);
        }

    }
}
