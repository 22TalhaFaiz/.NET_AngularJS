using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
	public class Connection : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("server=.; database=Angulartest; User Id=sa; password=aptech; TrustServerCertificate=True");
		}
		public DbSet<User> users { get; set; }
	}
}
