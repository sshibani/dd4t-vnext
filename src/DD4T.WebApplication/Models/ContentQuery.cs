using DVM4T.Attributes;
using DVM4T.Base;
using DVM4T.DD4T.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.WebApplication.Models
{
    [ViewModel("ContentQuery", true, ViewModelKeys = new string[] { "ContentQuery"  })]
    public class ContentQuery : ViewModelBase
    {
        [TextField()]
        public string Headline { get; set; }   

    }
}
