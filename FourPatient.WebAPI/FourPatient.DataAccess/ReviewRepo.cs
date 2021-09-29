using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatient.DataAccess
{
   public  class ReviewRepo : IReview
    {

        private readonly _4PatientContext _context;

        public ReviewRepo(_4PatientContext context)
        {
            _context = context;
        }

        //public List<Review> ListReview()
        //{
        //    return _context.Reviews

        //        .Select(n => new Review
        //        {
        //            Id = n.Id,
        //            Patient = n.Patient, // foreign KEY
        //            Comfort = n.Comfort,
        //            DatePosted = n.DatePosted,
        //            Message = n.Message,
        //            Hospitalid = n.Hospitalid,
        //            AccommodationId = n.AccommodationId,
        //            NursingId = n.NursingId,
        //            CovidId = n.CovidId,
        //            CleanlinessId = n.CleanlinessId                 
        //        })
        //       .ToList();
        //}



    }
}
