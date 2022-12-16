using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Store.Models.ViewModels;

namespace Store.Infrastructure
{
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelper;
        public PageLinkTagHelper(IUrlHelperFactory urlHelper)
        {
            this._urlHelper = urlHelper;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext _ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper _url = _urlHelper.GetUrlHelper(_ViewContext);
            TagBuilder result = new TagBuilder("div");
            for(int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = _url.Action(PageAction, new { page = 1 });
                tag.InnerHtml.Append(i.ToString());
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
