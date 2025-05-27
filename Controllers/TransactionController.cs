using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Defteria.API.Models;
using Defteria.API.Data;

namespace Defteria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, Transaction updatedTransaction)
        {
            if (id != updatedTransaction.Id)
                return BadRequest();

            _context.Entry(updatedTransaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
