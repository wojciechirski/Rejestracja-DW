using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Registration.Helpers
{
    public static class ActionLinkSortableExtensions
    {


        //public static MvcHtmlString ActionLinkSortable(this HtmlHelper htmlHelper, string linkText, string actionName, string sortField, string currentSort, object currentDesc)
        //{
        //    bool desc = (currentDesc == null) ? false : Convert.ToBoolean(currentDesc);
        //    //get link route values   
        //    var routeValues = new System.Web.Routing.RouteValueDictionary();
        //    routeValues.Add("id", sortField);
        //    routeValues.Add("desc", (currentSort == sortField) && !desc);
        //    //build the tag   
        //    if (currentSort == sortField) linkText = string.Format("{0} <span class='badge'><span class='glyphicon glyphicon-sort-by-attributes{1}'></span></span>", linkText, (desc) ? "-alt" : "");
        //    TagBuilder tagBuilder = new TagBuilder("a");
        //    tagBuilder.InnerHtml = linkText;
        //    //add url to the link   
        //    var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        //    var url = urlHelper.Action(actionName, routeValues);
        //    tagBuilder.MergeAttribute("href", url);
        //    //put it all together   
        //    return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        //}


        //public static MvcHtmlString ActionLinkSortableFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string actionName, string sortField, string currentSort, object currentDesc)
        //{
        //    var metadata = ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, new ViewDataDictionary<TModel>());
        //    var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
        //    string s = metadata.DisplayName ?? (metadata.PropertyName ?? htmlFieldName.Split(new char[] { '.' }).Last<string>());

        //    bool desc = (currentDesc == null) ? false : Convert.ToBoolean(currentDesc);
        //    //get link route values   
        //    var routeValues = new System.Web.Routing.RouteValueDictionary();
        //    routeValues.Add("id", sortField);
        //    routeValues.Add("desc", (currentSort == sortField) && !desc);
        //    //build the tag   
        //    if (currentSort == sortField) s = string.Format("{0} <span class='badge'><span class='glyphicon glyphicon-sort-by-attributes{1}'></span></span>", s, (desc) ? "-alt" : "");
        //    TagBuilder tagBuilder = new TagBuilder("a");
        //    tagBuilder.InnerHtml = s;
        //    //add url to the link   
        //    var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        //    var url = urlHelper.Action(actionName, routeValues);
        //    tagBuilder.MergeAttribute("href", url);
        //    //put it all together   
        //    return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));


        //}

        public static MvcHtmlString ActionLinkSortableFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression, string actionName, string sortField, string currentSort, object currentDesc, RouteValueDictionary extendedRouteValues = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, new ViewDataDictionary<TModel>());
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string s = metadata.DisplayName ?? (metadata.PropertyName ?? htmlFieldName.Split(new char[] { '.' }).Last<string>());

            bool desc = (currentDesc == null) ? false : Convert.ToBoolean(currentDesc);
            //get link route values   
            //var routeValues = new System.Web.Routing.RouteValueDictionary();
            //routeValues.Add("sortby", sortField);
            //routeValues.Add("sortdesc", (currentSort == sortField) && !desc);

            RouteValueDictionary routeCombined;

            if (extendedRouteValues != null)
            {
                RouteValueDictionary routeValues = new RouteValueDictionary();
                routeValues.Add("sortby", sortField);
                routeValues.Add("sortdesc", (currentSort == sortField) && !desc);
                routeCombined = new RouteValueDictionary(routeValues.Union(extendedRouteValues).ToDictionary(k => k.Key, k => k.Value));
            }
            else
            {
                routeCombined = new RouteValueDictionary();
                routeCombined.Add("sortby", sortField);
                routeCombined.Add("sortdesc", (currentSort == sortField) && !desc);
            }

            //build the tag   
            if (currentSort == sortField)
                s = string.Format("{0} <i class='fa fa-sort-{1} fa-fw'></i>", s, (desc) ? "desc" : "asc");
            else
                s = string.Format("{0} <i class='fa fa-sort fa-fw'></i>", s);
            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = s;
            //add url to the link   
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName, routeCombined);
            tagBuilder.MergeAttribute("href", url);
            //put it all together   
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));


        }


    }
}