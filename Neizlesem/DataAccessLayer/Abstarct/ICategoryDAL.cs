using Core.DAL;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstarct
{
    public interface ICategoryDAL : IRepository<Category>
    {
        IEnumerable<Category> GetCategory();
    }
}
