using APIPLANETAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static APIPLANETAS.ApplicationDbContext;

namespace APIPLANETAS.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PlanetsController : ControllerBase
        {
            private readonly PlanetContext _context;

            public PlanetsController(PlanetContext context)
            {
                _context = context;
            }

            // GET: api/Planets
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Planets>>> GetPlanets()
            {
                return await _context.Planets.ToListAsync();
            }

            // GET: api/Planets/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Planets>> GetPlanet(int id)
            {
                var planet = await _context.Planets.FindAsync(id);

                if (planet == null)
                {
                    return NotFound();
                }

                return planet;
            }

            // PUT: api/Planets/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutPlanet(int id, Planets planet)
            {
                if (id != planet.Id)
                {
                    return BadRequest();
                }

                _context.Entry(planet).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/Planets
            [HttpPost]
            public async Task<ActionResult<Planets>> PostPlanet(Planets planet)
            {
                _context.Planets.Add(planet);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPlanet), new { id = planet.Id }, planet);
            }

            // DELETE: api/Planets/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePlanet(int id)
            {
                var planet = await _context.Planets.FindAsync(id);
                if (planet == null)
                {
                    return NotFound();
                }

                _context.Planets.Remove(planet);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool PlanetExists(int id)
            {
                return _context.Planets.Any(e => e.Id == id);
            }
        }
    
}
