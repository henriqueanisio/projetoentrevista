using AutoMapper;
using HenriqueAnisio.Domain.Interfaces;
using HenriqueAnisio.Domain.Models;
using HenriqueAnisio.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueAnisio.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetProductsWithCategoriesAsync());
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new ProductViewModel();

            model.Categories = _mapper.Map<List<CategoryViewModel>>(await _categoryService.GetCategoriesAsync());

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = _mapper.Map<ProductViewModel>(await _productService.GetProductByIdWithCategoriesAsync(id));
            var allCategories = _mapper.Map<List<CategoryViewModel>>(await _categoryService.GetCategoriesAsync());
            
            foreach (var category in allCategories)
            {
                if (model.Categories.Select(x => x.Id).ToList().Contains(category.Id))
                    category.Selected = true;
            }

            model.Categories = allCategories;

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProductAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _mapper.Map<List<CategoryViewModel>>(await _categoryService.GetCategoriesAsync());
                return View(model);
            }

            await _productService.UpdateProductAsync(_mapper.Map<Product>(model), model.IdsCategories);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Categories = _mapper.Map<List<CategoryViewModel>>(await _categoryService.GetCategoriesAsync());
                return View(model);
            }

            await _productService.InsertProductAsync(_mapper.Map<Product>(model), model.IdsCategories);
    
            return RedirectToAction("Index");
        }
    }
}
