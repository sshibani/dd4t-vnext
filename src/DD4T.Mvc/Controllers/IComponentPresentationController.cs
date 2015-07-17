using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Mvc;
using DD4T.ContentModel.Factories;
using DD4T.ContentModel.Contracts.Factories;

namespace DD4T.Mvc.Controllers
{
    public interface IComponentPresentationController
    {
        IComponentPresentationFactory ComponentPresentationFactory { get; set; }
    }
}
