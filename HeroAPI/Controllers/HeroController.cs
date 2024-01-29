using HeroAPI.DATA;
using HeroAPI.MODELS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly APIDbContext dbContext;

        public HeroController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return dbContext.Hero;
        }

        //Método Get con ID

        // GET api/<HeroController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Agregamos validaciones 
            if(id <= 0)
            {
                return BadRequest("El ID debe de ser mayor que 0");
            }
            Hero hero = dbContext.Hero.Find(id);
            if(hero == null)
            {
                return NotFound("Héroe NO encontrado");  
            }
            return Ok(hero);
        }

        //Agregar
        // POST api/<HeroController>
        [HttpPost]
        public IActionResult Post([FromBody] Hero newHero)
        {
            if (newHero == null)
            {
                return BadRequest("Los datos del heroe son nulos");
            }
            if((string.IsNullOrEmpty(newHero.Name))
                ||(string.IsNullOrEmpty(newHero.Description))
                ||(string.IsNullOrEmpty(newHero.HeroType))
                || (string.IsNullOrEmpty(newHero.DamageType))){
                return BadRequest("Uno de los campos esta vacío");
            }
            dbContext.Hero.Add(newHero);
            dbContext.SaveChanges();
            return Ok();
        }

        //Actualizar
        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Hero updatedHero)
        { 
            if(updatedHero == null)
            {
                return BadRequest("Los datos del héroe son nulos");
            }

            var existingHero = dbContext.Hero.Find(id);

            if(existingHero == null)
            {
                return BadRequest("Héroe NO encontrado");
            }

            existingHero.Name = updatedHero.Name;
            existingHero.Description = updatedHero.Description;
            existingHero.HeroType = updatedHero.HeroType;
            existingHero.DamageType = updatedHero.DamageType;

            dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var heroToDelete = dbContext.Hero.Find(id);
            if(heroToDelete != null)
            {
                dbContext.Hero.Remove(heroToDelete);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
