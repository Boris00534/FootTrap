using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Shoes;
using FootTrap.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using FootTrap.Services.Extensions;

namespace FootTrap.Web.Controllers
{
    [Authorize]
    public class ShoesController : Controller
    {
        private readonly IShoeService shoeService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly ISizeService sizeService;

        public ShoesController(IShoeService shoeService, IUserService userService, ICategoryService categoryService, ISizeService sizeService)
        {
            this.shoeService = shoeService;
            this.userService = userService;
            this.categoryService = categoryService;
            this.sizeService = sizeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(ShoesQueryModel model)
        {
            var userId = User.GetId();
            bool isCustomer = await userService.IsCustomerAsync(userId!);

            if (!isCustomer && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                AllShoesFilteredAndPaged serviceModel = await shoeService.GetAllShoesFilteredAndPagedAsync(model);
                model.TotalShoes = serviceModel.TotalShoes;
                model.Shoes = serviceModel.Shoes.ToList();
                model.Categories = await categoryService.GetAllCategoryNamesAsync();

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            ShoeFormModel model = new ShoeFormModel();
            model.Categories = await categoryService.GetAllCategoriesAsync();
            model.Sizes = await sizeService.GetAllSizesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShoeFormModel model)
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategoriesAsync();
                model.Sizes = await sizeService.GetAllSizesAsync();

                return View(model);
            }

            string shoeId = await shoeService.AddAsync(model);

            await sizeService.AddSizesToShoeAsync(model.SizeIds, shoeId);

            return RedirectToAction("All");


        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isExists = await shoeService.IsExistsAsync(id);
            if (!isExists)
            {
                return RedirectToAction("All");
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = await shoeService.GetDetailsForShoeAsync(id);

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            if (!User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            string? userName = User.GetUsername();
            var cartShoes = shoeService.GetCartShoes(userName!);

            return await Task.Run(() =>  View(cartShoes));

        }

        public async Task<IActionResult> AddToCart(DetailsShoeViewModel model)
        {
            string shoeId = model.Id;
            bool isExists = await shoeService.IsExistsAsync(shoeId);

            if (!isExists)
            {
                return RedirectToAction("All");
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            string userName = User.GetUsername()!;
            await shoeService.AddShoeToCart(userName, shoeId, model.Size);
            return RedirectToAction("Cart");


        }

        [AllowAnonymous]
        public async Task<IActionResult> RemoveFromCart(string shoeId)
        {
            bool isExists = await shoeService.IsExistsAsync(shoeId);

            if (!isExists)
            {
                return RedirectToAction("All");
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            var shoes = HttpContext.Session.GetObjectFromJson<List<OrderShoeViewModel>>($"cart{User.GetUsername()}");

            if(shoes!.Count > 0)
            {
                var shoeToRemove = shoes.FirstOrDefault(d => d.Id == shoeId);
                if (shoes.Remove(shoeToRemove!))
                {
                    HttpContext.Session.SetObjectAsJson($"cart{User.GetUsername()}", shoes);
                }
                else
                {
                    HttpContext.Session.SetObjectAsJson($"cart{User.GetUsername()}", shoes);

                    return RedirectToAction("Cart");
                }
            }

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string shoeId)
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("All");
            }

            bool isExists = await shoeService.IsExistsAsync(shoeId);

            if (!isExists)
            {
                return RedirectToAction("All");
            }

            try
            {
                var shoe = await shoeService.GetShoeForEditAsync(shoeId);

                return View(shoe);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}
