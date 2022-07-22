using BusinesLogicLayer.Abstarct;
using BusinesLogicLayer.Coctere;
using Core.BLL.Constant;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.Controllers
{
    public class HomeController : Controller  
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
             
            return View();
        }
        public IActionResult Abaout()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Hizmetler()
        {
            return View();
        }
    }
}
