using System;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Abstarct;

namespace DataAccessLayer.Concrete.Context.EntityFramework
{
    public class EfCategory : EfRepository<Category,NeizlesemDbContext>, ICategoryDAL

    {
        private readonly NeizlesemDbContext db;

        public EfCategory(NeizlesemDbContext db) : base(db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetCategory()
        {
            return db.Category
                .Include(x => x.FilmCategories)
                .ThenInclude(x => x.Film)
                .Where(x => x.Active && !x.Delete);
        }
    }
}
