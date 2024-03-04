using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Payment;
using FootTrap.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FootTrap.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUserService userService;
        private readonly IPaymentService paymentService;
        private readonly ICustomerService customerService;

        public PaymentController(IUserService userService, IPaymentService paymentService, ICustomerService customerService)
        {
            this.userService = userService;
            this.paymentService = paymentService;
            this.customerService = customerService;
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
            if(!isCustomer && !User.IsInRole("Admin")) 
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

            string? customerId = await customerService.GetCustomerIdByUserIdAsync(userId!);

            string paymentId = await paymentService.CreatPaymentAsync(model, customerId!);



            return RedirectToAction("Order", "Order", new {paymentId});
        }
    }
}
