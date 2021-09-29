using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FourPatient.WebAPI.Models
{
    public class Cleanliness
    {
        public int Id { get; set; }
        public int? WaitingRoom { get; set; }
        public int? WardRoom { get; set; }
        public int? Equipment { get; set; }
        public int? Bathroom { get; set; }
        public decimal? AverageCl { get; set; }
    }
}
