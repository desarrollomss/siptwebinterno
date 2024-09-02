using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuProcedimientostupa_dao
	{
		public abstract Int32 Insertar(PtuProcedimientostupa pPtuProcedimientostupa);
		public abstract void Actualizar(PtuProcedimientostupa pPtuProcedimientostupa);
		public abstract void Eliminar(int? intcodigoprocedimiento);
		public abstract List<PtuProcedimientostupa> Listar();
		public abstract PtuProcedimientostupa ListarKey(int? intcodigoprocedimiento);
		public abstract List<PtuProcedimientostupa> ListarKeys(
								int? intcodigoprocedimiento);

	}
}
