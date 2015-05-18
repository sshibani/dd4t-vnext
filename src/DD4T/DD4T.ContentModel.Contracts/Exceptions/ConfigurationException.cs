namespace DD4T.ContentModel.Exceptions
{
    using System;
#if DNX451
    [Serializable]
    public class ConfigurationException : ApplicationException
#elif DNXCORE5
    public class ConfigurationException : Exception
#endif
    {
        public ConfigurationException()
            : base()
        {
        }
        public ConfigurationException(string message)
            : base(message)
        {
        }
        public ConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
