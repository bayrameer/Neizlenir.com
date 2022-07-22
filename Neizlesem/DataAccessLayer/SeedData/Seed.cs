using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SeedData
{
    public static class MyClass
    {
        public static void Seed()
        {
            NeizlesemDbContext db = new NeizlesemDbContext();
            
           // List<Category> categories = new List<Category>
           // {
            //  new Category{ Name="Animasyon"},//1
             // new Category{ Name="Romantik"},//2
             // new Category{ Name="Drama"},//3
             // new Category{ Name="Macera"},//3
             // new Category{ Name="Aksiyon"}//3
             //new Category{Name="Komedi"}
         // };
           // db.Category.AddRange(categories);
           List<Film> films = new List<Film>()
            {
              new Film{Name="Manchester by the Sea ",Puan=81,YapimYili=2018, },//19
               new Film{Name="Gone with the Wind",Puan=81,YapimYili=1993},//20
             


            };
            db.Film.AddRange(films);
            db.SaveChanges();

           List<FilmCategory> filmCategories = new List<FilmCategory>
           {
                 new FilmCategory{ CategoryId=1,FilmId=1071},
                 new FilmCategory{ CategoryId=4,FilmId=1072},
                 



           };

                 db.FilmCategory.AddRange(filmCategories);
                 db.SaveChanges();

                 List<FilmImage> filmImages = new List<FilmImage>
                 {
                 new FilmImage{ FilmId=1071, Url="/img/poster/q41.jpg"},
                 new FilmImage{ FilmId=1072, Url="/img/poster/q42.jpg"},
                 




                 };
                 db.FilmImages.AddRange(filmImages);
                db.SaveChanges();
                
            
        }
    }
}
