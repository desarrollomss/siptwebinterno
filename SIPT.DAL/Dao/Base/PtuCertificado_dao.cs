using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuCertificado_dao
	{
		public abstract Int32 Insertar(PtuCertificado pPtuCertificado);
		public abstract void Actualizar(PtuCertificado pPtuCertificado);
		public abstract void Eliminar(int? intcodcertificado);
		public abstract List<PtuCertificado> Listar();
		public abstract PtuCertificado ListarKey(int? intcodcertificado);
		public abstract List<PtuCertificado> ListarKeys(
								int? intcodcertificado,
								int? intcodsolicitud);

	}
}
