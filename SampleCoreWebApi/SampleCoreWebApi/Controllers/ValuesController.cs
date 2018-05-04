﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // optainal route values: {id?}
        //Default values: {id=5}
        //Contraints: {id:int}      
        // GET api/values/5     
        [HttpGet("{id}")]
        public IActionResult Get(int id, string query)
        {

            return Ok(new Value { Id = id, Text = "value" + id });
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // save the value to DB
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Value {
        public int Id { get; set; }
        [MinLength(3)]
        public string Text { get; set; }
    }
}
