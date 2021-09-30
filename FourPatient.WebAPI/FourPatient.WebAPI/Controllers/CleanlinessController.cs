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
using Cleanliness = FourPatient.WebAPI.Models.Cleanliness;

namespace FourPatient.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CleanlinessController : ControllerBase
    {
        private readonly ICleanliness _cleanlinessrepo;
        private readonly ILogger<CleanlinessController> _logger;

        public CleanlinessController(ICleanliness cleanlinessrepo, ILogger<CleanlinessController> logger)
        {
            _logger = logger;
            _cleanlinessrepo = cleanlinessrepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cleanliness>> GetAll()
        {
            return Ok(_cleanlinessrepo.GetAll().Select(p => Model(p)));
        }

        [HttpGet("{id}")]
        public ActionResult<Cleanliness> Get(int id)
        {
            return Ok(Model(_cleanlinessrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Cleanliness survey)
        {
            if (ModelState.IsValid)
            {
                _cleanlinessrepo.Create(Table(survey));
            }
            return Ok();
        }

        [HttpPost("Edit")]
        public ActionResult Edit([FromBody] Cleanliness survey)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cleanlinessrepo.Update(Table(survey));
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
            _cleanlinessrepo.Delete(id);
            return Ok();
        }

        private static Cleanliness Model(Domain.Tables.Cleanliness n)
        {
            return new Cleanliness
            {
                Id = n.Id,
                WaitingRoom = n.WaitingRoom,
                WardRoom = n.WardRoom,
                Equipment = n.Equipment,
                Bathroom = n.Bathroom,
                AverageCl = n.AverageCl
            };
        }
        private static Domain.Tables.Cleanliness Table(Cleanliness n)
        {
            return new Domain.Tables.Cleanliness
            {
                Id = n.Id,
                WaitingRoom = n.WaitingRoom,
                WardRoom = n.WardRoom,
                Equipment = n.Equipment,
                Bathroom = n.Bathroom,
                AverageCl = n.AverageCl
            };
        }
    }
}
