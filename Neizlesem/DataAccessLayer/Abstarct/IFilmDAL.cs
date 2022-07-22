using Core.DAL;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstarct
{
    public interface IFilmDAL : IRepository<Film>
    {
        IEnumerable<FilmDto> GetFilmByCategoryId(int categoryid);
        IEnumerable<FilmDto> GetAllFilm();
    }
}
