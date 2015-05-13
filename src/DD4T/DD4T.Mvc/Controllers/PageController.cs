using Microsoft.AspNet.Mvc;
using DD4T.ContentModel;
using DD4T.ContentModel.Exceptions;
using DD4T.ContentModel.Factories;
using System;
using System.Threading.Tasks;
using Microsoft.Framework.Logging;

namespace DD4T.Mvc.Controllers
{
    public class PageController : Controller, IPageController
    {
        public IPageFactory PageFactory { get; private set; }
        private readonly ILogger Logger;
        //Todo: Fixme
        //public IComponentPresentationRenderer ComponentPresentationRenderer { get; set; }

        public PageController(IPageFactory pageFactory, ILoggerFactory loggerfactory)
        {
            Logger = loggerfactory.CreateLogger<PageController>();

            if (pageFactory == null)
                throw new ArgumentNullException("pageFactory");

            Logger.LogDebug("TridionPageController", pageFactory);

            PageFactory = pageFactory;
        }

        protected virtual ViewResult GetView(IPage page)
        {
            string viewName;
            if (page.PageTemplate.MetadataFields == null || !page.PageTemplate.MetadataFields.ContainsKey("view"))
                viewName = page.PageTemplate.Title.Replace(" ", "");
            else
                viewName = page.PageTemplate.MetadataFields["view"].Value;

            if (string.IsNullOrEmpty(viewName))
            {
                throw new ConfigurationException("No view configured for page template " + page.PageTemplate.Id);
            }

            return View(viewName, page);
        }

        //protected virtual ViewResult GetViewAsyncfor(classHomePage page)
        //{

        //    return View("Strongly", page);
        //}

        protected virtual ViewResult GetViewAsync(IPage page)
        {
            string viewName;
            if (page.PageTemplate.MetadataFields == null || !page.PageTemplate.MetadataFields.ContainsKey("view"))
                viewName = page.PageTemplate.Title.Replace(" ", "");
            else
                viewName = page.PageTemplate.MetadataFields["view"].Value;

            if (string.IsNullOrEmpty(viewName))
            {
                throw new ConfigurationException("No view configured for page template " + page.PageTemplate.Id);
            }
            return View(viewName, page);
        }

        //public virtual IActionResult Page(string pageId)
        //{
        //    IPage model = GetModelForPage(pageId);
        //    if (model == null)
        //        throw new Exception("Page cannot be found"); 

        //    //Todo: fix me
        //    //ViewBag.Renderer = ComponentPresentationRenderer;
        //    return GetView(model);
        //}

        public async virtual Task<IActionResult> PageAsync(string pageUrl)
        {
            //classHomePage model = await GetModelForPageAsyncFor(pageUrl);
            IPage model = await GetModelForPageAsync(pageUrl);
            if (model == null)
                throw new Exception("Page cannot be found");

            //Todo: fix me
            //ViewBag.Renderer = ComponentPresentationRenderer;
            return GetViewAsync(model);
        }

        protected async Task<IPage> GetModelForPageAsync(string PageId)
        {
            IPage page = await PageFactory.GetPage(string.Format("/{0}", PageId));
            return page;
        }
    }

}
