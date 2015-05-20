using DVM4T.Attributes;
using DVM4T.Base;
using DVM4T.DD4T.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.WebApplication.Models
{

    [PageViewModel(new [] { "GeneralPage" })]
    public class GeneralPage : ViewModelBase
    {

        [PresentationsByView(ViewPrefix = "Product")]
        public List<Product> Product { get; set; }
        
        [PresentationsByView(ViewPrefix = "Article")]
        public List<Article> Article { get; set; }
    }
}
