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
    public class NursingRepo : INursing
    {
        private readonly _4PatientContext _context;

        public NursingRepo(_4PatientContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }
        private static Entities.Nursing Entity(Domain.Tables.Nursing n)
        {
            return new Entities.Nursing
            {
                Id = n.Id,
                Attentiveness = n.Attentiveness,
                Transparecy = n.Transparecy,
                Knowledge = n.Knowledge,
                Compassion = n.Compassion,
                WaitTimes = n.WaitTimes,
                AverageN = n.AverageN
            };
        }
        private static Domain.Tables.Nursing Table(Entities.Nursing n)
        {
            return new Domain.Tables.Nursing
            {
                Id = n.Id,
                Attentiveness = n.Attentiveness,
                Transparecy = n.Transparecy,
                Knowledge = n.Knowledge,
                Compassion = n.Compassion,
                WaitTimes = n.WaitTimes,
                AverageN = n.AverageN
            };
        }

        public IEnumerable<Domain.Tables.Nursing> GetAll()
        {
            return _context.Nursing
                .Select(n => Table(n))
               .ToList();
        }

        public Domain.Tables.Nursing Get(int id)
        {
            var n = _context.Nursing
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Nursing n)
        {
            // map to EF model
            var entity = Entity(n);

            _context.Nursing.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Nursing N)
        {
            // query the DB
            var entity = _context.Nursing.First(n => n.Id == N.Id);

            entity = Entity(N);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Nursing.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }

    }
}
