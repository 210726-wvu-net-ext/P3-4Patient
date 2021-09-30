using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using FourPatient.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatient.DataAccess
{
    public class CovidRepo : ICovid
    {
        private readonly _4PatientContext _context;

        public CovidRepo(_4PatientContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }
        private static Entities.Covid Entity(Domain.Tables.Covid n)
        {
            return new Entities.Covid
            {
                Id = n.Id,
                WaitingRooms = n.WaitingRooms,
                Protocols = n.Protocols,
                Separation = n.Separation,
                Safety = n.Safety,
                Covid1 = n.Covid1,
                Screening = n.Screening,
                Treatement = n.Treatement,
                AverageC = n.AverageC
            };
        }
        private static Domain.Tables.Covid Table(Entities.Covid n)
        {
            return new Domain.Tables.Covid
            {
                Id = n.Id,
                WaitingRooms = n.WaitingRooms,
                Protocols = n.Protocols,
                Separation = n.Separation,
                Safety = n.Safety,
                Covid1 = n.Covid1,
                Screening = n.Screening,
                Treatement = n.Treatement,
                AverageC = n.AverageC
            };
        }

        public IEnumerable<Domain.Tables.Covid> GetAll()
        {
            return _context.Covid
                .Select(n => Table(n))
               .ToList();
        }

        public Domain.Tables.Covid Get(int id)
        {
            var n = _context.Covid
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Covid c)
        {
            // map to EF model
            var entity = Entity(c);

            _context.Covid.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Covid c)
        {
            // query the DB
            var entity = _context.Covid.First(n => n.Id == c.Id);

            entity = Entity(c);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Covid.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }

    }
}
