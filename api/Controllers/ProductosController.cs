using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace api.Controllers
{
		[ApiController]
	[Route("api/[controller]"), Authorize(Roles = "Admin")]
	public class ProductosController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Productos>> Get()
		{
				 return Ok(db.Productos.ToList());
		}

		private pruebasDB db;
		public ProductosController(pruebasDB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Productos json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Productos.Add(json);
				db.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Find(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			try
			{
				var item = await db.Productos.FindAsync(id);
				if (item == null)
				{
					return NotFound();
				}
				return Ok(item);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPut]
		public ActionResult Put([FromBody]Productos json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Productos.Where(a => a.id == json.id).FirstOrDefault();
				 if (dbjson == null){
				return BadRequest($"Productos with id json.id not found");
				}
				 db.Entry(dbjson).CurrentValues.SetValues(json);
				db.Update(dbjson);
				db.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult Delete(int? id)
		{
			if (!ModelState.IsValid)
			return BadRequest("Invalid Information");
				var dbjson = db.Productos.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Productos with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
