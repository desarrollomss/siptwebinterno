using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuSolcertificadoinspector_dao
	{
		public abstract Int32 Insertar(PtuSolcertificadoinspector pPtuSolcertificadoinspector);
		public abstract void Actualizar(PtuSolcertificadoinspector pPtuSolcertificadoinspector);
		public abstract void Eliminar(int? intcodsolicitudinspector);
		public abstract List<PtuSolcertificadoinspector> Listar();
		public abstract PtuSolcertificadoinspector ListarKey(int? intcodsolicitudinspector);
		public abstract List<PtuSolcertificadoinspector> ListarKeys(
								int? intcodsolicitudinspector,
								int? intcodsolicitud);

	}
}
