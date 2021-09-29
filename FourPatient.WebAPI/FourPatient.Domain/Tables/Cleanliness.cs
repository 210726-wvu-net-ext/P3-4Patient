using System;
using System.Collections.Generic;


namespace FourPatient.Domain.Tables
{
    public class Cleanliness
    {
        public Cleanliness()
        {
        }

        public int Id { get; set; }
        public int? WaitingRoom { get; set; }
        public int? WardRoom { get; set; }
        public int? Equipment { get; set; }
        public int? Bathroom { get; set; }
        public decimal? AverageCl { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
