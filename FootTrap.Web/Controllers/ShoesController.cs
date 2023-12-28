using FootTrap.Services.Contracts;
using FootTrap.Services.ViewModels.Shoes;
using FootTrap.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FootTrap.Web.Controllers
{

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
            var userId = User.GetId();
            bool isCustomer = await userService.IsCustomerAsync(userId);

            if (!isCustomer)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                AllShoesFilteredAndPaged serviceModel = await shoeService.GetAllShoesFilteredAndPagedAsync(model);
                model.TotalShoes = serviceModel.TotalShoes;
                model.Shoes = serviceModel.Shoes;
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
            ShoeFromModel model = new ShoeFromModel();
            model.Categories = await categoryService.GetAllCategoriesAsync();
            model.Sizes = await sizeService.GetAllSizesAsync();

            return View(model);
        }
    }
}
