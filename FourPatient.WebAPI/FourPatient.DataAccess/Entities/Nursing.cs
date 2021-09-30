﻿using System;
using System.Collections.Generic;

#nullable disable

// Hold data layer objects, either from Business layer or SQL Server

namespace FourPatient.DataAccess.Entities
{
    public partial class Nursing
    {
        public Nursing()
        {
            Reviews = new HashSet<Review>();
        }

        // Primitive properties
        // Data type? = Nullable
        public int Id { get; set; }
        public int? Attentiveness { get; set; }
        public int? Transparecy { get; set; }
        public int? Knowledge { get; set; }
        public int? Compassion { get; set; }
        public int? WaitTimes { get; set; }
        public decimal? AverageN { get; set; }

        // List property of associated objects
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
