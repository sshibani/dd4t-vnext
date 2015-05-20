using DD4T.ContentModel.Contracts.Factories;
using DVM4T.Contracts;
using DVM4T.Core;
using DVM4T.DD4T;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DD4T.WebApplication.Controllers
{
    public class ComponentPresentationController : Controller
    {
        public IComponentPresentationFactory ComponentPresentationFactory { get; private set; }
        private readonly ILogger Logger;

        public ComponentPresentationController(IComponentPresentationFactory componentPresentationFactory, ILoggerFactory loggerfactory)
        {
            Logger = loggerfactory.CreateLogger<ComponentPresentationController>();

            if (componentPresentationFactory == null)
                throw new ArgumentNullException("componentPresentationFactory");

            Logger.LogDebug("TridionPageController", componentPresentationFactory);

            ComponentPresentationFactory = componentPresentationFactory;
        }

        public async virtual Task<IActionResult> CP(string pageUrl)
        {
            //classHomePage model = await GetModelForPageAsyncFor(pageUrl);
            var cp = await ComponentPresentationFactory.GetComponentPresentation("3");

            IComponentPresentationData cpDataObject = new ComponentPresentation(cp);
            ViewModelDefaults.Factory.LoadViewModels(Assembly.GetAssembly(this.GetType()));
            var model = ViewModelDefaults.Factory.BuildViewModel(cpDataObject);
            return View("CP", model);

            //Todo: fix me
            //ViewBag.Renderer = ComponentPresentationRenderer;
            //return View("CP");
        }

    }
}
