using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using again.Models;
using System.ComponentModel.DataAnnotations;


namespace again.Models
{
    public class Work
    {
        
            public int Id { get; set; }

            
            [Display(Name = "Release Date")]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Start { get; set; }

            [Display(Name = "Release Date")]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime End { get; set; }

            public Day Day { get; set; }

            public double GetHours()
            {
                return (End - Start).Hours;
            }
        
    }
}