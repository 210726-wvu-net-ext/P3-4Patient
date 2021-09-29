using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FourPatient.DataAccess.Entities
{
    public partial class Covid
    {
        public Covid()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int? WaitingRooms { get; set; }
        public int? Protocols { get; set; }
        public int? Separation { get; set; }
        public int? Safety { get; set; }
        public bool? Covid1 { get; set; }
        public int? Screening { get; set; }
        public int? Treatement { get; set; }
        public decimal? AverageC { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
