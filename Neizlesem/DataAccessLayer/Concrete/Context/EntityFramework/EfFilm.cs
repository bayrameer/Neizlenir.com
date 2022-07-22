using DataAccessLayer.Abstarct;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer.Concrete.Context.EntityFramework
{
    public class EfFilm : EfRepository<Film, NeizlesemDbContext>, IFilmDAL
    {
        public readonly NeizlesemDbContext db;
        public EfFilm(NeizlesemDbContext db) : base(db)
        {
            this.db = db;
        }
        public IEnumerable<FilmDto> GetFilmByCategoryId(int categoryid)
        {
            var result = from Film in db.Film
                         join FilmCategory in db.FilmCategory on Film.Id equals FilmCategory.FilmId
                         join Category in db.Category on FilmCategory.CategoryId equals Category.Id
                         where Category.Id==categoryid
                         select new FilmDto
                         {
                             CategoryName = Category.Name,
                             Id = Film.Id,
                             Name=Film.Name,
                             Puan=Film.Puan,
                             YonetmenId=Film.YonetmenId,
                             FilmDetayId=Film.FilmDetayId,
                             Images = db.FilmImages.FirstOrDefault(x => x.FilmId == Film.Id).Url

                         };
            return result;
        }
        public IEnumerable<FilmDto> GetAllFilm()
        {
            var result =
                from film in db.Film
                join filmCategory in db.FilmCategory
                on film.Id equals filmCategory.FilmId
                join category in db.Category
                on filmCategory.CategoryId equals category.Id
                select new FilmDto
                {
                    Id = film.Id,
                    Name=film.Name,
                    Puan = film.Puan,
                    YonetmenId = film.YonetmenId,
                    FilmDetayId = film.FilmDetayId,
                    Images = db.FilmImages.FirstOrDefault(x => x.FilmId == film.Id).Url
                     
                };
            return result;
        }
    }
}
