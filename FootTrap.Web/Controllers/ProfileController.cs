using FootTrap.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FootTrap.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;

        public ProfileController(IProfileService profileService, IUserService userService)
        {
            this.profileService = profileService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile(string userId)
        {
            bool isExists = await userService.IsExistsByIdAsync(userId);
            if (!isExists)
            {
                return RedirectToAction("Index", "Home");
            }

            var profile = await profileService.GetProfileAsync(userId);
            if (profile == null)
            {
                return RedirectToAction("Index", "Home");
            }

            bool isCustomer = await userService.IsCustomerAsync(userId);
            if (!isCustomer) 
            {
                return RedirectToAction("Index", "Home");
            }

            return View(profile);



        }
    }
}
