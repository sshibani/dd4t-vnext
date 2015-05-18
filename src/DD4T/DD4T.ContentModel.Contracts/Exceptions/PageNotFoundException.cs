namespace DD4T.ContentModel.Exceptions
{
    using System;
#if DNX451
    [Serializable]
    public class PageNotFoundException : ApplicationException
#elif DNXCORE5
    public class PageNotFoundException : Exception
#endif
    {
    }
}
