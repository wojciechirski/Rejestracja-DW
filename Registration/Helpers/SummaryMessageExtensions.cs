using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Registration.Utils;

//Jeśli robię przekierowanie na inną stronę/wracam to używam
//Widok: nie używać w poście tylko w gecie, używam tam gdzie wracam @Html.SummaryMessage()
//Kontroler: //SummaryMessageManager.Add("Komunikat"); //SummaryMessageManager.Set(this, false);

namespace Registration.Helpers
{
    public static class SummaryMessageExtensions
    {
        public static IHtmlString SummaryMessage(this HtmlHelper htmlHelper)
        {
            SummaryMessages sm = new SummaryMessages();
            sm = SummaryMessageManager.Get(htmlHelper.ViewContext.Controller);

            string s;

            if (sm != null)
            {
                if (sm.IsSuccess)
                {
                    s = "<div class=\"alert alert-success alert-dismissible fade in\" role=\"alert\"> <button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">×</span></button>";

                    foreach (string msg in sm.messages)
                    {
                        s += msg + "</br>";
                    }

                    s += "</div>";
                }
                else
                {
                    s = "<div class=\"alert alert-danger alert-dismissible fade in\" role=\"alert\"> <button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">×</span></button>";

                    foreach (string msg in sm.messages)
                    {
                        s += msg + "</br>";
                    }

                    s += "</div>";
                }


                SummaryMessageManager.Reset(htmlHelper.ViewContext.Controller);
                return new HtmlString(s);
            }
            return new HtmlString("");
        }
    }
}