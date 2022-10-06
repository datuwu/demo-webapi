using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        public static List<Good> goods = new List<Good>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(goods);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var good = goods.SingleOrDefault(good => good.Id == Guid.Parse(id));
                if (good == null)
                {
                    return NotFound();
                }
                return Ok(good);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(GoodVM goodVM)
        {
            var good = new Good
            {
                Id = Guid.NewGuid(),
                Name = goodVM.Name,
                UnitPrice = goodVM.UnitPrice
            };
            goods.Add(good);

            return Ok(new
            {
                Success = true,
                Data = good
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Good goodEdit)
        {
            try
            {
                var good = goods.SingleOrDefault(good => good.Id == Guid.Parse(id));
                if (good == null)
                {
                    return NotFound();
                }

                if (id != goodEdit.Id.ToString())
                {
                    return BadRequest();
                }
                good.Name = goodEdit.Name;
                good.UnitPrice = goodEdit.UnitPrice;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var good = goods.SingleOrDefault(good => good.Id == Guid.Parse(id));
                if (good == null)
                {
                    return NotFound();
                }

                goods.Remove(good);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
