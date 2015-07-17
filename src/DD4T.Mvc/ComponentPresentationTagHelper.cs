using DD4T.ContentModel.Contracts.Factories;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Mvc
{
    [TargetElement("cp", Attributes = "componentId, templateId")]
    public class ComponentPresentationTagHelper : TagHelper
    {
        //Just trying out
      
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            var componentId = context.AllAttributes["componentId"].ToString();
            var tempalteId = context.AllAttributes["templateId"].ToString();
            output.TagName = "div";
            output.PreContent.SetContent("<ul class=\"link-list\">");

   
        }
    }
}
