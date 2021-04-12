using MailBee;
using MailBee.SmtpMail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registration.Utils
{
    public class SendingEmails
    {
        public static string SmtpServerHost
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpServerHost"];
            }
        }

        public static string EncodeParam(string input)
        {
            string enc = string.Empty;
            try
            {
                enc = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            }
            catch
            {
                return "";
            }
            return enc;
        }

        public static string DecodeParam(string input)
        {
            string dec = string.Empty;
            try
            {
                dec = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input));
            }
            catch
            {
                return "";
            }
            return dec;
        }

        public static void SetError(Control ctrl, string error)
        {
            Literal lit = (Literal)ctrl;
            lit.Text = "<p class=\"error\">" + error + "</p>";
        }

        public static void SetInfo(Control ctrl, string info)
        {
            Literal lit = (Literal)ctrl;
            lit.Text = info;
        }

        public static string SendMailBcc(string rectp, string bcc_rectp, string subject, string body)
        {
            if (string.IsNullOrEmpty(rectp)) return "Utils.SendMail error: Recipient mail empty.";

            try
            {
                MailBee.SmtpMail.Smtp.LicenseKey = "MN200-F33B3CD13B2D3B253BB3428A32F6-7DB8";
                MailBee.SmtpMail.Smtp smtp = new Smtp();

                smtp.Message.From.AsString = "noreply@ricoh.pl";
                smtp.Message.To.AsString = rectp;
                smtp.Message.Bcc.AsString = bcc_rectp;
                smtp.Message.Subject = subject;
                smtp.Message.From.DisplayName = "RICOH Polska";

                smtp.Message.Charset = "utf-8";
                smtp.Message.MailTransferEncodingHtml = MailBee.Mime.MailTransferEncoding.QuotedPrintable;
                smtp.Message.EncodeAllHeaders(Encoding.Default, MailBee.Mime.HeaderEncodingOptions.Base64);

                smtp.Message.BodyHtmlText = body;
                smtp.SmtpServers.Add(SmtpServerHost);

                smtp.Send();
            }
            catch (MailBeeException ex)
            {
                return ex.Message;
            }
            return "";
        }


        public static string SendMail(string rectp, string subject, string body)
        {
            if (string.IsNullOrEmpty(rectp)) return "Utils.SendMail error: Recipient mail empty.";

            try
            {
                MailBee.SmtpMail.Smtp.LicenseKey = "MN200-F33B3CD13B2D3B253BB3428A32F6-7DB8";
                MailBee.SmtpMail.Smtp smtp = new Smtp();

                smtp.Message.From.AsString = "no.reply1234@ricoh.pl";
                smtp.Message.To.AsString = rectp;
                smtp.Message.Subject = subject;
                smtp.Message.From.DisplayName = "RICOH Polska";

                smtp.Message.Charset = "utf-8";
                smtp.Message.MailTransferEncodingHtml = MailBee.Mime.MailTransferEncoding.QuotedPrintable;
                smtp.Message.EncodeAllHeaders(Encoding.Default, MailBee.Mime.HeaderEncodingOptions.Base64);

                smtp.Message.BodyHtmlText = body;
                smtp.SmtpServers.Add(SmtpServerHost);

                smtp.Send();
            }
            catch (MailBeeException ex)
            {
                return ex.Message;
            }
            return "";
        }

        public static string SendMail(string rectp, string subject, string body, byte[] att, string attName)
        {
            if (string.IsNullOrEmpty(rectp)) return "Utils.SendMail error: Recipient mail empty.";

            try
            {
                MailBee.SmtpMail.Smtp.LicenseKey = "MN200-F33B3CD13B2D3B253BB3428A32F6-7DB8";
                MailBee.SmtpMail.Smtp smtp = new Smtp();

                smtp.Message.From.AsString = "no.reply1234@ricoh.pl";
                smtp.Message.To.AsString = rectp;
                smtp.Message.Subject = subject;
                smtp.Message.From.DisplayName = "RICOH Polska";

                smtp.Message.Charset = "utf-8";
                smtp.Message.MailTransferEncodingHtml = MailBee.Mime.MailTransferEncoding.QuotedPrintable;
                smtp.Message.EncodeAllHeaders(Encoding.Default, MailBee.Mime.HeaderEncodingOptions.Base64);

                smtp.Message.Attachments.Add(att, attName, "as656as78ds", "applicationPdf", null, MailBee.Mime.NewAttachmentOptions.None, MailBee.Mime.MailTransferEncoding.Base64);

                smtp.Message.BodyHtmlText = body;
                smtp.SmtpServers.Add(SmtpServerHost);

                smtp.Send();
            }
            catch (MailBeeException ex)
            {
                return ex.Message;
            }
            return "";
        }


        public static string SendMail(string rectp, string subject, string body, byte[] att1, byte[] att2, string attName1, string attName2)
        {
            if (string.IsNullOrEmpty(rectp)) return "Utils.SendMail error: Recipient mail empty.";

            try
            {
                MailBee.SmtpMail.Smtp.LicenseKey = "MN200-F33B3CD13B2D3B253BB3428A32F6-7DB8";
                MailBee.SmtpMail.Smtp smtp = new Smtp();

                smtp.Message.From.AsString = "no.reply1234@ricoh.pl";
                smtp.Message.To.AsString = rectp;
                smtp.Message.Subject = subject;
                smtp.Message.From.DisplayName = "RICOH Polska";

                smtp.Message.Charset = "utf-8";
                smtp.Message.MailTransferEncodingHtml = MailBee.Mime.MailTransferEncoding.QuotedPrintable;
                smtp.Message.EncodeAllHeaders(Encoding.Default, MailBee.Mime.HeaderEncodingOptions.Base64);

                smtp.Message.Attachments.Add(att1, attName1, "as656as78ds", "application/octet-stream", null, MailBee.Mime.NewAttachmentOptions.None, MailBee.Mime.MailTransferEncoding.Base64);
                smtp.Message.Attachments.Add(att2, attName2, "as656as79ds", "application/octet-stream", null, MailBee.Mime.NewAttachmentOptions.None, MailBee.Mime.MailTransferEncoding.Base64);

                smtp.Message.BodyHtmlText = body;
                smtp.SmtpServers.Add(SmtpServerHost);

                smtp.Send();
            }
            catch (MailBeeException ex)
            {
                return ex.Message;
            }
            return "";
        }




        public static string SendMailConfirmation(string rectp, string subject, string body)
        {
            if (string.IsNullOrEmpty(rectp)) return "Utils.SendMail error: Recipient mail empty.";

            try
            {
                MailBee.SmtpMail.Smtp.LicenseKey = "MN200-F33B3CD13B2D3B253BB3428A32F6-7DB8";
                MailBee.SmtpMail.Smtp smtp = new Smtp();

                smtp.Message.From.AsString = "no.reply1234@ricoh.pl";
                smtp.Message.To.AsString = rectp;
                smtp.Message.Subject = subject;
                smtp.Message.From.DisplayName = "RICOH Polska";

                smtp.Message.Charset = "utf-8";
                //smtp.Message.LoadBodyText(Utils.ResourcesFolder + "\\mail_confirmation.html", MailBee.Mime.MessageBodyType.Html, null,
                //                    MailBee.Mime.ImportBodyOptions.ImportRelatedFiles);
                smtp.SmtpServers.Add(SmtpServerHost);

                smtp.Send();
            }
            catch (MailBeeException ex)
            {
                return ex.Message;
            }
            return "";
        }


    }
}