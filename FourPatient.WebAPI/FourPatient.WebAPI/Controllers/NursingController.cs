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
using Nursing = FourPatient.WebAPI.Models.Nursing;

namespace FourPatient.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NursingController : ControllerBase
    {
        private readonly INursing _nursingrepo;
        private readonly ILogger<NursingController> _logger;

        public NursingController(INursing nursingrepo, ILogger<NursingController> logger)
        {
            _logger = logger;
            _nursingrepo = nursingrepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Nursing>> GetAll()
        {
            return Ok(_nursingrepo.GetAll().Select(p => Model(p)));
        }

        [HttpGet("{id}")]
        public ActionResult<Nursing> Get(int id)
        {
            return Ok(Model(_nursingrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Nursing survey)
        {
            if (ModelState.IsValid)
            {
                _nursingrepo.Create(Table(survey));
            }
            return Ok();
        }

        [HttpPost("Edit")]
        public ActionResult Edit([FromBody] Nursing survey)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _nursingrepo.Update(Table(survey));
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
            _nursingrepo.Delete(id);
            return Ok();
        }

        private static Nursing Model(Domain.Tables.Nursing n)
        {
            return new Nursing
            {
                Id = n.Id,
                Attentiveness = n.Attentiveness,
                Transparecy = n.Transparecy,
                Knowledge = n.Knowledge,
                Compassion = n.Compassion,
                WaitTimes = n.WaitTimes,
                AverageN = n.AverageN
            };
        }
        private static Domain.Tables.Nursing Table(Nursing n)
        {
            return new Domain.Tables.Nursing
            {
                Id = n.Id,
                Attentiveness = n.Attentiveness,
                Transparecy = n.Transparecy,
                Knowledge = n.Knowledge,
                Compassion = n.Compassion,
                WaitTimes = n.WaitTimes,
                AverageN = n.AverageN
            };
        }
    }
}
