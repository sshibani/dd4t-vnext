using System.IO;

namespace DD4T.ContentModel
{
    public interface IBinary : IComponent, IRepositoryLocal, IItem, IModel, IViewable
    {
        byte[] BinaryData { get; set; }
        Stream BinaryStream { get; set; }
        string Url { get; set; }
        string VariantId { get; }
    }
}
