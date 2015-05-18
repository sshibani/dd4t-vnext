using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DD4T.ContentModel.Exceptions
{
#if DNX451
    [Serializable]
    public class ComponentNotFoundException : ApplicationException
#elif DNXCORE5
    public class ComponentNotFoundException : Exception
#endif
    {
    }
}
