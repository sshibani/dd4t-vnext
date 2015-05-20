using Microsoft.AspNet.Mvc;
using DD4T.ContentModel;
using DD4T.ContentModel.Exceptions;
using DD4T.ContentModel.Factories;
using System;
using System.Threading.Tasks;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Mvc.Rendering;
using DD4T.Mvc.Controllers;
using DD4T.WebApplication.Models;
using DVM4T.Core;
using DVM4T.Contracts;
using System.Reflection;

namespace DD4T.WebApplication.Controllers
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

        protected virtual ViewResult GetViewAsync()
        {
            return View("Strongly");
        }

        protected virtual string GetViewAsync(IPage page)
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
            return viewName;
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


            IPageData pDataObject = new DVM4T.DD4T.Page(model);
           
            ViewModelDefaults.Factory.LoadViewModels(Assembly.GetAssembly(this.GetType()));
            var pageModel = ViewModelDefaults.Factory.BuildViewModel(pDataObject);
            //return View("CP", pageModel);

            var viewName = GetViewAsync(model);
            //Todo: fix me
            //ViewBag.Renderer = ComponentPresentationRenderer;
            return View(viewName, pageModel);
        }

        public async virtual Task<IActionResult> PageAsyncFor(string pageUrl)
        {
            var view = GetViewAsync();

            var ViewEngine = (ICompositeViewEngine)ActionContext.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine));

            var v = ViewEngine.FindPartialView(ActionContext, "Strongly");

            var model = await GetModelForPageAsync<GeneralPage>(pageUrl);
            //IPage model = await GetModelForPageAsync(pageUrl);
            if (model == null)
                throw new Exception("Page cannot be found");

            //Todo: fix megit 
            //ViewBag.Renderer = ComponentPresentationRenderer;
            view.ViewData.Model = model;
            return view;
        }


        protected async Task<IPage> GetModelForPageAsync(string PageId)
        {
            IPage page = await PageFactory.GetPage(string.Format("/{0}", PageId));
            return page;
        }


        protected async Task<T> GetModelForPageAsync<T>(string PageId)
        {
            var page = await PageFactory.GetPage<T>(string.Format("/{0}", PageId));
            return page;
        }


    }




}
