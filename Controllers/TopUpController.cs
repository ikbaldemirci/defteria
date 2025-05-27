using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Defteria.API.Models;
using Defteria.API.Data;

namespace Defteria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopUpController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TopUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TopUp>>> GetTopUps()
        {
            return await _context.TopUps.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopUp>> GetTopUp(int id)
        {
            var topUp = await _context.TopUps.FindAsync(id);
            if (topUp == null)
                return NotFound();
            return Ok(topUp);
        }

        [HttpPost]
        public async Task<ActionResult<TopUp>> CreateTopUp(TopUp topUp)
        {
            _context.TopUps.Add(topUp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTopUp), new { id = topUp.Id }, topUp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopUp(int id, TopUp updatedTopUp)
        {
            if (id != updatedTopUp.Id)
                return BadRequest();

            _context.Entry(updatedTopUp).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopUp(int id)
        {
            var topUp = await _context.TopUps.FindAsync(id);
            if (topUp == null)
                return NotFound();

            _context.TopUps.Remove(topUp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
