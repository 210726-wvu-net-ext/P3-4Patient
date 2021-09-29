using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using System.Linq;
using System;
using System.Collections.Generic;

namespace FourPatient.DataAccess
{
    public class HospitalRepo : IHospital
    {
        private readonly _4PatientContext _context;

        public HospitalRepo(_4PatientContext context)
        {
            _context = context;
        }

        //public List <Hospital> ListHospital()
        //{
        //    return _context.Hospitals

        //        .Select(n => new Hospital
        //        {
        //            Id = n.Id,
        //            Name = n.Name,
        //            Address = n.Address,
        //            City = n.City,
        //            State = n.State,                   
        //            ZipCode = n.ZipCode,
        //            Comfort = n.Comfort,
        //            Nursing = n.Nursing,
        //            Accomodations = n.Accomodations,
        //            Cleanliness = n.Cleanliness,
        //            Covid = n.Covid,
        //            Description =n.Description,
        //            Departments = n.Departments
        //        })
        //       .ToList();
        //}




    }
}
