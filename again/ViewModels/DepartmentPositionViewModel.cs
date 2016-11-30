using again.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace again.ViewModels
{
    public class DepartmentPositionViewModel
    {
        public Department Department { get; set; }
        public Position Position { get; set; }

        public int DepartmentId { get; set;}

    }
}