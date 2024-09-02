using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuSolreqgrupo_dao
	{
		public abstract Int32 Insertar(PtuSolreqgrupo pPtuSolreqgrupo);
		public abstract void Actualizar(PtuSolreqgrupo pPtuSolreqgrupo);
		public abstract void Eliminar(int? intcodsolreqgrupo);
		public abstract List<PtuSolreqgrupo> Listar();
		public abstract PtuSolreqgrupo ListarKey(int? intcodsolreqgrupo);
		public abstract List<PtuSolreqgrupo> ListarKeys(
								int? intcodsolreqgrupo,
								int? intsolicitudplantilla);
		public abstract List<PtuSolreqgrupo> ListarSegunFuncion(int? intsolicitudplantilla);

	}
}
