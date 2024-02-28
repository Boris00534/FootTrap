using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Payment;
using FootTrap.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FootTrap.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUserService userService;

        public PaymentController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            var userId = User.GetId();
            bool isCustomer = await userService.IsCustomerAsync(userId!);

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if(!User.IsInRole("Admin") || !isCustomer) 
            { 
                return RedirectToAction("Index", "Home");
            }

            PaymentFormModel model = new PaymentFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentFormModel model)
        {
            var userId = User.GetId();
            bool isCustomer = await userService.IsCustomerAsync(userId!);

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!User.IsInRole("Admin") && !isCustomer)
            {
                return RedirectToAction("Index", "Home");
            }

            if(!ModelState.IsValid) 
            {
                return View(model);
            }

            return View();
        }
    }
}
