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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Reprimand { get; set; }

        
        public string Pesel { get; set; }

        public DisabilityLevel DisabilityLevel { get; set; }


        public HealthStatus HealthStatus {get;set;}

        public string AdditionalInformation { get; set; }

        public ICollection<Daily> Dailys { get; set; }

        public string Interestings { get; set; }

        public Position Position { get; set;  }

        public ICollection<Day> Days { get; set; }

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

    public class Work
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Day Day { get; set; }

        public double GetHours()
        {
            return (End - Start).Hours;
        }
    }
}