namespace DD4T.ContentModel.Exceptions
{
    using System;
#if DNX451
    [Serializable]
    public class FieldTypeNotDefinedException : ApplicationException
#elif DNXCORE5
    public class FieldTypeNotDefinedException : Exception
#endif
    {
    }
}
