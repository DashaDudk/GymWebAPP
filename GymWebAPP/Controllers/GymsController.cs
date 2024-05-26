using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymWebAPP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWebAPP.DTO;

namespace GymWebAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly GymAPIContext _context;

        public GymsController(GymAPIContext context)
        {
            _context = context;
        }

        // GET: api/Gyms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gym>>> GetGyms()
        {
            return await _context.Gyms.ToListAsync();
        }

        // GET: api/Gyms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gym>> GetGym(int id)
        {
            var gym = await _context.Gyms.FindAsync(id);

            if (gym == null)
            {
                return NotFound();
            }

            return gym;
        }

        // POST: api/Gyms
        [HttpPost]
        public async Task<ActionResult<Gym>> PostGym(GymDto gymDto)
        {
            var gym = new Gym
            {
                CategoryId = gymDto.CategoryId,
                StatusId = gymDto.StatusId,
                DateTime = gymDto.DateTime,
                Description = gymDto.Description,
                Price = gymDto.Price
            };

            _context.Gyms.Add(gym);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGym), new { id = gym.Id }, gym);
        }

        // PUT: api/Gyms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGym(int id, GymDto gymDto)
        {
            if (id != gymDto.Id)
            {
                return BadRequest();
            }

            var gym = await _context.Gyms.FindAsync(id);

            if (gym == null)
            {
                return NotFound();
            }

            gym.CategoryId = gymDto.CategoryId;
            gym.StatusId = gymDto.StatusId;
            gym.DateTime = gymDto.DateTime;
            gym.Description = gymDto.Description;
            gym.Price = gymDto.Price;

            _context.Entry(gym).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymExists(id))
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
        private bool GymExists(int id)
        {
            return _context.Gyms.Any(e => e.Id == id);
        }

        // DELETE: api/Gyms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            var gym = await _context.Gyms.FindAsync(id);
            if (gym == null)
            {
                return NotFound();
            }

            _context.Gyms.Remove(gym);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/Gyms/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGym(int id, [FromBody] GymDto gymDto)
        {
            var gym = await _context.Gyms.FindAsync(id);
            if (gym == null)
            {
                return NotFound();
            }

            // Оновлення інформації про спортзал
            gym.DateTime = gymDto.DateTime;
            gym.Description = gymDto.Description;

            _context.Entry(gym).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}