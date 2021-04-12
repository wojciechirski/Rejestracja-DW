using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Registration.Helpers
{
    public static class DisplayLongExtensions
    {
        public static MvcHtmlString DisplayLongFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string propertyName = data.PropertyName;

            if (data.ModelType == typeof(String))
            {
                if (String.IsNullOrEmpty((string)data.Model))
                    return MvcHtmlString.Empty;
                else
                {
                    string m = (string)data.Model;
                    TagBuilder tagBuilder = new TagBuilder("span");
                    if (m.Length > 30)
                    {
                        tagBuilder.Attributes.Add("data-toggle", "tooltip");
                        tagBuilder.Attributes.Add("title", m);
                        string s = m.Substring(0, 29) + "...";
                        tagBuilder.SetInnerText(s);
                    }
                    else
                    {
                        tagBuilder.SetInnerText(m);
                    }

                    return new MvcHtmlString(tagBuilder.ToString());

                }
            }
            return MvcHtmlString.Empty;
        }

    }
}