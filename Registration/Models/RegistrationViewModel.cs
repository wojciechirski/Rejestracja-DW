using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registration.Models
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nazwa Firmy jest wymagana")]
        [Required(ErrorMessage = "Firma")]
        public string Company { get; set; }

        [DisplayName("Województwo")]
        [Required(ErrorMessage = "Województwo jest wymagane")]
        public string Address { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Email musi być wpisany poprawnie")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Telefon jest wymagany")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wymagany format telefonu: XXXXXXXXX")]
        [StringLength(9, ErrorMessage = "Wymagany format telefonu: XXXXXXXXX", MinimumLength = 9)]
        public string Telephone { get; set; }

        //[DisplayName("Udział w seminarium RODO")]
        //[Range(1, 3, ErrorMessage = "Proszę wybrać godziny")]
        //public ParticipationRODO ParticipationRODO { get; set; }

        //[DisplayName("Udział w wydarzeniu")]
        //[Range(1, 5, ErrorMessage = "Proszę wybrać datę i miejsce wydarzenia")]
        //public EventLocation EventLocation { get; set; }

        //[DisplayName("Skąd dowiedział się Pan/Pani o naszym evencie")]
        //[Range(1, 3, ErrorMessage = "Proszę wybrać skąd dowiedział się Pan/Pani o naszym evencie")]
        //public KnowAboutUs KnowAboutUs { get; set; }

        [DisplayName("Nie")]
        //przetwarzanie danych osobowych
        public bool Agree1No { get; set; }

        [DisplayName("Tak")]
        //przetwarzanie danych osobowych
        public bool Agree1Yes { get; set; }

        [DisplayName("Nie")]
        //przesyłanie informacji handlowych
        public bool Agree2No { get; set; }

        [DisplayName("Tak")]
        //przesyłanie informacji handlowych
        public bool Agree2Yes { get; set; }

        [DisplayName("Nie")]
        //przesyłanie materiałów marketingowych
        public bool Agree3No { get; set; }

        [DisplayName("Tak")]
        //przesyłanie materiałów marketingowych
        public bool Agree3Yes { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Dodatkowe")]
        public string Additionals { get; set; }

        [DisplayName("Data rejestracji")]
        public DateTime? RegistrationDate { get; set; }

        [DisplayName("Data rezygnacji")]
        public DateTime? CancelationDate { get; set; }


    }
}