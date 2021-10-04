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
using Microsoft.AspNetCore.Authorization;

using Patient = FourPatient.WebAPI.Models.Patient;

namespace FourPatient.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatient _patientrepo;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatient patientrepo, ILogger<PatientController> logger)
        {
            _logger = logger;
            _patientrepo = patientrepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAll()
        {
            return Ok(_patientrepo.GetAll().Select(p => Model(p)));
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            return Ok(Model(_patientrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientrepo.Create(Table(patient));
            }
            return Ok();
        }

        [HttpPost("Edit")]
        public ActionResult Edit([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _patientrepo.Update(Table(patient));
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
        // POST: Patient/Delete/{id}
        [HttpDelete]
        public ActionResult DeleteConfirmed(int id)
        {
            _patientrepo.Delete(id);
            return Ok();
        }

        private static Patient Model(Domain.Tables.Patient n)
        {
            return new Patient
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
            };
        }
        private static Domain.Tables.Patient Table(Patient n)
        {
            return new Domain.Tables.Patient
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
            };
        }
    }
}
