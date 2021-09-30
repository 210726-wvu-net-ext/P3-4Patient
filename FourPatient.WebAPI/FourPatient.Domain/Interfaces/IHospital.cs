using FourPatient.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatient.Domain
{
    public interface IHospital
    {
        IEnumerable<Hospital> GetAll();
        Hospital Get(int id);
        void Create(Hospital hospital);
        void Update(Hospital hospital);
        void Delete(int id);
    }
}
