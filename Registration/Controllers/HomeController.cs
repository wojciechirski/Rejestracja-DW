using NLog;
using Registration.Models;
using Registration.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ThankYou()
        {
            return View();
        }

        //POST: SendMailWithAtt
        [HttpPost]
        public ActionResult SendForm(RegistrationViewModel reservation)
        {
            if (ModelState.IsValid)
            {
                //tworzę wiadomość z danymi i odpowiedziami dla Ricoh
                StringBuilder sbRicoh = new StringBuilder();
                sbRicoh.Append("<span style=\"font-family: arial;\">Firma: <span style=\"color:green;\">" + reservation.Company.Trim() + "</span>");
                sbRicoh.Append("<br />Województwo: <span style=\"color:green;\">" + reservation.Address.Trim() + "</span>");
                sbRicoh.Append("<br />Imię: <span style=\"color:green;\">" + reservation.FirstName.Trim() + "</span>");
                sbRicoh.Append("<br />Nazwisko: <span style=\"color:green;\">" + reservation.LastName.Trim() + "</span>");
                sbRicoh.Append("<br />Email: <span style=\"color:green;\">" + reservation.Email.Trim() + "</span>");
                sbRicoh.Append("<br />Telefon: <span style=\"color:green;\">" + reservation.Telephone.Trim() + "</span>");

                if (reservation.Agree1Yes == true)
                {
                    sbRicoh.Append("<br />zgoda na przysłanie przez Ricoh Polska informacji przez email: <span style=\"color:green;\"> Tak</span>");
                }
                else
                {
                    sbRicoh.Append("<br />zgoda na przysłanie przez Ricoh Polska informacji przez email: <span style=\"color:green;\"> Nie</span>");
                }
                if (reservation.Agree2Yes == true)
                {
                    sbRicoh.Append("<br />zgoda na przysłanie przez Ricoh Polska informacji przez telefon: <span style=\"color:green;\"> Tak</span>");
                }
                else
                {
                    sbRicoh.Append("<br />zgoda na przysłanie przez Ricoh Polska informacji przez emtelefonail: <span style=\"color:green;\"> Nie</span>");
                }
                sbRicoh.Append("</span>");





                //tworzę wiadomość zwrotną do osoby rejestrującej się
                StringBuilder sbPerson = new StringBuilder();
                sbPerson.Append("<span style=\"font-family: arial;\">Dziękujemy za obejrzenie webcastu „Jak zarządzać dokumentami w dziale finansowo-księgowym w nowej rzeczywistości?” ");
                sbPerson.Append("<br /><br /><span style=\"font-weight: bold;\">Jeśli zainteresowało Państwa nasze rozwiązanie DocuWare, to zachęcamy do umówienia się na darmową konsultację.</span>");
                sbPerson.Append("<br /><span style=\"font-weight: bold;\">Kontakt do naszego specjalisty: Wojciech Jankowski,  wjankowski@ricoh.pl</span>");
                sbPerson.Append("<br /><br />Zachęcamy do obserwowania profilów Ricoh");

                sbPerson.Append("<br /><a href=\"https://www.linkedin.com/company/ricoh-poland\" target=\"_blank\"><img src=\"http://www.it.ricoh.pl/content/images/linkedin.png\" height=\"50\"></a>");
                sbPerson.Append("<br /><a href=\"https://www.facebook.com/ricohpolska\" target=\"_blank\"><img src=\"http://www.it.ricoh.pl/content/images/facebook.png\" height=\"50\"></a>");



                sbPerson.Append("<br /><br />Pozdrawiamy<br />Ricoh Polska<br /><br />");
                //sbPerson.Append("<br /><a href=\"https://www.linkedin.com/company/ricoh-poland\">Linkedin</a>");
                //sbPerson.Append("<br /><a href=\"https://www.facebook.com/ricohpolska\">Facebook</a>");
                //sbPerson.Append("<br /><a href=\"https://www.instagram.com/ricohpoland\">Instagram</a>");
                //sbPerson.Append("<br /><br /><img src=\"http://www.rejestracja.ricoh.pl/content/images/rejestracja.jpg\">");

                sbPerson.Append("</span>");


                try
                {
                    if (reservation.Agree1Yes)
                    {

                        RegistrationModel gm = new RegistrationModel();

                        gm.Company = reservation.Company;
                        gm.FirstName = reservation.FirstName;
                        gm.LastName = reservation.LastName;
                        gm.Email = reservation.Email;
                        gm.Telephone = reservation.Telephone;
                        gm.Address = reservation.Address;

                        gm.Agree1No = reservation.Agree1No;
                        gm.Agree1Yes = reservation.Agree1Yes;
                        gm.Agree2No = reservation.Agree2No;
                        gm.Agree2Yes = reservation.Agree2Yes;
                        gm.RegistrationDate = DateTime.Now;

                        _db.ReservationModels.Add(gm);
                        _db.SaveChanges();


                        // wysyłka wiadomości do Ricoh                       
                        string err = SendingEmails.SendMail("kdawidowska@ricoh.pl", "DocuWare webcast", sbRicoh.ToString());

                        //wysyłka potwierdzenia do osoby rejestrującej się
                        if (String.IsNullOrEmpty(err))
                        {
                            string errSend = SendingEmails.SendMail(reservation.Email.Trim(), "Dziękujemy za obejrzenie webcastu.", sbPerson.ToString());
                        }
                        else
                        {
                            ModelState.AddModelError("", "Wystąpił błąd. Aplikacja nie została wysłana.");
                            return PartialView("_fiveForm");
                        }
                        return PartialView("_fiveSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError("", "proszę zaznaczyć zgodę.");
                        return PartialView("_fiveForm");
                    }
                }
                catch (Exception ex)
                {
                    //RebuildViewbagLists();
                    _log.Error("### Wystąpił wyjątek: " + ex.Message);
                    ModelState.AddModelError("", "Wystąpił wyjątek, dane nie zostały wysłane.");
                    return PartialView("_fiveForm");
                }
            }
            else
            {
                // niepoprawny model
                //RebuildViewbagLists();
                return PartialView("_fiveForm");
            }
        }













        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}