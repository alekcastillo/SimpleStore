using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Entities;
using SimpleStore.Infrastructure;

namespace SimpleStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodCardsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public PaymentMethodCardsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentMethodCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodCard>>> GetPaymentMethodCards()
        {
            return await _context.PaymentMethodCards.ToListAsync();
        }

        // GET: api/PaymentMethodCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodCard>> GetPaymentMethodCard(Guid id)
        {
            var paymentMethodCard = await _context.PaymentMethodCards.FindAsync(id);

            if (paymentMethodCard == null)
            {
                return NotFound();
            }

            return paymentMethodCard;
        }

        // PUT: api/PaymentMethodCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethodCard(Guid id, PaymentMethodCard paymentMethodCard)
        {
            if (id != paymentMethodCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentMethodCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodCardExists(id))
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

        // POST: api/PaymentMethodCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentMethodCard>> PostPaymentMethodCard(PaymentMethodCard paymentMethodCard)
        {
            _context.PaymentMethodCards.Add(paymentMethodCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentMethodCard", new { id = paymentMethodCard.Id }, paymentMethodCard);
        }

        // DELETE: api/PaymentMethodCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentMethodCard>> DeletePaymentMethodCard(Guid id)
        {
            var paymentMethodCard = await _context.PaymentMethodCards.FindAsync(id);
            if (paymentMethodCard == null)
            {
                return NotFound();
            }

            _context.PaymentMethodCards.Remove(paymentMethodCard);
            await _context.SaveChangesAsync();

            return paymentMethodCard;
        }

        private bool PaymentMethodCardExists(Guid id)
        {
            return _context.PaymentMethodCards.Any(e => e.Id == id);
        }
    }
}
