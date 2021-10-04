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
            return Ok(_cleanlinessrepo.GetAll().Select(p => (Cleanliness)Map.Model(p)));
        }

        [HttpGet("{id}")]
        public ActionResult<Cleanliness> Get(int id)
        {
            return Ok((Cleanliness)Map.Model(_cleanlinessrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Cleanliness survey)
        {
            if (ModelState.IsValid)
            {
                _cleanlinessrepo.Create((Domain.Tables.Cleanliness)Map.Table(survey));
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
                    _cleanlinessrepo.Update((Domain.Tables.Cleanliness)Map.Table(survey));
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
            Cleanliness N = (Cleanliness)Map.Model(n);
            N.Review = (Models.Review)Map.Model(n.Review); ;
            return N;
        }
        private static Domain.Tables.Cleanliness Table(Cleanliness n)
        {
            Domain.Tables.Cleanliness N = (Domain.Tables.Cleanliness)Map.Table(n);
            N.Review = (Domain.Tables.Review)Map.Table(n.Review);
            return N;
        }
    }
}
