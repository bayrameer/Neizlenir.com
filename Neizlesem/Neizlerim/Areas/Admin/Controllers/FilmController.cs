using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Neizlerim.Areas.Admin.Data;
using FilmDto = Neizlerim.Areas.Admin.Data.FilmDto;
using Microsoft.AspNetCore.Authorization;

namespace Neizlerim.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    public class FilmController : Controller
    {
        private readonly NeizlesemDbContext db;
        public FilmController(NeizlesemDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           var film
                = db.Film.Include(x=>x.FilmImages)
                .Include(x=>x.FilmCategories)

                .ToList();
            return View(film);
        }
        public async Task<IActionResult> Details(int id)
        {
           var film = 
                await db.Film.Include(x => x.FilmImages)
                .Include(x => x.FilmCategories).FirstOrDefaultAsync(x => x.Id == id);
           return View(film);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var film =
                 await db.Film.Include(x => x.FilmImages)
                 .Include(x => x.FilmCategories).FirstOrDefaultAsync(x => x.Id == id);
            return View(film);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var film =
                 await db.Film.Include(x => x.FilmImages)
                 .Include(x => x.FilmCategories).FirstOrDefaultAsync(x => x.Id == id);
            return View(film);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Category =new SelectList( db.Category
                .Where(x=> x.Active && x.Delete) 
                .Select(x=>new Category {Id=x.Id,Name=x.Name })
                .ToList(),"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FilmDto model)
        {
            var fileInfo = new FileInfo(model.Images[0].FileName).Extension;
            if (ModelState.IsValid)
            {
                var strategy = db.Database.CreateExecutionStrategy();
                strategy.Execute(() =>
                {
                    var transaction =
                    db.Database.BeginTransaction();
                    try
                    {
                        Film film =
                        new Film
                        {
                            Name = model.Name,
                            Puan = model.Puan,
                            YapimYili = model.YapimYili
                        };
                        db.Film.Add(film);
                        if (db.SaveChanges() > 0)
                        {
                            List<FilmCategory> filmCategories = new List<FilmCategory>();
                            foreach (var item in model.Categories)
                            {
                                FilmCategory filmCategory =
                                new FilmCategory
                                {
                                    FilmId = film.Id, 
                                    CategoryId = item
                                };
                                filmCategories.Add(filmCategory);
                            }
                            db.FilmCategory.AddRange(filmCategories);
                            if (model.Images != null && model.Images.Count > 0)
                            {
                                foreach (var item in model.Images)
                                {
                                    string path = Guid.NewGuid().ToString() + new FileInfo(item.FileName).Extension;
                                    string pathControl = new FileInfo(item.FileName).Extension;
                                    if (pathControl == ".jpg")
                                    {

                                        string dataBasepath = "/ProImages/" + path;
                                        string serverPath = Directory.GetCurrentDirectory() + @"\wwwroot\ProImages\" + path;
                                        db.FilmImages.Add(new FilmImage { FilmId = film.Id, Url = dataBasepath });
                                        var flStrm = new FileStream(serverPath, FileMode.Create);
                                        item.CopyTo(flStrm);
                                    }

                                }
                                db.SaveChanges();
                                transaction.Commit();

                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }

                });

                return RedirectToAction("Index");

            }
            ViewBag.Category =
                new SelectList(db.Category
                .Where(x => x.Active && x.Delete)
                .Select(x => new Category { Id = x.Id, Name = x.Name })
                .ToList(), "Id", "Name");
            return View(model);
        }
    }

}