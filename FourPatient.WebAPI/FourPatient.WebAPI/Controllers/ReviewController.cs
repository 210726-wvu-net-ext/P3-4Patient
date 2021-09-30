using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FourPatient.Domain;
using FourPatient.Domain.Tables;
using FourPatient.WebAPI.Models;
using Review = FourPatient.WebAPI.Models.Review;

namespace FourPatient.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _reviewrepo;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReview reviewrepo, ILogger<ReviewController> logger)
        {
            _logger = logger;
            _reviewrepo = reviewrepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAll()
        {
            return Ok(_reviewrepo.GetAll().Select(n => Model(n)));
        }

        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return Ok(Model(_reviewrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewrepo.Create(Table(review));
            }
            return Ok();
        }

        [HttpPost("Edit")]
        public ActionResult Edit([FromBody] Review review)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _reviewrepo.Update(Table(review));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _reviewrepo.Delete(id);
            return Ok();
        }

        private static Review Model(Domain.Tables.Review n)
        {
            return new Review
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
        private static Domain.Tables.Review Table(Review n)
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
    }
}
