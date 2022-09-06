using Microsoft.EntityFrameworkCore;
using Praktikumsaufgabe.Models;

namespace Praktikumsaufgabe.Data
{
	public class EFContext : DbContext
	{
		public EFContext(DbContextOptions<EFContext> options) : base(options)
		{

		}

		public DbSet<Models.Address> Addresses { get; set; }
		public DbSet<Models.Communication> Communications { get; set; }

		public DbSet<Models.ComStatus> ComStatus { get; set; }
		public DbSet<Models.ComType> ComType{get; set; }



	}
}
