namespace DD4T.ContentModel.Exceptions
{
    using System;

#if DNX451
    [Serializable]
    public class ModelNotCreatedException : ApplicationException
#elif DNXCORE5
    public class ModelNotCreatedException : Exception
#endif
    {
        public ModelNotCreatedException(string viewName)
            : base(string.Format("model for view '{0}' is not created", viewName))
        {
        }

        public ModelNotCreatedException(string viewName, Exception innerException)
            : base(string.Format("model for view '{0}' is not created", viewName), innerException)
        {
        }
    }
}
