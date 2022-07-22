using BusinesLogicLayer.Abstarct;
using DataAccessLayer.Abstarct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService filmService;

        public FilmController(IFilmService filmService)
        {
            this.filmService = filmService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            string[] sdizi = new string[] { "FilmImages" };
            var result = filmService.GetEntity(x => x.Id == id,sdizi );
            //var result = filmService.GetFilmByCategoryId(id);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    var entity = result.Data.ToList()[0];
                    return View(entity);
                    
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}
