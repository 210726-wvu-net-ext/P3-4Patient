using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourPatient.Domain.Tables;

namespace FourPatient.Domain
{
    public interface IReview
    {
        IEnumerable<Review> GetAll();
        Review Get(int id);
        void Create(Review review);
        void Update(Review review);
        void Delete(int id);
    }
}
