using ligunaApplication.Data;
using ligunaApplication.Interface;
using ligunaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ligunaApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RateController : Controller
    {
        private readonly IRate _context;
        public RateController(IRate context)
        {
            _context = context;
        }

        // GET: api/<RateController>
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<RateEntity>> Get()
        {
            return _context.GetAllRates().ToList();
        }

        // GET api/<RateController>/5
        [HttpGet("GetOne/{id}")]
        public ActionResult<RateEntity> Get(string id)
        {
            var rate = _context.GetOneRateDetails(id);
            if (rate == null)
            {
                return NotFound($"Rate with id {id} not found");
            }
            return rate;
        }

        // POST api/<RateController>
        [HttpPost]
        [Route("Create")]
        public ActionResult<RateEntity> Post([FromBody] RateEntity rate)
        {
            _context.Create(rate);
            return CreatedAtAction(nameof(Get), new { id = rate._Id }, rate);
        }

        // PUT api/<RateController>/5
        [HttpPut("Update/{id}")]
        public ActionResult Put(string id, [FromBody] RateEntity rate)
        {
            var existRate = _context.GetOneRateDetails(id);
            if (existRate == null)
            {
                return NotFound($"Rate with id {id} not found");
            }
            _context.Update(id, rate);
            return NoContent();
        }

        // DELETE api/<RateController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(string id)
        {
            var Rate = _context.GetOneRateDetails(id);
            if (Rate == null)
            {
                return NotFound($"Rate with id {id} not found");
            }
            _context.Delete(id);
            return Ok($"Rate with id {id} deleted");
        }

        // GET api/<RateController>/5
        [HttpGet("GetCount")]
        public ActionResult<dataview> GetCount()
        {
            var ratecount = _context.GetCount();
            return ratecount;
        }
    }
}
