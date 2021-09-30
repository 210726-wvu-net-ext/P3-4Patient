using System;
using System.Collections.Generic;

#nullable disable

// Hold data layer objects, either from Business layer or SQL Server

namespace FourPatient.DataAccess.Entities
{
    public partial class Cleanliness
    {
        public Cleanliness()
        {
            Reviews = new HashSet<Review>();
        }

        // Primitive properties
        // Data type? = Nullable
        public int Id { get; set; }
        public int? WaitingRoom { get; set; }
        public int? WardRoom { get; set; }
        public int? Equipment { get; set; }
        public int? Bathroom { get; set; }
        public decimal? AverageCl { get; set; }

        // List property of associated objects
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
