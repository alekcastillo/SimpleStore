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
    public class PaymentMethodEasyPaysController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public PaymentMethodEasyPaysController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentMethodEasyPays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodEasyPay>>> GetPaymentMethodEasyPays()
        {
            return await _context.PaymentMethodEasyPays.ToListAsync();
        }

        // GET: api/PaymentMethodEasyPays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodEasyPay>> GetPaymentMethodEasyPay(Guid id)
        {
            var paymentMethodEasyPay = await _context.PaymentMethodEasyPays.FindAsync(id);

            if (paymentMethodEasyPay == null)
            {
                return NotFound();
            }

            return paymentMethodEasyPay;
        }

        // PUT: api/PaymentMethodEasyPays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethodEasyPay(Guid id, PaymentMethodEasyPay paymentMethodEasyPay)
        {
            if (id != paymentMethodEasyPay.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentMethodEasyPay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodEasyPayExists(id))
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

        // POST: api/PaymentMethodEasyPays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentMethodEasyPay>> PostPaymentMethodEasyPay(PaymentMethodEasyPay paymentMethodEasyPay)
        {
            _context.PaymentMethodEasyPays.Add(paymentMethodEasyPay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentMethodEasyPay", new { id = paymentMethodEasyPay.Id }, paymentMethodEasyPay);
        }

        // DELETE: api/PaymentMethodEasyPays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentMethodEasyPay>> DeletePaymentMethodEasyPay(Guid id)
        {
            var paymentMethodEasyPay = await _context.PaymentMethodEasyPays.FindAsync(id);
            if (paymentMethodEasyPay == null)
            {
                return NotFound();
            }

            _context.PaymentMethodEasyPays.Remove(paymentMethodEasyPay);
            await _context.SaveChangesAsync();

            return paymentMethodEasyPay;
        }

        private bool PaymentMethodEasyPayExists(Guid id)
        {
            return _context.PaymentMethodEasyPays.Any(e => e.Id == id);
        }
    }
}
