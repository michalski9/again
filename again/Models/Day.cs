using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace again.Models
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Employer> Employers { get; set; }

        public ICollection<Work> Works { get; set; }

        public int GetNumberOfEmployers()
        {
            return Employers.Count();
        }
    }
}