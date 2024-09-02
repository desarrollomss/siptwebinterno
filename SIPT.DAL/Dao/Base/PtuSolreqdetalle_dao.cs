using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuSolreqdetalle_dao
	{
		public abstract Int32 Insertar(PtuSolreqdetalle pPtuSolreqdetalle);
		public abstract void Actualizar(PtuSolreqdetalle pPtuSolreqdetalle);
		public abstract void Eliminar(int? intcodsolreqdetalle);
		public abstract List<PtuSolreqdetalle> Listar();
		public abstract PtuSolreqdetalle ListarKey(int? intcodsolreqdetalle);
		public abstract List<PtuSolreqdetalle> ListarKeys(
								int? intcodsolreqdetalle,
								int? intcodsolreqgrupo);

	}
}
