using again.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace again.ViewModels
{
    public class GeneralViewModel
    {
        public Position Position { get; set; }
        public Employer Employer { get; set; }

        public int PositionId { get; set; }
    }
}