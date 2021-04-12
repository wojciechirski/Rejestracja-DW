using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Utils
{
    public class SummaryMessages
    {
        public bool IsSuccess { get; set; }
        public List<string> messages { get; set; }

        public SummaryMessages()
        {
            messages = new List<string>();
        }

    }

    public static class SummaryMessageManager
    {
        public static SummaryMessages Messages;
        static SummaryMessageManager()
        {
            Messages = new SummaryMessages();
        }

        public static void Add(string message)
        {
            Messages.messages.Add(message);
        }

        public static void Reset(ControllerBase cb)
        {
            cb.TempData["SummaryMessage"] = null;
            Messages.messages.Clear();
            Messages.IsSuccess = false;
        }

        public static void Set(ControllerBase cb, bool isSuccess)
        {
            Messages.IsSuccess = isSuccess;
            cb.TempData["SummaryMessage"] = Messages;
        }

        public static SummaryMessages Get(ControllerBase cb)
        {
            SummaryMessages sm = new SummaryMessages();
            sm = (SummaryMessages)cb.TempData["SummaryMessage"];
            return sm;
        }


    }
}