using AutoMapper;
using HenriqueAnisio.Domain.Interfaces;
using HenriqueAnisio.Domain.Models;
using HenriqueAnisio.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HenriqueAnisio.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetCategoriesAsync());
            return View(model);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            await _categoryService.InsertCategoryAsync(_mapper.Map<Category>(product));
    
            return RedirectToAction("Index");
        }
    }
}
