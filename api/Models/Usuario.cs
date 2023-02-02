using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
	[Table("Usuario")]
	public class Usuario
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("id")]
		public int id { get; set; }

		[Required]
		[Column("nombre")]
		public string nombre { get; set; }

		[Required]
		[Column("cotrasena")]
		public string cotrasena { get; set; }


	}
}
