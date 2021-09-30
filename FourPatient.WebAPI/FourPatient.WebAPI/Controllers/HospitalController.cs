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
using Hospital = FourPatient.WebAPI.Models.Hospital;

namespace FourPatient.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospital _hospitalrepo;
        private readonly ILogger<HospitalController> _logger;

        public HospitalController(IHospital hospitalrepo, ILogger<HospitalController> logger)
        {
            _logger = logger;
            _hospitalrepo = hospitalrepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hospital>> GetAll()
        {
            return Ok(_hospitalrepo.GetAll().Select(n => Model(n)));
        }

        [HttpGet("{id}")]
        public ActionResult<Hospital> Get(int id)
        {
            return Ok(Model(_hospitalrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Hospital n)
        {
            if (ModelState.IsValid)
            {
                _hospitalrepo.Create(Table(n));
            }
            return Ok();
        }

        [HttpPost("Edit")]
        public ActionResult Edit([FromBody] Hospital n)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _hospitalrepo.Update(Table(n));
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
            _hospitalrepo.Delete(id);
            return Ok();
        }

        private static Hospital Model(Domain.Tables.Hospital n)
        {
            return new Hospital
            {
                Id = n.Id,
                Name = n.Name,
                Address = n.Address,
                City = n.City,
                State = n.State,
                ZipCode = n.ZipCode,
                Comfort = n.Comfort,
                Nursing = n.Nursing,
                Accomodations = n.Accomodations,
                Cleanliness = n.Cleanliness,
                Covid = n.Covid,
                Description = n.Description,
                Departments = n.Departments
            };
        }
        private static Domain.Tables.Hospital Table(Hospital n)
        {
            return new Domain.Tables.Hospital
            {
                Id = n.Id,
                Name = n.Name,
                Address = n.Address,
                City = n.City,
                State = n.State,
                ZipCode = n.ZipCode,
                Comfort = n.Comfort,
                Nursing = n.Nursing,
                Accomodations = n.Accomodations,
                Cleanliness = n.Cleanliness,
                Covid = n.Covid,
                Description = n.Description,
                Departments = n.Departments
            };
        }
    }
}
