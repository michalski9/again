using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace again.Models
{
    public class Employer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Telefon")]
        [RegularExpression("^\\d{3}-\\d{3}-\\d{3}$",ErrorMessage = "Wprowadź telefon w formie XXX-XXX-XXX")]
        public string Phone { get; set; }

        [Display(Name = "Nagana")]
        public bool Reprimand { get; set; }

        [Display(Name = "Pesel")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Wprowadź telefon w formie XXX-XXX-XXX")]
        public string Pesel { get; set; }

        [Display(Name = "Seopień niepełnosprawności",ShortName = "Niepełnosprawność")]
        public DisabilityLevel DisabilityLevel { get; set; }

        [Required]
        [Display(Name = "Status zdrowia")]
        public HealthStatus HealthStatus {get;set;}

        [Display(Name = "Uwagi")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Dniówka")]
        public ICollection<Daily> Dailys { get; set; }

        [Required]
        [Display(Name = "Zainteresowania")]
        public string Interestings { get; set; }

        [Display(Name = "Stanowisko")]
        public Position Position { get; set;  }

        [Display(Name = "Dzień")]
        public ICollection<Day> Days { get; set; }

        [Display(Name = "Godziny pracy")]
        public ICollection<Work> Works { get; set; }


        public double GetMonthlyRate()
        {

            double value = 0;
            if (Works != null)
            {
                
                foreach (var item in Works)
                {
                    Daily daily = Dailys
                        .Where(p => p.Days
                                        .Contains(item.Day)).SingleOrDefault();
                    value += item.GetHours() * daily.HourlyRate;
                    if (Reprimand == false)
                    {
                        value += daily.Bonus;
                    }
                }
            }

            return value;
        }

        
    }

    public enum HealthStatus
    {
        [Display(Name="Zdrowy")]
        ZDROWY = 0, 
    [Display(Name="Niepełnosprawny")]
    NIEPEŁNOSPRAWNY = 1,
        [Display(Name="Chory")]
    CHORY = 2
    }
    
    public enum DisabilityLevel {
        ZNACZNY = 0, LEKKI = 1, UMIARKOWANY = 3
    }

    
}