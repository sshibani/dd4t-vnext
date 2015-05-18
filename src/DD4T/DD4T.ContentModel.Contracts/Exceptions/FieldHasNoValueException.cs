namespace DD4T.ContentModel.Exceptions
{
    using System;
#if DNX451
    [Serializable]
    public class FieldHasNoValueException : ApplicationException
#elif DNXCORE5
    public class FieldHasNoValueException : Exception
#endif
    {
    }
}
