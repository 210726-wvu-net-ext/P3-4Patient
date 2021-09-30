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

        private static Entities.Review Entity(Domain.Tables.Review n)
        {
            return new Entities.Review
            {
                Id = n.Id,
                PatientId = n.PatientId,
                Comfort = n.Comfort,
                DatePosted = n.DatePosted,
                Message = n.Message,
                Hospitalid = n.Hospitalid,
                AccommodationId = n.AccommodationId,
                NursingId = n.NursingId,
                CovidId = n.CovidId,
                CleanlinessId = n.CleanlinessId
            };
        }
        private static Domain.Tables.Review Table(Entities.Review n)
        {
            return new Domain.Tables.Review
            {
                Id = n.Id,
                PatientId = n.PatientId,
                Comfort = n.Comfort,
                DatePosted = n.DatePosted,
                Message = n.Message,
                Hospitalid = n.Hospitalid,
                AccommodationId = n.AccommodationId,
                NursingId = n.NursingId,
                CovidId = n.CovidId,
                CleanlinessId = n.CleanlinessId
            };
        }

        public IEnumerable<Domain.Tables.Review> GetAll()
        {
            return _context.Reviews
                .Select(n => Table(n))
               .ToList();
        }

        public Domain.Tables.Review Get(int id)
        {
            var n = _context.Reviews
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Review c)
        {
            // map to EF model
            var entity = Entity(c);

            _context.Reviews.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Review c)
        {
            // query the DB
            var entity = _context.Reviews.First(n => n.Id == c.Id);

            entity = Entity(c);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Reviews.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }
    }
}
