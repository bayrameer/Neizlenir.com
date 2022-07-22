using BusinesLogicLayer.Abstarct;
using BusinesLogicLayer.Validation;
using Core.BLL.Constant;
using Core.BLL.Logger;
using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Context.EntityFramework;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinesLogicLayer.Coctere
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL categoryDal;

        public CategoryManager(ICategoryDAL categoryDal)
        {
            this.categoryDal = categoryDal;
        }
        
        public EntityResult Add(Category entity)
        {
            try
            {
                
                var validation = new CategoryValidation(categoryDal).Validate(entity);
                if (!validation.IsValid)
                {
                    List<string> errorMessage = new List<string>();
                    foreach (var item in validation.Errors)
                    {
                        errorMessage.Add(item.ErrorMessage);
                    }
                    return new EntityResult(validation, EntityResultType.NonValidation);
                }
                if (categoryDal.Add(entity))
                {
                 return new EntityResult(ResultTypeMessage.Add());
                }
                return new EntityResult(ResultTypeMessage.Warning(), EntityResultType.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultTypeMessage.Error(ex),EntityResultType.Error);
            }
        }

        public EntityResult Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Category>> Get()
        {
            throw new NotImplementedException();
        }

        public EntityResult<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Category>> GetCategory()
        {
            try
            {
                var result = categoryDal.GetCategory();
                if (result!=null && result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Category>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Category>>(null,"Not Found",EntityResultType.Notfound);


            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<Category>>(null, "Error"+ex.ToInnest().Message,EntityResultType.Error);
               
            }
        }

        public EntityResult Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
