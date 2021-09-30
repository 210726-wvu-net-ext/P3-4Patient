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
    public class AccommodationRepo : IAccommodation
    {
        private readonly _4PatientContext _context;

        public AccommodationRepo(_4PatientContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }
        private static Entities.Accommodation Entity(Domain.Tables.Accommodation n)
        {
            return new Entities.Accommodation
            {
                Id = n.Id,
                Checkin = n.Checkin,
                Discharge = n.Discharge,
                Equipment = n.Equipment,
                Policy = n.Policy,
                Privacy = n.Privacy,
                Room = n.Room,
                FoodOptions = n.FoodOptions,
                FoodQuality = n.FoodQuality,
                DietOptions = n.DietOptions,
                Accessibility = n.Accessibility,
                Parking = n.Parking,
                AverageA = n.AverageA
            };
        }
        private static Domain.Tables.Accommodation Table(Entities.Accommodation n)
        {
            return new Domain.Tables.Accommodation
            {
                Id = n.Id,
                Checkin = n.Checkin,
                Discharge = n.Discharge,
                Equipment = n.Equipment,
                Policy = n.Policy,
                Privacy = n.Privacy,
                Room = n.Room,
                FoodOptions = n.FoodOptions,
                FoodQuality = n.FoodQuality,
                DietOptions = n.DietOptions,
                Accessibility = n.Accessibility,
                Parking = n.Parking,
                AverageA = n.AverageA
            };
        }

        public IEnumerable<Domain.Tables.Accommodation> GetAll()
        {
            return _context.Accommodation
                .Select(n => Table(n))
               .ToList();
        }

        public Domain.Tables.Accommodation Get(int id)
        {
            var n = _context.Accommodation
                .First(n => n.Id == id);
            return Table(n);
        }

        public void Create(Domain.Tables.Accommodation a)
        {
            // map to EF model
            var entity = Entity(a);

            _context.Accommodation.Add(entity);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Update(Domain.Tables.Accommodation a)
        {
            // query the DB
            var entity = _context.Accommodation.First(n => n.Id == a.Id);

            entity = Entity(a);

            // write changes to DB
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Accommodation.First(n => n.Id == id));

            // write changes to DB
            _context.SaveChanges();
        }

    }
}
