﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FourPatient.DataAccess.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal Comfort { get; set; }
        public DateTime? DatePosted { get; set; }
        public string Message { get; set; }
        public int Hospitalid { get; set; }
        public int? AccommodationId { get; set; }
        public int? NursingId { get; set; }
        public int? CovidId { get; set; }
        public int? CleanlinessId { get; set; }

        public virtual Accommodation Accommodation { get; set; }
        public virtual Cleanliness Cleanliness { get; set; }
        public virtual Covid Covid { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Nursing Nursing { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
