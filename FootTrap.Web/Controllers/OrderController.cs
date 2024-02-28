using FootTrap.Services.Contracts;
using FootTrap.Services.Services;
using FootTrap.Services.ViewModels.Order;
using FootTrap.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FootTrap.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserService userService;
        public OrderController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Order()
        {
            var userId = User.GetId();
            bool isCustomer = await userService.IsCustomerAsync(userId!);

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!isCustomer && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            OrderViewModel model = new OrderViewModel();

            return View(model);
        }
    }
}
