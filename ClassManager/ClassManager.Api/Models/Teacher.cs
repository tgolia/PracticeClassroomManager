using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassManager.Api.Models
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public DateTime StateDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigration Properties
        public virtual ICollection<Class> Classes { get; set; }

        // Relations
        
    }
}