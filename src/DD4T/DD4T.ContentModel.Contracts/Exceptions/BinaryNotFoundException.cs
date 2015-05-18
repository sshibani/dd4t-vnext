namespace DD4T.ContentModel.Exceptions
{
    using System;

#if DNX451
    [Serializable]
    public class BinaryNotFoundException : ApplicationException
#elif DNXCORE5
        public class BinaryNotFoundException : Exception
#endif
    {
    }
}
