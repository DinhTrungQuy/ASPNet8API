using ASPNet8API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet8API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name = "Superman",
                    FistName = "Clark",
                    LastName = "Kent",
                    Palace = "Metropolis"
                },

            };


            return Ok(heroes);
        }

    }
}
