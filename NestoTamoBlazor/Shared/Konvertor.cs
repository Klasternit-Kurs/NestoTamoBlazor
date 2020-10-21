using grpcStvari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NestoTamoBlazor.Shared
{
	public class Konvertor
	{
		public AdresaMsg Konvert(Adresa a)
			=> new AdresaMsg { ID = a.ID, Ulica = a.Ulica, Broj = a.Broj };

		public Adresa Konvert(AdresaMsg am)
			=> new Adresa { ID = am.ID, Ulica = am.Ulica, Broj = am.Broj };

		public KorisnikMsg Konvert(Korisnik k)
		{
			KorisnikMsg kms = new KorisnikMsg {ID = k.ID, Ime = k.Ime, Prezime = k.Prezime };

			k.Adrese.ForEach(a => kms.Adrese.Add(Konvert(a)));
			return kms;
		}
		
		public Korisnik Konvert(KorisnikMsg km)
		{
			Korisnik k = new Korisnik {ID = km.ID, Ime = km.Ime, Prezime = km.Prezime };

			km.Adrese.ToList().ForEach(am => k.Adrese.Add(Konvert(am)));
			return k;
		}
	}
}
