using BlazorApp1Demo.Client.Pages;
using BlazorApp1Demo.Server.Data;
using BlazorApp1Demo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1Demo.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private readonly DataContext _context;

        public SuperHeroController(ILogger<SuperHeroController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.Comics.ToListAsync();
            return Ok(comics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {
            var hero = _context.SuperHeroes.SingleOrDefault(x => x.Id == id);

            if (hero == null)
            {
                return NotFound("Sorry, not found");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> SalvarSuperHero(SuperHero param)
        {
            param.Comic = null;
            _context.SuperHeroes.Add(param);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> AlterarSuperHero(SuperHero param)
        {
            param.Comic = null;
            _context.SuperHeroes.Add(param);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _context.SuperHeroes.Include(s => s.Comic).ToListAsync();
        }
    }
}
