using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using FourPatient.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This Class hold access methods for data layer


namespace FourPatient.DataAccess
{
    public class CleanlinessRepo : ICleanliness
    {
        private readonly _4PatientContext _context;

        public CleanlinessRepo(_4PatientContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }
        private static Entities.Cleanliness Entity(Domain.Tables.Cleanliness n)
        {
            return new Entities.Cleanliness
            {
                Id = n.Id,
                WaitingRoom = n.WaitingRoom,
                WardRoom = n.WardRoom,
                Equipment = n.Equipment,
                Bathroom = n.Bathroom,
                AverageCl = n.AverageCl
            };
        }
        private static Domain.Tables.Cleanliness Table(Entities.Cleanliness n)
        {
            return new Domain.Tables.Cleanliness
            {
                Id = n.Id,
                WaitingRoom = n.WaitingRoom,
                WardRoom = n.WardRoom,
                Equipment = n.Equipment,
                Bathroom = n.Bathroom,
                AverageCl = n.AverageCl
            };
        }

        public IEnumerable<Domain.Tables.Cleanliness> GetAll()
        {
            return _context.Cleanliness
                .Select(n => Table(n))
               .ToList();
        }

        public Domain.Tables.Cleanliness Get(int id)
        {
            var n = _context.Cleanliness
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Cleanliness c)
        {
            // map to EF model
            var entity = Entity(c);

            _context.Cleanliness.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Cleanliness c)
        {
            // query the DB
            var entity = _context.Cleanliness.First(n => n.Id == c.Id);

            entity = Entity(c);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Cleanliness.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }

    }
}
