using System;
using System.Collections.Generic;

#nullable disable

// Hold data layer objects, either from Business layer or SQL Server

namespace FourPatient.DataAccess.Entities
{
    public partial class Covid
    {
        public Covid()
        {
            Reviews = new HashSet<Review>();
        }

        // Primitive properties
        // Data type? = Nullable
        public int Id { get; set; }
        public int? WaitingRooms { get; set; }
        public int? Protocols { get; set; }
        public int? Separation { get; set; }
        public int? Safety { get; set; }
        public bool? Covid1 { get; set; }
        public int? Screening { get; set; }
        public int? Treatement { get; set; }
        public decimal? AverageC { get; set; }

        // List property of associated objects
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
