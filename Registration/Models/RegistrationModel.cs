using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Registration.Models
{


    //public enum ParticipationRODO : int
    //{
    //    [Display(Name = "Wybierz")]
    //    Select = 0,
    //    [Display(Name = "10:00-11:30")]
    //    Tenth = 1,
    //    [Display(Name = "13:30-15:00")]
    //    Thirteenth = 2,
    //    [Display(Name = "Nie wezmę udziału")]
    //    No = 3,
    //}

    public enum KnowAboutUs : int
    {
        [Display(Name = "Wybierz skąd dowiedział się Pan/Pani o naszym evencie")]
        Select = 0,
        [Display(Name = "Ricoh Polska")]
        RicohPolska = 1,
        [Display(Name = "Partner Ricoh")]
        PartnerRicoh = 2,
        [Display(Name = "Inne")]
        Other = 3,

    }

    public enum EventLocation : int
    {
        [Display(Name = "Wybierz datę")]
        Select = 0,
        //[Display(Name = "11.03.2020 - Szczecin")]
        //Szczecin = 1,
        //[Display(Name = "12.03.2020 - Poznań")]
        //Poznan = 2,
        [Display(Name = "17.03.2020")]
        Wroclaw = 3,
        [Display(Name = "25.03.2020")]
        Warsaw = 4,
        [Display(Name = "01.04.2020")]
        Katowice = 5,

    }



    [Table("Reservation")]
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        //przetwarzanie danych osobowych
        public bool Agree1No { get; set; }
        //przetwarzanie danych osobowych
        public bool Agree1Yes { get; set; }
        //przesyłanie informacji handlowych
        public bool Agree2No { get; set; }
        //przesyłanie informacji handlowych
        public bool Agree2Yes { get; set; }
        //przesyłanie materiałów marketingowych
        public bool Agree3No { get; set; }
        //przesyłanie materiałów marketingowych
        public bool Agree3Yes { get; set; }

        public string Description { get; set; }
        public string Additionals { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? CancelationDate { get; set; }

        public RegistrationModel()
        {
            ProjectName = "Docuware2020";
        }
    }
}