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
        private static Entities.Hospital Entity(Domain.Tables.Hospital n)
        {
            return new Entities.Hospital
            {
                Id = n.Id,
                Name = n.Name,
                Address = n.Address,
                City = n.City,
                State = n.State,
                ZipCode = n.ZipCode,
                Comfort = n.Comfort,
                Nursing = n.Nursing,
                Accomodations = n.Accomodations,
                Cleanliness = n.Cleanliness,
                Covid = n.Covid,
                Description = n.Description,
                Departments = n.Departments
            };
        }
        private static Domain.Tables.Hospital Table(Entities.Hospital n)
        {
            return new Domain.Tables.Hospital
            {
                Id = n.Id,
                Name = n.Name,
                Address = n.Address,
                City = n.City,
                State = n.State,
                ZipCode = n.ZipCode,
                Comfort = n.Comfort,
                Nursing = n.Nursing,
                Accomodations = n.Accomodations,
                Cleanliness = n.Cleanliness,
                Covid = n.Covid,
                Description = n.Description,
                Departments = n.Departments
            };
        }

        public IEnumerable<Domain.Tables.Hospital> GetAll()
        {
            return _context.Hospitals
                .Select(n => Table(n))
               .ToList();
        }

        public Domain.Tables.Hospital Get(int id)
        {
            var n = _context.Hospitals
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Hospital h)
        {
            // map to EF model
            var entity = Entity(h);

            _context.Hospitals.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Hospital h)
        {
            // query the DB
            var entity = _context.Hospitals.First(n => n.Id == h.Id);

            entity = Entity(h);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Hospitals.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }
    }
}
