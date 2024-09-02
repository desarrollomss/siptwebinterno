using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuSolrequerimiento_dao
	{
		public abstract Int32 Insertar(PtuSolrequerimiento pPtuSolrequerimiento);
		public abstract void Actualizar(PtuSolrequerimiento pPtuSolrequerimiento);
		public abstract void Eliminar(int? intsolicitudplantilla);
		public abstract List<PtuSolrequerimiento> Listar();
		public abstract PtuSolrequerimiento ListarKey(int? intsolicitudplantilla);
		public abstract List<PtuSolrequerimiento> ListarKeys(
								int? intsolicitudplantilla,
								int? intcodplantilla,
								int? intcodsolicitud,
								Int16? smlevaluacion,
								Int16? smlestadodocumento);

		public abstract List<PtuSolrequerimiento> ListarAcredita(int? intcodsolicitud);

	}
}
