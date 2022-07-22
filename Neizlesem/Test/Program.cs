using BusinesLogicLayer.Concrete;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BusinesLogicLayer.Abstarct;
using DataAccessLayer.Abstarct;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilmManager filmManager = new FilmManager(new EfFilm(new NeizlesemDbContext()));
            EfFilm ef = new EfFilm(new NeizlesemDbContext());
           var result = ef.GetFilmByCategoryId(1).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
           



          

        }
    }
}
