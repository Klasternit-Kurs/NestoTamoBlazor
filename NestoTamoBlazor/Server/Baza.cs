using Microsoft.EntityFrameworkCore;
using NestoTamoBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestoTamoBlazor.Server
{
	public class Baza : DbContext
	{
		public Baza(DbContextOptions<Baza> op) : base(op) { }

		public DbSet<Korisnik> Korisniks { get; set; }
		public DbSet<Adresa> Adresas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Korisnik>().HasKey(k => k.ID);
			modelBuilder.Entity<Adresa>().HasKey(a => a.ID);

			modelBuilder.Entity<Korisnik>().HasMany(k => k.Adrese)
				.WithOne(a => a.Korisnik)
				.HasForeignKey(a => a.Korisnik_FK);

			modelBuilder.Entity<Korisnik>().HasData(
				new Korisnik { ID = -1, Ime = "Pera", Prezime = "Peric" },
				new Korisnik { ID = -2, Ime = "Neko", Prezime = "Nekic" }
				);

			modelBuilder.Entity<Adresa>().HasData(
				new Adresa { ID = "a", Ulica = "abc", Broj = "111", Korisnik_FK=-1 },
				new Adresa { ID = "b", Ulica = "zxc", Broj = "222", Korisnik_FK=-1 },
				new Adresa { ID = "c", Ulica = "qwe", Broj = "333", Korisnik_FK=-2 }
				);
		}
	}
}
