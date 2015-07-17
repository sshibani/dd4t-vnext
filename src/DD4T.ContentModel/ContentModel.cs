using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace DD4T.ContentModel
{
    public class ComponentMeta : IComponentMeta
    {
        public string ID { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastPublishedDate { get; set; }

        DateTime IComponentMeta.ModificationDate
        {
            get { return ModificationDate; }
        }

        DateTime IComponentMeta.CreationDate
        {
            get { return CreationDate; }
        }

        DateTime IComponentMeta.LastPublishedDate
        {
            get { return LastPublishedDate; }
        }
    }

    public class Page : RepositoryLocalItem, IPage
    {
        public DateTime RevisionDate { get; set; }
        public string Filename { get; set; }
        public DateTime LastPublishedDate { get; set; }

        public PageTemplate PageTemplate { get; set; }
         
        IPageTemplate IPage.PageTemplate
        {
            get { return PageTemplate; }
        }

        public Schema Schema { get; set; }
         
        ISchema IPage.Schema
        {
            get { return Schema; }
        }
        public FieldSet MetadataFields { get; set; }
         
        IFieldSet IPage.MetadataFields
        {
            get
            {
                return MetadataFields != null ? MetadataFields as IFieldSet : null;
            }
        }
        public List<ComponentPresentation> ComponentPresentations { get; set; }
         
        IList<IComponentPresentation> IPage.ComponentPresentations
        {
            get { return ComponentPresentations.ToList<IComponentPresentation>(); }
        }

        public OrganizationalItem StructureGroup { get; set; }
         
        IOrganizationalItem IPage.StructureGroup
        {
            get { return StructureGroup; }
        }
        public List<Category> Categories { get; set; }
         
        IList<ICategory> IPage.Categories
        {
            get { return Categories.ToList<ICategory>(); }
        }

        public int Version { get; set; }
    }

    public class Keyword : RepositoryLocalItem, IKeyword
    {
        
        public string Description { get; set; }
        
        public string Key { get; set; }
        
        public string TaxonomyId { get; set; }
        
        public string Path { get; set; }
        private List<IKeyword> parentKeywords = new List<IKeyword>();
         
        public IList<IKeyword> ParentKeywords { get { return parentKeywords; } }


        public FieldSet MetadataFields { get; set; }
         
        IFieldSet IKeyword.MetadataFields
        {
            get { return MetadataFields != null ? (MetadataFields as IFieldSet) : null; }
        }

        public Keyword()
        {
            this.MetadataFields = new FieldSet();
        }
    }

    public class Category : RepositoryLocalItem, ICategory
    {
        public List<Keyword> Keywords { get; set; }
         
        IList<IKeyword> ICategory.Keywords
        { get { return Keywords.ToList<IKeyword>(); } }
    }

    public class ComponentPresentation : IComponentPresentation
    {
         
        public IPage Page { get; set; }
        public Component Component { get; set; }
         
        IComponent IComponentPresentation.Component
        {
            get { return Component as IComponent; }
        }
        public ComponentTemplate ComponentTemplate { get; set; }
         
        IComponentTemplate IComponentPresentation.ComponentTemplate
        {
            get { return ComponentTemplate as IComponentTemplate; }
        }
        public string RenderedContent { get; set; }
        public bool IsDynamic { get; set; }

         
        public int OrderOnPage { get; set; }

        public List<Condition> Conditions { get; set; }

         
        IList<ICondition> IComponentPresentation.Conditions
        {
            get { return Conditions.ToList<ICondition>(); }
        }
    }

    public class PageTemplate : RepositoryLocalItem, IPageTemplate
    {
        public string FileExtension { get; set; }
        public DateTime RevisionDate { get; set; }
        public FieldSet MetadataFields { get; set; }
         
        IFieldSet ITemplate.MetadataFields
        {
            get
            {
                return MetadataFields != null ? MetadataFields as IFieldSet : null;
            }
        }
        public OrganizationalItem Folder { get; set; }
         
        IOrganizationalItem ITemplate.Folder
        {
            get { return Folder as IOrganizationalItem; }
        }
    }

    public class ComponentTemplate : RepositoryLocalItem, IComponentTemplate
    {
        public string OutputFormat { get; set; }
        public DateTime RevisionDate { get; set; }
        public FieldSet MetadataFields { get; set; }
         
        IFieldSet ITemplate.MetadataFields
        {
            get
            {
                return MetadataFields != null ? MetadataFields as IFieldSet : null;
            }
        }
        public OrganizationalItem Folder { get; set; }
         
        IOrganizationalItem ITemplate.Folder
        {
            get { return Folder as IOrganizationalItem; }
        }
    }

    public class Component : RepositoryLocalItem, IComponent
    {

        #region Properties
        public DateTime LastPublishedDate { get; set; }
        public DateTime RevisionDate { get; set; }
        public Schema Schema { get; set; }
         
        ISchema IComponent.Schema
        {
            get { return Schema; }
        }

        public FieldSet Fields { get; set; }
         
        IFieldSet IComponent.Fields
        {
            get { return Fields != null ? (Fields as IFieldSet) : null; }
        }
        public FieldSet MetadataFields { get; set; }
         
        IFieldSet IComponent.MetadataFields
        {
            get { return MetadataFields != null ? (MetadataFields as IFieldSet) : null; }
        }
        public ComponentType ComponentType { get; set; }
        public Multimedia Multimedia { get; set; }
         
        IMultimedia IComponent.Multimedia
        {
            get { return Multimedia as IMultimedia; }
        }
        public OrganizationalItem Folder { get; set; }
         
        IOrganizationalItem IComponent.Folder
        {
            get { return Folder as IOrganizationalItem; }
        }
        public List<Category> Categories { get; set; }
         
        IList<ICategory> IComponent.Categories
        {
            get { return Categories.ToList<ICategory>(); } //as IList<ICategory>; 
        }

        public int Version { get; set; }

        #endregion Properties

        #region constructors
        public Component()
        {
            this.Categories = new List<Category>();
            this.Schema = new Schema();
            this.Fields = new FieldSet();
            this.MetadataFields = new FieldSet();
        }
        #endregion constructors
    }
    public class Schema : RepositoryLocalItem, ISchema
    {
        public OrganizationalItem Folder { get; set; }
         
        IOrganizationalItem ISchema.Folder
        {
            get { return Folder as IOrganizationalItem; }
        }

        public string RootElementName
        {
            get;
            set;
        }
    }
    public enum MergeAction { Replace, Merge, MergeMultiValueSkipSingleValue, MergeMultiValueReplaceSingleValue, Skip }


    public class FieldSet : Dictionary<string, IField>, IFieldSet //SerializableDictionary<string, IField, Field>, IFieldSet, IXmlSerializable
    {
        public FieldSet()
            : base()
        {
        }

        //protected FieldSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }


    public class Field : IField
    {
        #region Properties
        public string Name
        {
            get;
            set;
        }
        public string Value
        {
            get
            {
                if (this.Values == null || this.Values.Count == 0)
                    return string.Empty;
                return this.Values[0];
            }
        }
        public List<string> Values
        {
            get;
            set;
        }
         
        IList<string> IField.Values
        {
            get { return Values as IList<string>; }
        }
        public List<double> NumericValues
        {
            get;
            set;
        }
         
        IList<double> IField.NumericValues
        {
            get { return NumericValues as IList<double>; }
        }
        public List<DateTime> DateTimeValues
        {
            get;
            set;
        }
         
        IList<DateTime> IField.DateTimeValues
        {
            get { return DateTimeValues as IList<DateTime>; }
        }
        public List<Component> LinkedComponentValues
        {
            get;
            set;
        }
         
        IList<IComponent> IField.LinkedComponentValues
        {
            get { return LinkedComponentValues.ToList<IComponent>(); }
        }
        public List<FieldSet> EmbeddedValues
        {
            get;
            set;
        }
         
        IList<IFieldSet> IField.EmbeddedValues
        {
            get
            {
                return EmbeddedValues.Select<FieldSet, IFieldSet>(e => e as IFieldSet).ToList<IFieldSet>();
            }
        }


        public Schema EmbeddedSchema
        {
            get;
            set;
        }
         
        ISchema IField.EmbeddedSchema
        {
            get
            {
                return EmbeddedSchema as ISchema;
            }
        }


        
        public FieldType FieldType
        {
            get;
            set;
        }

        
        public string CategoryName
        {
            get;
            set;
        }

        
        public string CategoryId
        {
            get;
            set;
        }

        
        public string XPath
        {
            get;
            set;
        }

        public List<Keyword> Keywords
        {
            get
            {
                return KeywordValues;
            }
            set
            {
                KeywordValues = value;
            }
        }

         
        public List<Keyword> KeywordValues
        {
            get;
            set;
        }

         
        IList<IKeyword> IField.Keywords
        {
            get { return KeywordValues.ToList<IKeyword>(); }
        }
         
        IList<IKeyword> IField.KeywordValues
        {
            get { return KeywordValues.ToList<IKeyword>(); }
        }

        #endregion Properties
        #region Constructors
        public Field()
        {
            this.Keywords = new List<Keyword>();
            this.Values = new List<string>();
            this.NumericValues = new List<double>();
            this.DateTimeValues = new List<DateTime>();
            this.LinkedComponentValues = new List<Component>();
        }
        #endregion Constructors
    }

    public abstract class TridionItem : IItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
    public abstract class RepositoryLocalItem : TridionItem, IRepositoryLocal
    {
        public string PublicationId { get; set; }
        public Publication Publication { get; set; }
         
        IPublication IRepositoryLocal.Publication
        {
            get { return Publication; }
        }
        public Publication OwningPublication { get; set; }
         
        IPublication IRepositoryLocal.OwningPublication
        {
            get { return OwningPublication; }
        }
    }

    public class OrganizationalItem : RepositoryLocalItem, IOrganizationalItem
    {
    }

    public class Publication : TridionItem, IPublication
    {
    }

    public class TcmUri
    {
        public int ItemId { get; set; }
        public int PublicationId { get; set; }
        public int ItemTypeId { get; set; }
        public int Version { get; set; }


        public TcmUri(string Uri)
        {
            Regex re = new Regex(@"tcm:(\d+)-(\d+)-?(\d*)-?v?(\d*)");
            Match m = re.Match(Uri);
            if (m.Success)
            {
                PublicationId = Convert.ToInt32(m.Groups[1].Value);
                ItemId = Convert.ToInt32(m.Groups[2].Value);
                if (m.Groups.Count > 3 && !string.IsNullOrEmpty(m.Groups[3].Value))
                {
                    ItemTypeId = Convert.ToInt32(m.Groups[3].Value);
                }
                else
                {
                    ItemTypeId = 16;
                }
                if (m.Groups.Count > 4 && !string.IsNullOrEmpty(m.Groups[4].Value))
                {
                    Version = Convert.ToInt32(m.Groups[4].Value);
                }
                else
                {
                    Version = 0;
                }
            }
        }
        public TcmUri(int PublicationId, int ItemId, int ItemTypeId, int Version)
        {
            this.PublicationId = PublicationId;
            this.ItemId = ItemId;
            this.ItemTypeId = ItemTypeId;
            this.Version = Version;
        }
        public override string ToString()
        {
            if (this.ItemTypeId == 16)
            {
                return string.Format("tcm:{0}-{1}", this.PublicationId, this.ItemId);
            }
            return string.Format("tcm:{0}-{1}-{2}", this.PublicationId, this.ItemId, this.ItemTypeId);
        }
        public static TcmUri NullUri
        {
            get
            {
                return new TcmUri(0, 0, 0, 0);
            }
        }
    }

    public class Multimedia : IMultimedia
    {
        public string Url
        {
            get;
            set;
        }
        public string MimeType
        {
            get;
            set;
        }
        public string AltText
        {
            get;
            set;
        }
        public string FileName
        {
            get;
            set;
        }
        public string FileExtension
        {
            get;
            set;
        }
        public long Size
        {
            get;
            set;
        }
        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
    }


    public class Binary : Component, IBinary
    {
        public byte[] BinaryData { get; set; }
        public string VariantId { get; set; }
        public string Url { get; set; }
        public System.IO.Stream BinaryStream { get; set; }
    }

    public class TargetGroup : RepositoryLocalItem, ITargetGroup
    {
        public string Description { get; set; }

        public List<Condition> Conditions { get; set; }

         
        IList<ICondition> ITargetGroup.Conditions { get { return Conditions.ToList<ICondition>(); } }
    }

    public class Condition : ICondition
    {
        public bool Negate { get; set; }
    }

    public class KeywordCondition : Condition
    {
        public Keyword Keyword { get; set; }
        public NumericalConditionOperator Operator { get; set; }
        public object Value { get; set; }
    }

    public class CustomerCharacteristicCondition : Condition
    {
        public string Name { get; set; }
        public ConditionOperator Operator { get; set; }
        public object Value { get; set; }
    }

    public class TargetGroupCondition : Condition
    {
        public TargetGroup TargetGroup { get; set; }
    }
}
