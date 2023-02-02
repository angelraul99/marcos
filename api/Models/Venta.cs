using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
	[Table("Venta")]
	public class Venta
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("id_venta")]
		public int id_venta { get; set; }

		[ForeignKey("FK_Id")]
		[Required]
		[Column("id")]
		public int id { get; set; }

		[Column("detalle_venta")]
		public string detalle_venta { get; set; }


		[JsonIgnore]
		public Productos FK_Id{ get; set; }

	}
}
