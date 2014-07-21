using System.Linq;
using System.Linq.Expressions;
using CodeSnippets.Extensions.LamdaExpression;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        /* Html.EnumDropDownListFor(model => model.Enum) */

        public static MvcHtmlString EnumDropDownFor<TModel, TEnum>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> enumAccessor)
        {
            var propertyInfo = enumAccessor.ToPropertyInfo();
            var enumType = propertyInfo.PropertyType;

            var enumValues = Enum.GetValues(enumType).Cast<Enum>();

            var selectItems = enumValues.Select(x => new SelectListItem()
            {
                Text = x.GetDescription(),
                Value = x.ToString()
            });

            return htmlHelper.DropDownListFor(enumAccessor, selectItems);
        }
    }
}