namespace DD4T.ContentModel.Exceptions
{
    using System;

#if DNX451
    [Serializable]
    public class KeywordNotFoundException : ApplicationException
#elif DNXCORE5
    public class KeywordNotFoundException : Exception
#endif
    {
    }
}
