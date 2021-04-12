using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

//Jeśli zostaję na tej samej podstronie to używam. 
//Widok: @Html.BS_ValidationSummary(true) 
//Kontroler: ModelState.AddModelError("jeśli puste to błąd nie związany z propertą, jeśli nazwa property to związany", "Komunikat")
namespace Registration.Helpers
{
    public static class BootStrapValidationSummaryExtensions
    {
        public static MvcHtmlString BS_ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            bool anyErrors = false;
            var sb = new StringBuilder();
            List<ModelState> modelStateList = new List<ModelState>();

            if (excludePropertyErrors)
            {
                ModelState modelState;
                htmlHelper.ViewData.ModelState.TryGetValue(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, out modelState);
                if (modelState != null)
                {
                    modelStateList.Add(modelState);
                    anyErrors = true;
                }
                else
                {
                    anyErrors = false;
                }
            }
            else
            {
                anyErrors = htmlHelper.ViewData.ModelState.Values.Where(v => v.Errors.Count != 0).Any();
                if (anyErrors)
                {
                    modelStateList = htmlHelper.ViewData.ModelState.Values.ToList();
                }
            }

            var divBeginTag = "<div class=\"alert alert-danger alert-dismissible fade in\" role=\"alert\"> <button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">×</span></button>";
            var divEndTag = @"</div>";

            if (anyErrors)
            {
                sb.AppendLine(divBeginTag);

                foreach (ModelState ms in modelStateList)
                {
                    foreach (var error in ms.Errors)
                    {
                        sb.AppendLine(error.ErrorMessage + "</br>");
                    }
                }

                sb.AppendLine(divEndTag);
                return new MvcHtmlString(sb.ToString());
            }
            else
            {
                return new MvcHtmlString(sb.ToString());
            }


        }
    }
}