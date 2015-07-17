
namespace DD4T.ContentModel
{
    public enum ComponentType { Multimedia, Normal }
    public enum FieldType { Text, MultiLineText, Xhtml, Keyword, Embedded, MultiMediaLink, ComponentLink, ExternalLink, Number, Date }
    public enum NumericalConditionOperator {  UnknownByClient = -2147483648,   Equals = 0,   GreaterThan = 1,   LessThan = 2,   NotEqual = 3, }
    public enum ConditionOperator {   UnknownByClient = -2147483648,   Equals = 0,   GreaterThan = 1,   LessThan = 2,   NotEqual = 3,   StringEquals = 4,   Contains = 5,   StartsWith = 6,   EndsWith = 7, }
}
