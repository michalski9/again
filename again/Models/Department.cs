using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace again.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Position> Positions { get; set; }

    }

    public class Position
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public Department Department { get; set; }

        public ICollection<Employer> Employers { get; set; }
    }
}