using DD4T.ContentModel.Factories;


namespace DD4T.Mvc.Controllers
{
    public interface IPageController
    {
        IPageFactory PageFactory { get; }
        // IComponentPresentationRenderer ComponentPresentationRenderer { get; set; }
    }
}
