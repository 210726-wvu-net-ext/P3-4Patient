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

        public void Create(Hospital H)
        {
            // map to EF entity
            var entity = (Entities.Hospital)Map.Entity(H);

            _context.Hospitals.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Hospital H)
        {
            H = Average(H);

            _context.ChangeTracker.Clear();

            // map to EF entity
            _context.Hospitals.Update((Entities.Hospital)Map.Entity(H));

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(Get(id));

            // write changes to DB
            _context.SaveChanges();
        }
        public Hospital Average(Hospital H)
        {
            decimal sum = 0;
            int i = 0;

            decimal sumA = 0;
            decimal sumCl = 0;
            decimal sumC = 0;
            decimal sumN = 0;

            ICollection<Entities.Review> R = _context.Reviews.Where(x => x.HospitalId == H.Id).ToList();

            foreach (var review in R)
            {
                sum += review.Comfort;
                i++;

                sumA += _context.Accommodations.Find(review.Id).AverageA ?? 0;
                sumCl += _context.Cleanlinesses.Find(review.Id).AverageCl ?? 0;
                sumC += _context.Covids.Find(review.Id).AverageC ?? 0; 
                sumN += _context.Nursings.Find(review.Id).AverageN ?? 0;
            }

            if (i == 0)
                return H;

            H.Comfort = (decimal)sum / i;
            H.Accomodations = (decimal)sumA / i;
            H.Cleanliness = (decimal)sumCl / i;
            H.Covid = (decimal)sumC / i;
            H.Nursing = (decimal)sumN / i;

            return H;
        }
    }
}
