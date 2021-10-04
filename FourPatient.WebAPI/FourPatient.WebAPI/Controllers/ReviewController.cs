﻿using Microsoft.AspNetCore.Mvc;
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
            return Ok(_reviewrepo.GetAll().Select(n => (Review)Map.Model(n)));
        }

        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return Ok((Review)Map.Model(_reviewrepo.Get(id)));
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewrepo.Create((Domain.Tables.Review)Map.Table(review));
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
                    _reviewrepo.Update((Domain.Tables.Review)Map.Table(review));
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
    }
}
