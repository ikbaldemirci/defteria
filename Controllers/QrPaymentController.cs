using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Defteria.API.Models;
using Defteria.API.Data;

namespace Defteria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrPaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QrPaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<QrPayment>>> GetQrPayments()
        {
            return await _context.QrPayments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QrPayment>> GetQrPayment(int id)
        {
            var qrPayment = await _context.QrPayments.FindAsync(id);
            if (qrPayment == null)
                return NotFound();
            return Ok(qrPayment);
        }

        [HttpPost]
        public async Task<ActionResult<QrPayment>> CreateQrPayment(QrPayment qrPayment)
        {
            _context.QrPayments.Add(qrPayment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQrPayment), new { id = qrPayment.Id }, qrPayment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQrPayment(int id, QrPayment updatedPayment)
        {
            if (id != updatedPayment.Id)
                return BadRequest();

            _context.Entry(updatedPayment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQrPayment(int id)
        {
            var qrPayment = await _context.QrPayments.FindAsync(id);
            if (qrPayment == null)
                return NotFound();

            _context.QrPayments.Remove(qrPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
