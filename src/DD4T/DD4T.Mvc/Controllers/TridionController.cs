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

//namespace DD4T.Mvc.Controllers
//{
//    public abstract class TridionController : Controller, IPageController, IComponentController
//    {
     
//        public virtual IPageFactory PageFactory { get; set; }
//        public virtual IComponentFactory ComponentFactory { get; set; }

//        //Todo: Fixme
//        //public IComponentPresentationRenderer ComponentPresentationRenderer { get; set; }

//        public TridionController()
//        {
//            PageFactory = CreateDefaultPageFactory();
//            ComponentFactory = CreateDefaultComponentFactory();
//        }
//        public TridionController(IPageFactory pageFactory)
//        {
//            if (pageFactory == null)
//                throw new ArgumentException("pageFactory");

//            PageFactory = pageFactory;
//            ComponentFactory = CreateDefaultComponentFactory();
//        }

//        public TridionController(IComponentFactory componentFactory)
//        {
//            if (componentFactory == null)
//                throw new ArgumentException("pageFactory");

//            ComponentFactory = componentFactory;
//            PageFactory = CreateDefaultPageFactory();
//        }

//        public TridionController(IPageFactory pageFactory, IComponentFactory componentFactory)
//        {
//            if (pageFactory == null)
//                throw new ArgumentException("pageFactory");

//            if (componentFactory == null)
//                throw new ArgumentException("componentFactory");

//            PageFactory = pageFactory;
//            ComponentFactory = componentFactory;
//        }



//        private IPageFactory CreateDefaultPageFactory()
//        {
//            return new PageFactory();
//        }

//        private IComponentFactory CreateDefaultComponentFactory()
//        {
//            return new ComponentFactory();
//        }

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

//        protected IPage GetModelForPage(string PageId)
//        {
//            IPage page;
//            if (PageFactory != null)
//            {
//                if (PageFactory.TryFindPage(string.Format("/{0}", PageId), out page))
//                {
//                    return page;
//                }
//            }
//            else
//                throw new ConfigurationException("No PageFactory configured");

//            return page;
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
//                throw new ConfigurationException("no view configured for page template " + page.PageTemplate.Id);
//            }

//            return base.View(viewName, page);
//        }

//        protected IComponentPresentation GetComponentPresentation()
//        {
//            return this.RouteData.Values["ComponentPresentation"] as IComponentPresentation;
//        }

//        protected virtual ViewResult GetView(IComponentPresentation componentPresentation)
//        {
//            string viewName = null;
//            if (componentPresentation.ComponentTemplate.MetadataFields == null || !componentPresentation.ComponentTemplate.MetadataFields.ContainsKey("view"))
//                viewName = componentPresentation.ComponentTemplate.Title.Replace(" ", "");
//            else
//                viewName = componentPresentation.ComponentTemplate.MetadataFields["view"].Value; 

//            if (string.IsNullOrEmpty(viewName))
//            {
//                throw new ConfigurationException("no view configured for component template " + componentPresentation.ComponentTemplate.Id);
//            }
//            return View(viewName, componentPresentation);

//        }

  
//        public virtual IActionResult Page(string pageId)
//        {
//            IPage model = GetModelForPage(pageId);
//            if (model == null) { throw new Exception("Page cannot be found"); }
//            ViewBag.Title = model.Title;
//            //Todo: fix me
//            //ViewBag.Renderer = ComponentPresentationRenderer;
//            return GetView(model);
//        }

//        /// <summary>
//        /// Create IPage from XML in the request and forward to the view
//        /// </summary>
//        /// <example>
//        /// To use, add the following code to the Global.asax.cs of your MVC web application:
//        ///             routes.MapRoute(
//        ///                "PreviewPage",
//        ///                "{*PageId}",
//        ///                new { controller = "Page", action = "PreviewPage" }, // Parameter defaults
//        ///                new { httpMethod = new HttpMethodConstraint("POST") } // Parameter constraints
//        ///            );
//        ///            * This is assuming that you have a controller called PageController which extends TridionControllerBase
//        /// </example>
//        /// <returns></returns>
//        //[HandleError]
//        //[AcceptVerbs(HttpVerbs.Post)]
//        //[ValidateInput(false)]
//        //public System.Web.Mvc.ActionResult PreviewPage()
//        //{

//        //    try
//        //    {
//        //        using (StreamReader reader = new StreamReader(this.Request.InputStream))
//        //        {
//        //            string pageXml = reader.ReadToEnd();
//        //            IPage model = this.PageFactory.GetIPageObject(pageXml);
//        //            if (model == null)
//        //            {
//        //                throw new ModelNotCreatedException("--unknown--");
//        //            }
//        //            ViewBag.Title = model.Title;
//        //            ViewBag.Renderer = ComponentPresentationRenderer;
//        //            ViewResult result = GetView(model);
//        //            return result;
//        //        }
//        //    }
//        //    catch (SecurityException se)
//        //    {
//        //        throw new HttpException(403, se.Message);
//        //    }

//        //}


//        public virtual IActionResult ComponentPresentation(string componentPresentationId)
//        {
//            Logger.Information(">>ComponentPresentation", LoggingCategory.Performance);
//            try
//            {
//                IComponentPresentation model = GetComponentPresentation();
//                //Todo: fix me
//                //ViewBag.Renderer = ComponentPresentationRenderer;
//                ViewResult result = GetView(model);
//                Logger.Information("<<ComponentPresentation", LoggingCategory.Performance);
//                return result;
//            }
//            catch (ConfigurationException e)
//            {
//                ViewResult result = View("Configuration exception: " + e.Message);
//                Logger.Information("<<ComponentPresentation", LoggingCategory.Performance);
//                return result;
//            }
//        }
//        //public virtual ActionResult ComponentPresentation(IComponentPresentation cp)
//        //{
//        //    try
//        //    {
//        //        ViewBag.Renderer = ComponentPresentationRenderer;
//        //        return GetView(cp);
//        //    }
//        //    catch (ConfigurationException e)
//        //    {
//        //        return View("Configuration exception: " + e.Message);
//        //    }
//        //}


//    }
//}
