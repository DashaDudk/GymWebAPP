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
    public class CategoriesController : ControllerBase
    {
        private readonly GymAPIContext _context;

        public CategoriesController(GymAPIContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
                                         .Include(a => a.Gyms)
                                         .FirstOrDefaultAsync(a => a.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Gyms = category.Gyms.Select(g => new GymDto
                {
                    Id = g.Id,
                    CategoryId = g.CategoryId,
                    StatusId = g.StatusId,
                    DateTime = g.DateTime,
                    Description = g.Description,
                    Price = g.Price
                }).ToList()
            };

            return Ok(categoryDto);
        }


        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Створення нової категорії
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName
            };

            // Створення та зв'язок нових gym з категорією
            foreach (var gymDto in categoryDto.Gyms)
            {
                var gym = new Gym
                {
                    StatusId = gymDto.StatusId,
                    DateTime = gymDto.DateTime,
                    Description = gymDto.Description,
                    Price = gymDto.Price
                };

                category.Gyms.Add(gym);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Отримання оновленої категорії з ідентифікаторами, які надає база даних
            var createdCategoryDto = new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Gyms = category.Gyms.Select(g => new GymDto
                {
                    Id = g.Id,
                    StatusId = g.StatusId,
                    DateTime = g.DateTime,
                    Description = g.Description,
                    Price = g.Price
                }).ToList()
            };

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, createdCategoryDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }

            var category = await _context.Categories.Include(a => a.Gyms).FirstOrDefaultAsync(a => a.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = categoryDto.CategoryName;

            // Оновлення списку Gym
            foreach (var gymDto in categoryDto.Gyms)
            {
                var gym = category.Gyms.FirstOrDefault(g => g.Id == gymDto.Id);
                if (gym != null)
                {
                    gym.StatusId = gymDto.StatusId;
                    gym.DateTime = gymDto.DateTime;
                    gym.Description = gymDto.Description;
                    gym.Price = gymDto.Price;
                }
                else
                {
                    category.Gyms.Add(new Gym
                    {
                        StatusId = gymDto.StatusId,
                        DateTime = gymDto.DateTime,
                        Description = gymDto.Description,
                        Price = gymDto.Price
                    });
                }
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // HEAD: api/Categories/5
        [HttpHead("{id}")]
        public async Task<IActionResult> HeadCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Отримання заголовків відповіді
            var headers = new Dictionary<string, string>();
            headers.Add("CategoryName", category.CategoryName);
            headers.Add("NumberOfGyms", category.Gyms.Count().ToString()); // Приклад кількості спортзалів у категорії

            return Ok(headers);
        }

        // PATCH: api/Categories/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Оновлення інформації про категорію
            category.CategoryName = categoryDto.CategoryName;

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}