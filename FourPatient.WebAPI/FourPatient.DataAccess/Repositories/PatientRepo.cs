using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using FourPatient.Domain.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This Class hold access methods for data layer


namespace FourPatient.DataAccess
{
    public class PatientRepo : IPatient
    {
        private readonly _4PatientContext _context;

        public PatientRepo(_4PatientContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }
        private static Entities.Patient Entity(Domain.Tables.Patient n)
        {
            return new Entities.Patient
            {
                Id = n.Id,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Password = n.Password,
                Street = n.Street,
                City = n.City,
                State = n.State,
                DoB = n.DoB,
                Email = n.Email,
                PhoneNumber = n.PhoneNumber,
                ZipCode = n.ZipCode
            };
        }
        private static Domain.Tables.Patient Table(Entities.Patient n)
        {
            return new Domain.Tables.Patient
            {
                Id = n.Id,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Password = n.Password,
                Street = n.Street,
                City = n.City,
                State = n.State,
                DoB = n.DoB,
                Email = n.Email,
                PhoneNumber = n.PhoneNumber,
                ZipCode = n.ZipCode
            };
        }
        // Get all the patients
        public IEnumerable<Domain.Tables.Patient> GetAll()
        {
            return _context.Patients
                .Select(n => Table(n))
                .ToList();
        }

        public Domain.Tables.Patient Get(int id)
        {
            var n = _context.Patients
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Patient patient)
        {
            // map to EF model
            _context.Patients.Add(Entity(patient));

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Patient patient)
        {
            // query the DB
            var entity = _context.Patients.First(n => n.Id == patient.Id);

            entity = Entity(patient);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Patients.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }

    }
}
