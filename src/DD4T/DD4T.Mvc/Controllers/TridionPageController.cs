//using System.Net;
//using Microsoft.AspNet.Mvc;
//using DD4T.ContentModel;
//using DD4T.ContentModel.Exceptions;
//using DD4T.ContentModel.Factories;
//using System;
//using DD4T.Factories;
//using System.IO;
//using System.Security;
//using Utils = DD4T.Utils;
//using DD4T.ContentModel.Logging;
//using DD4T.Utils;
//using System.Threading.Tasks;
//using DD4T.ContentModel.Factories.New;
//using DD4T.Factories.New;
//using DD4T.Providers.SDLTridion2013sp1.New;


//namespace DD4T.Mvc.Controllers
//{
//    public class TridionPageController : Controller, IPageController
//    {
//        protected INewPageFactory PageFactory { get; private set; }

//        private ILogger logger = null;
//        public ILogger Logger
//        {
//            get
//            {
//                if (logger == null)
//                    logger = NullLogger.Create();

//                return logger;
//            }
//            set
//            {
//                logger = value;
//            }
//        }
//        //Todo: Fixme
//        //public IComponentPresentationRenderer ComponentPresentationRenderer { get; set; }

//        public TridionPageController(INewPageFactory pageFactory)
//        {
//            if (pageFactory == null)
//                throw new ArgumentNullException("pageFactory");

//            Logger.Debug("TridionPageController", pageFactory);

//            PageFactory = pageFactory;
//        }

//        protected virtual ViewResult GetView(IPage page)
//        {
//            string viewName;
//            if (page.PageTemplate.MetadataFields == null || !page.PageTemplate.MetadataFields.ContainsKey("view"))
//                viewName = page.PageTemplate.Title.Replace(" ", "");
//            else
//                viewName = page.PageTemplate.MetadataFields["view"].Value;

//            if (string.IsNullOrEmpty(viewName))
//            {
//                throw new ConfigurationException("No view configured for page template " + page.PageTemplate.Id);
//            }

//            return View(viewName, page);
//        }

//        protected virtual ViewResult GetViewAsyncfor(classHomePage page)
//        {
           
//            return View("Strongly", page);
//        }

//        protected virtual ViewResult GetViewAsync(IPage page)
//        {
//            string viewName;
//            if (page.PageTemplate.MetadataFields == null || !page.PageTemplate.MetadataFields.ContainsKey("view"))
//                viewName = page.PageTemplate.Title.Replace(" ", "");
//            else
//                viewName = page.PageTemplate.MetadataFields["view"].Value;

//            if (string.IsNullOrEmpty(viewName))
//            {
//                throw new ConfigurationException("No view configured for page template " + page.PageTemplate.Id);
//            }
//            return View(viewName, page);
//        }

//        //public virtual IActionResult Page(string pageId)
//        //{
//        //    IPage model = GetModelForPage(pageId);
//        //    if (model == null)
//        //        throw new Exception("Page cannot be found"); 

//        //    //Todo: fix me
//        //    //ViewBag.Renderer = ComponentPresentationRenderer;
//        //    return GetView(model);
//        //}

//        public async virtual Task<IActionResult> PageAsync(string pageUrl)
//        {
//            //classHomePage model = await GetModelForPageAsyncFor(pageUrl);
//            IPage model = await GetModelForPageAsync(pageUrl);
//            if (model == null)
//                throw new Exception("Page cannot be found");

//            //Todo: fix me
//            //ViewBag.Renderer = ComponentPresentationRenderer;
//            return GetViewAsync(model);
//        }

//        protected async Task<IPage> GetModelForPageAsync(string PageId)
//        {
//            IPage page = await PageFactory.GetPage(string.Format("/{0}", PageId));
//            return page;
//        }

//        protected async Task<classHomePage> GetModelForPageAsyncFor(string PageId)
//        {
//            classHomePage page = await PageFactory.GetPage<classHomePage>(string.Format("/{0}", PageId));
//            return page;
//        }

//    }

//    public class classHomePage
//    {
//        public string Title { get; set; }
//    }
//}
