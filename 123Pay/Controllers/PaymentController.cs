using _123Pay.Models;
using _123Pay.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _123Pay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentController(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [HttpPost] 
        public async Task<IActionResult> Create(NewPaymentRequest model)
        {
            try
            {
                var newPayment = model.ToEntity();
                await _paymentRepo.Add(newPayment);
                return Ok(newPayment.ReferenceNo);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]/{referenceNo}")]
        public async Task<IActionResult> Process(Guid referenceNo)
        {
            try
            {
                await _paymentRepo.Process(referenceNo);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]/{referenceNo}")]
        public async Task<IActionResult> Paid(Guid referenceNo, [FromForm]IFormFile attachment)
        {
            try
            {
                await _paymentRepo.Done(referenceNo, attachment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]/{referenceNo}")]
        public async Task<IActionResult> Reject(Guid referenceNo, [FromForm] IFormFile? attachment)
        {
            try
            {
                await _paymentRepo.Fail(referenceNo, attachment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
