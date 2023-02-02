using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
	[Table("Productos")]
	public class Productos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("id")]
		public int id { get; set; }

		[Column("nombre_del_producto")]
		public string nombre_del_producto { get; set; }

		[Column("descripcion_product")]
		public string descripcion_product { get; set; }

		[Column("precio")]
		public double? precio { get; set; }


	}
}
