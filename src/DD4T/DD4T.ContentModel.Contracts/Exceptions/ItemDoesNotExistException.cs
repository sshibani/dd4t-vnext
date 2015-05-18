namespace DD4T.ContentModel.Exceptions
{
    using System;
#if DNX451
    [Serializable]
    public class ItemDoesNotExistException : ApplicationException
#elif DNXCORE5
    public class ItemDoesNotExistException : Exception
#endif
    {
    }
}
