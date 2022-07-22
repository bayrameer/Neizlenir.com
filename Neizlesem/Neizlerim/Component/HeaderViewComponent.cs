using BusinesLogicLayer.Abstarct;
using Entity.POCO;
using Microsoft.AspNetCore.Mvc;
using Neizlerim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.Component

{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HeaderViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
   
        public IViewComponentResult Invoke()
        {
            HeaderViewModel model = new HeaderViewModel();
            var categories = categoryService.GetCategory();
            switch (categories.ResultType)
            {
                    case Core.BLL.Constant.EntityResultType.Success:
                    model.Categories = categories.Data.ToList();
                        break;
                    case Core.BLL.Constant.EntityResultType.Error:
                        break;
                    case Core.BLL.Constant.EntityResultType.Notfound:
                        break;
                    case Core.BLL.Constant.EntityResultType.NonValidation:
                        break;
                    case Core.BLL.Constant.EntityResultType.Warning:
                        break;
                    default:
                        break;
            }
            
            
            return View(model);
        }
        
    }
}
