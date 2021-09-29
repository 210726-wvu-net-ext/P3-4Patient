using FourPatient.DataAccess.Entities;
using FourPatient.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatient.DataAccess
{
    public class PatientRepo : IPatient
    {
        private readonly Patient4Context _context;

        public PatientRepo(Patient4Context context)
        {
            _context = context;
        }

        public List<Patient> ListPatient()
        {
            return _context.Patients

                .Select(n => new Patient
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
                })
               .ToList();
        }

    }
}
