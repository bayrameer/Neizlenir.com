using Core.BLL;
using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinesLogicLayer.Abstarct
{
    public interface IFilmService : IGenericService<Film>
    {
        EntityResult<IEnumerable<FilmDto>> GetFilmByCategoryId(int categoryid);

        EntityResult<IEnumerable<Film>>GetEntity(Expression<Func<Film, bool>> expression = null, string[] navProperty = null);
    }
}
