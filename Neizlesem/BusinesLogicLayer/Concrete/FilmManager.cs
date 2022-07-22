using BusinesLogicLayer.Abstarct;
using Core.BLL.Constant;
using DataAccessLayer.Abstarct;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinesLogicLayer.Concrete
{
    public class FilmManager : IFilmService
    {
        private readonly IFilmDAL filmDAL;
        public FilmManager(IFilmDAL filmDAL)
        {
            this.filmDAL = filmDAL;
        }
        public EntityResult Add(Film entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult Delete(Film entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Film>> Get()
        {
            throw new NotImplementedException();
        }

        public EntityResult<Film> Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Film>> GetEntity(Expression<Func<Film, bool>> expression = null, string[] navProperty = null)
        {
            try
            {
               var result = filmDAL.GetEntity(expression, navProperty);
                if (result!=null && result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Film>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Film>>(null, "NotFound", EntityResultType.Notfound);
            }

            catch (Exception ex)
            {

                return new EntityResult<IEnumerable<Film>>(null,ex.ToInnest().Message,EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<FilmDto>> GetFilmByCategoryId(int categoryid)
        {
            try
            {
                var result = filmDAL.GetFilmByCategoryId(categoryid);
                if (result!=null&& result.Count()>0)
                {
                    return new EntityResult<IEnumerable<FilmDto>>(result, "Success");
                }
                return new EntityResult<IEnumerable<FilmDto>>(null, "NotFound",EntityResultType.Notfound);

            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<FilmDto>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Film entity)
        {
            throw new NotImplementedException();
        }
    }

}
