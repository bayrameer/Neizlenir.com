using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Abstarct;
using Entity.POCO;
using FluentValidation;

namespace BusinesLogicLayer.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        private readonly ICategoryDAL categoryDAL;

        public CategoryValidation(ICategoryDAL categoryDAL)
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name Alanı Boş Geçilemez");
            RuleFor(x => x.Name).Must(CategoryNameValidation).WithMessage("Alan adı mevcut");
            this.categoryDAL = categoryDAL;
        }
        public bool CategoryNameValidation(string categoryname)
        {
            Category entity =
                categoryDAL.Get().AsQueryable().FirstOrDefault(x => x.Name == categoryname);
            if (entity == null)
            {
                return true;
            }
            return false;
        }
    }
}
