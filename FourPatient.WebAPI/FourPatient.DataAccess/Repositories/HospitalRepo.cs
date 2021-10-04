using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Hospital = FourPatient.Domain.Tables.Hospital;
using Review = FourPatient.Domain.Tables.Review;

// This Class hold access methods for data layer

namespace FourPatient.DataAccess
{
    public class HospitalRepo : IHospital
    {
        private readonly _4PatientContext _context;

        public HospitalRepo(_4PatientContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }
        public IEnumerable<Hospital> GetAll()
        {
            ICollection<Entities.Hospital> List = _context.Hospitals.ToList();
            ICollection<Hospital> N = List.Select(n => (Hospital)Map.Table(n)).ToList();

            foreach (var Hospital in N)
            {
                ICollection<Entities.Review> R = _context.Reviews.Where(x => x.HospitalId == Hospital.Id).ToList();
                Hospital.Reviews = R.Select(x => (Review)Map.Table(x)).ToList();
            };

            return N;
        }

        public Hospital Get(int id)
        {
            // The DbSet .Find() method searches DB based on primary key value
            var n = _context.Hospitals.Find(id); // This Enumerable method also works .First(n => n.Id == id);
            Hospital Hospital = (Hospital)Map.Table(n);

            ICollection<Entities.Review> R = _context.Reviews.Where(x => x.HospitalId == Hospital.Id).ToList();
            Hospital.Reviews = R.Select(x => (Review)Map.Table(x)).ToList();

            return Hospital;
        }

        public void Create(Hospital N)
        {
            // map to EF entity
            var entity = (Entities.Hospital)Map.Entity(N);

            _context.Hospitals.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Hospital N)
        {
            // map to EF entity
            _context.Hospitals.Update((Entities.Hospital)Map.Entity(N));

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(Get(id));

            // write changes to DB
            _context.SaveChanges();
        }
    }
}
