using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Shoes;
using FootTrap.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> All(ShoesQueryModel model)
        {
            //var userId = User.GetId();
            //bool isCustomer = await userService.IsCustomerAsync(userId);

            //if (!isCustomer && !User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            try
            {
                AllShoesFilteredAndPaged serviceModel = await shoeService.GetAllShoesFilteredAndPagedAsync(model);
                model.TotalShoes = serviceModel.TotalShoes;
                model.Shoes = serviceModel.Shoes.ToList();
                model.Categories = await categoryService.GetAllCategoryNamesAsync();

                return View(model);
            }
            catch (Exception ex)
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

            ShoeFromModel model = new ShoeFromModel();
            model.Categories = await categoryService.GetAllCategoriesAsync();
            model.Sizes = await sizeService.GetAllSizesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShoeFromModel model)
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

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            string userName = User.GetUsername();
            var cartShoes = shoeService.GetCartShoes(userName);

            return View(cartShoes);

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

            string userName = User.GetUsername();
            //var cartShoes = shoeService.GetCartShoes(userName);
            //var shoe = await shoeService.GetShoeForOrderAsync(shoeId);

            await shoeService.AddShoeToCart(userName, shoeId, model.Size);
            return RedirectToAction("Cart");


        }
    }
}
