using DD4T.WebApplication.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.WebApplication.ViewComponents
{
    [ViewComponent(Name="Product")]
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Product product)
        {
            return View("Product", product);
        }
    }
}
