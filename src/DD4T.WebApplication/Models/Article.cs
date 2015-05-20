using DVM4T.Attributes;
using DVM4T.Base;
using DVM4T.DD4T.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.WebApplication.Models
{
    [ViewModel("Article", true, ViewModelKeys = new string[] { "Article", "ProductContent", "CP" })]
    public class Article : ViewModelBase
    {
        [TextField()]
        public string Headline { get; set; }

        //[TextField()]
        //public string ArticleBody { get; set; }

      

    }
}
