using Microsoft.EntityFrameworkCore;

namespace api.Models
{
	public class pruebasDB : DbContext
	{
		public pruebasDB(DbContextOptions<pruebasDB> options) : base(options) { }
		
public DbSet<Productos> Productos { get; set; }
public DbSet<Usuario> Usuario { get; set; }
public DbSet<Venta> Venta { get; set; }
	}
}
