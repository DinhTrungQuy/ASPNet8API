using ASPNet8API.Data;
using ASPNet8API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNet8API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();


            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroe(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }



            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();


            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero([FromBody] SuperHero hero)
        {
            var heroExist = await _context.SuperHeroes.FindAsync(hero.Id);
            if (heroExist == null)
            {
                return BadRequest("Hero not found.");
            }
            heroExist.Name = hero.Name;
            heroExist.FistName = hero.FistName;
            heroExist.LastName = hero.LastName;
            heroExist.Palace = hero.Palace;
            await _context.SaveChangesAsync();


            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroExist = await _context.SuperHeroes.FindAsync(id);
            if (heroExist == null)
            {
                return BadRequest("Hero not found.");
            }
            _context.SuperHeroes.Remove(heroExist);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}
