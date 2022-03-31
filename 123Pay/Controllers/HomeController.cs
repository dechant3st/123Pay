using _123Pay.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _123Pay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPaymentRepo _paymentRepo;

        public HomeController(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<IActionResult> Index([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return View(await _paymentRepo.List(pageNumber, pageSize));
        }
    }
}
