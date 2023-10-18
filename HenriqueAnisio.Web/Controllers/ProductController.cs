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
            var productViewModel = new ProductViewModel();

            productViewModel.Categories = _mapper.Map<List<CategoryViewModel>>(await _categoryService.GetCategoriesAsync());

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            await _productService.InsertProductAsync(_mapper.Map<Product>(product), product.IdsCategories);
    
            return RedirectToAction("Index");
        }
    }
}
