//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GymWebAPP.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace GymWebAPP.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StatusController : ControllerBase
//    {
//        private readonly GymAPIContext _context;

//        public StatusController(GymAPIContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Status
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
//        {
//            return await _context.Statuses.ToListAsync();
//        }

//        // GET: api/Status/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Status>> GetStatus(int id)
//        {
//            var status = await _context.Statuses.FindAsync(id);

//            if (status == null)
//            {
//                return NotFound();
//            }

//            return status;
//        }

//        // POST: api/Status
//        [HttpPost]
//        public async Task<ActionResult<Status>> PostStatus(Status status)
//        {
//            _context.Statuses.Add(status);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, status);
//        }

//        // PUT: api/Status/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutStatus(int id, Status status)
//        {
//            if (id != status.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(status).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StatusExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // DELETE: api/Status/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStatus(int id)
//        {
//            var status = await _context.Statuses.FindAsync(id);
//            if (status == null)
//            {
//                return NotFound();
//            }

//            _context.Statuses.Remove(status);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool StatusExists(int id)
//        {
//            return _context.Statuses.Any(e => e.Id == id);
//        }
//    }
//}


////#nullable disable
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.AspNetCore.Mvc.Rendering;
////using Microsoft.EntityFrameworkCore;
////using GymWebAPP.Models;

////namespace GymWebAPP.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class StatusController : Controller
////    {
////        private readonly GymAPIContext _context;

////        public StatusController(GymAPIContext context)
////        {
////            _context = context;
////        }

////        // GET: Status
////        public async Task<IActionResult> Index()
////        {
////            return View(await _context.Statuses.ToListAsync());
////        }

////        // GET: Status/Details/5
////        public async Task<IActionResult> Details(int? id)
////        {
////            if (id == null)
////            {
////                return NotFound();
////            }

////            var status = await _context.Statuses
////                .FirstOrDefaultAsync(m => m.Id == id);
////            if (status == null)
////            {
////                return NotFound();
////            }

////            return View(status);
////        }

////        // GET: Status/Create
////        public IActionResult Create()
////        {
////            return View();
////        }

////        // POST: Status/Create
////        // To protect from overposting attacks, enable the specific properties you want to bind to.
////        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public async Task<IActionResult> Create([Bind("Id,StatusName")] Status status)
////        {
////            if (ModelState.IsValid)
////            {
////                _context.Add(status);
////                await _context.SaveChangesAsync();
////                return RedirectToAction(nameof(Index));
////            }
////            return View(status);
////        }

////        // GET: Status/Edit/5
////        public async Task<IActionResult> Edit(int? id)
////        {
////            if (id == null)
////            {
////                return NotFound();
////            }

////            var status = await _context.Statuses.FindAsync(id);
////            if (status == null)
////            {
////                return NotFound();
////            }
////            return View(status);
////        }

////        // POST: Status/Edit/5
////        // To protect from overposting attacks, enable the specific properties you want to bind to.
////        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName")] Status status)
////        {
////            if (id != status.Id)
////            {
////                return NotFound();
////            }

////            if (ModelState.IsValid)
////            {
////                try
////                {
////                    _context.Update(status);
////                    await _context.SaveChangesAsync();
////                }
////                catch (DbUpdateConcurrencyException)
////                {
////                    if (!StatusExists(status.Id))
////                    {
////                        return NotFound();
////                    }
////                    else
////                    {
////                        throw;
////                    }
////                }
////                return RedirectToAction(nameof(Index));
////            }
////            return View(status);
////        }

////        // GET: Status/Delete/5
////        public async Task<IActionResult> Delete(int? id)
////        {
////            if (id == null)
////            {
////                return NotFound();
////            }

////            var status = await _context.Statuses
////                .FirstOrDefaultAsync(m => m.Id == id);
////            if (status == null)
////            {
////                return NotFound();
////            }

////            return View(status);
////        }

////        // POST: Status/Delete/5
////        [HttpPost, ActionName("Delete")]
////        [ValidateAntiForgeryToken]
////        public async Task<IActionResult> DeleteConfirmed(int id)
////        {
////            var status = await _context.Statuses.FindAsync(id);
////            if (status != null)
////            {
////                _context.Statuses.Remove(status);
////            }

////            await _context.SaveChangesAsync();
////            return RedirectToAction(nameof(Index));
////        }

////        private bool StatusExists(int id)
////        {
////            return _context.Statuses.Any(e => e.Id == id);
////        }
////    }
////}
///


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
    public class StatusesController : ControllerBase
    {
        private readonly GymAPIContext _context;

        public StatusesController(GymAPIContext context)
        {
            _context = context;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetStatus(int id)
        {
            var status = await _context.Statuses
                                       .Include(s => s.Gyms)
                                       .FirstOrDefaultAsync(s => s.Id == id);

            if (status == null)
            {
                return NotFound();
            }

            var statusDto = new StatusDto
            {
                Id = status.Id,
                StatusName = status.StatusName,
                Gyms = status.Gyms.Select(g => new GymDto
                {
                    Id = g.Id,
                    CategoryId = g.CategoryId,
                    StatusId = g.StatusId,
                    DateTime = g.DateTime,
                    Description = g.Description,
                    Price = g.Price
                }).ToList()
            };

            return Ok(statusDto);
        }

        // POST: api/Statuses
        [HttpPost]
        public async Task<ActionResult<StatusDto>> PostStatus(StatusDto statusDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Створення нового статусу
            var status = new Status
            {
                StatusName = statusDto.StatusName
            };

            // Створення та зв'язок нових gym зі статусом
            foreach (var gymDto in statusDto.Gyms)
            {
                var gym = new Gym
                {
                    CategoryId = gymDto.CategoryId,
                    StatusId = gymDto.StatusId,
                    DateTime = gymDto.DateTime,
                    Description = gymDto.Description,
                    Price = gymDto.Price
                };

                status.Gyms.Add(gym);
            }

            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            // Отримання оновленого статусу з ідентифікаторами, які надає база даних
            var createdStatusDto = new StatusDto
            {
                Id = status.Id,
                StatusName = status.StatusName,
                Gyms = status.Gyms.Select(g => new GymDto
                {
                    Id = g.Id,
                    CategoryId = g.CategoryId,
                    StatusId = g.StatusId,
                    DateTime = g.DateTime,
                    Description = g.Description,
                    Price = g.Price
                }).ToList()
            };

            return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, createdStatusDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, StatusDto statusDto)
        {
            if (id != statusDto.Id)
            {
                return BadRequest();
            }

            var status = await _context.Statuses.Include(s => s.Gyms).FirstOrDefaultAsync(s => s.Id == id);

            if (status == null)
            {
                return NotFound();
            }

            status.StatusName = statusDto.StatusName;

            // Оновлення списку Gym
            foreach (var gymDto in statusDto.Gyms)
            {
                var gym = status.Gyms.FirstOrDefault(g => g.Id == gymDto.Id);
                if (gym != null)
                {
                    gym.CategoryId = gymDto.CategoryId;
                    gym.StatusId = gymDto.StatusId;
                    gym.DateTime = gymDto.DateTime;
                    gym.Description = gymDto.Description;
                    gym.Price = gymDto.Price;
                }
                else
                {
                    status.Gyms.Add(new Gym
                    {
                        CategoryId = gymDto.CategoryId,
                        StatusId = gymDto.StatusId,
                        DateTime = gymDto.DateTime,
                        Description = gymDto.Description,
                        Price = gymDto.Price
                    });
                }
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
