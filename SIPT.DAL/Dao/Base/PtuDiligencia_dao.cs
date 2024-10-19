using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuDiligencia_dao
	{
		public abstract Int32 Insertar(PtuDiligencia pPtuDiligencia);
		public abstract void Actualizar(PtuDiligencia pPtuDiligencia);
		public abstract void Eliminar(int? intcoddiligencia);
		public abstract List<PtuDiligencia> Listar();
		public abstract PtuDiligencia ListarKey(int? intcoddiligencia);
		public abstract List<PtuDiligencia> ListarKeys(
								int? intcoddiligencia,
								int? intcodsolicitud);

	}
}
