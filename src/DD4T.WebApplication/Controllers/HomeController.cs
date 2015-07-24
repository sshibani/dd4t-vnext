using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DD4T.ContentModel.Factories;
using DD4T.ContentModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DD4T.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageFactory _pageFactory;
        public HomeController(IPageFactory pageFactory)
        {
            _pageFactory = pageFactory;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IPage s = null;
            var page = _pageFactory.TryFindPage("/", out s);
            return View(s);
        }
    }
}
