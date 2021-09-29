using System;
using System.Collections.Generic;

#nullable disable

namespace FourPatient.Domain.Tables
{
    public partial class Nursing
    {
        public Nursing()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int? Attentiveness { get; set; }
        public int? Transparecy { get; set; }
        public int? Knowledge { get; set; }
        public int? Compassion { get; set; }
        public int? WaitTimes { get; set; }
        public decimal? AverageN { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
