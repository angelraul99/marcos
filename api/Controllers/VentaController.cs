using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
namespace api.Controllers
{
		[ApiController]
	[Route("api/[controller]"), Authorize(Roles = "Admin")]
	public class VentaController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Venta>> Get()
		{
				 return Ok(db.Venta.ToList());
		}

		private pruebasDB db;
		public VentaController(pruebasDB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Venta json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Venta.Add(json);
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
				var item = await db.Venta.FindAsync(id);
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
		public ActionResult Put([FromBody]Venta json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Venta.Where(a => a.id_venta == json.id_venta).FirstOrDefault();
				 if (dbjson == null){
				return BadRequest($"Venta with id json.id_venta not found");
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
				var dbjson = db.Venta.Where(a => a.id_venta == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Venta with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
