﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassManager.Api.Models
{
    public class Enrollment
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }

        // Navigation Properties
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }

    }
}