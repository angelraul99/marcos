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
	public class UsuarioController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Usuario>> Get()
		{
				 return Ok(db.Usuario.ToList());
		}

		private pruebasDB db;
		public UsuarioController(pruebasDB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Usuario json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Usuario.Add(json);
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
				var item = await db.Usuario.FindAsync(id);
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
		public ActionResult Put([FromBody]Usuario json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Usuario.Where(a => a.id == json.id).FirstOrDefault();
				 if (dbjson == null){
				return BadRequest($"Usuario with id json.id not found");
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
				var dbjson = db.Usuario.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Usuario with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
