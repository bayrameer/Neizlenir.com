using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using DataAccessLayer.Abstarct;
using BusinesLogicLayer.Abstarct;

namespace Neizlerim.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmDAL filmDAL;
        private readonly IFilmService filmService;

        public FilmsController( IFilmDAL filmDAL, IFilmService filmService)
        {
           
            this.filmDAL = filmDAL;
            this.filmService = filmService;
        }

        public IActionResult Index1()
        {
            var result = filmDAL.GetAllFilm().ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            string[] sdizi = new string[] { "FilmImages" };
            var result = filmService.GetEntity(x => x.Id == id, sdizi);
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
