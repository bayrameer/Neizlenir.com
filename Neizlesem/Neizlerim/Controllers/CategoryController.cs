using BusinesLogicLayer.Abstarct;
using Core.BLL.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neizlerim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly IFilmService filmService;
        private readonly ICategoryService categoryService;

        public CategoryController(IFilmService filmService, ICategoryService categoryService)
        {
            this.filmService = filmService;
            this.categoryService = categoryService;
        }
        public IActionResult Index(int id)
        {
            CategoryDetailViewModel model = new CategoryDetailViewModel
            {
                Categories = categoryService.GetCategory().Data.ToList()
            };
            var result =filmService.GetFilmByCategoryId(id);
            switch (result.ResultType)
            {
                case EntityResultType.Success:
                    model.FilmDto = result.Data.ToList();
                    return View(model); 
                case EntityResultType.Error:
                    break;
                case EntityResultType.Notfound:
                    break;
                case EntityResultType.NonValidation:
                    break;
                case EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}
