using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuLicencia_dao
	{
		public abstract Int32 Insertar(PtuLicencia pPtuLicencia);
		public abstract List<PtuLicencia> ListarKeys(
								int? intcodlicencia,
								int? intcodsolicitud);


	}
}
