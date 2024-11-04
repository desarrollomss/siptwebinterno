using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuSolcertificado_dao
	{
		public abstract Int32 Insertar(PtuSolcertificado pPtuSolcertificado);
		public abstract void Actualizar(PtuSolcertificado pPtuSolcertificado);
		public abstract void Eliminar(int? intcodsolicitud);
		public abstract List<PtuSolcertificado> Listar();
		public abstract PtuSolcertificado ListarKey(int? intcodsolicitud);
		public abstract List<PtuSolcertificado> ListarKeys(
								int? intcodsolicitud,
								int? intcodlicencia);

		public abstract List<PtuSolcertificado_PorInspector> Buscar(
										PtuSolcertificado pPtuSolcertificado,
										PtuSolicitud pPtuSolicitud);

	}
}
