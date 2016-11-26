using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace again.Models
{
    public class Daily
    {
        public int Id { get; set; }
        public double HourlyRate { get; set; }
        public double Bonus { get; set; }

        public ICollection<Day> Days { get; set; }
        public ICollection<Employer> Employers { get; set; }
    }
}