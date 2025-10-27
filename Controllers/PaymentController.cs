using EXAMINATION.Data;
using Microsoft.AspNetCore.Mvc;
using EXAMINATION.Models;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;

namespace EXAMINATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PaymentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPayment()
        {
            var paymentData = dbContext.Payments.ToList();
            return Ok(paymentData);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = dbContext.Payments.Find(id);
            if(payment is null)
            {
                return NotFound();

            }
            return Ok(payment);
        }

        [HttpPost]
        public IActionResult UpdatePayment(Payment updatePayment)
        {
           
            dbContext.Payments.Add(updatePayment);
            dbContext.SaveChanges();
            return Ok(updatePayment);

        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdatePayment(int id,PaymentDto updatePayment)
        {
            var payment=dbContext.Payments.Find(id);
            if(payment is null)
            {
                return NotFound();
            }

            PaymentMapper.ApplyPatch(updatePayment, payment);

            dbContext.SaveChanges();
            return Ok(payment);


        }

        [HttpDelete]
        public IActionResult DeletePayment(int id)
        {
            var payment = dbContext.Payments.Find(id);
            if(payment is null)
            {
                return NotFound();

            }
            dbContext.Payments.Remove(payment);
            dbContext.SaveChanges();
            return Ok();

        }

    }

}
