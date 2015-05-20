using DVM4T.Attributes;
using DVM4T.Base;
using DVM4T.DD4T.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.WebApplication.Models
{
    [ViewModel("Product", true, ViewModelKeys = new string[] { "Product", "ProductContent", "CP" })]
    public class Product : ViewModelBase
    {
        [TextField()]
        public string Title { get; set; }

        [TextField()]
        public string Description { get; set; }

      

    }
}
