using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using grpcStvari;
using Microsoft.Extensions.Logging;
using NestoTamoBlazor.Shared;

namespace NestoTamoBlazor.Server.grpcServisi
{
	public class KorSer : KorisniciServ.KorisniciServBase
	{
		private readonly Baza _db;
		private readonly ILogger<KorSer> _logger;
		private readonly Konvertor _kon;

		public KorSer(Baza db, ILogger<KorSer> log, Konvertor kon)
		{
			_db = db;
			_logger = log;
			_kon = kon;
		}

		public override async Task DajKorisnike(TrebaBudePrazno request, IServerStreamWriter<KorisnikMsg> responseStream, ServerCallContext context)
		{
			var kor = _db.Korisniks.ToList();
			_db.Adresas.ToList();
			_logger.LogInformation("Krecem stream");
			foreach (Korisnik k in kor)
			{
				_logger.LogInformation("Saljem");
				await responseStream.WriteAsync(_kon.Konvert(k));
				await Task.Delay(2000); // demek nesto radi :) 
			}
			_logger.LogInformation("Zavrsio");
		}

		public override Task<KorisnikMsg> PoredjenjaRadi(TrebaBudePrazno request, ServerCallContext context)
		{
			return base.PoredjenjaRadi(request, context);
		}
	}
}
