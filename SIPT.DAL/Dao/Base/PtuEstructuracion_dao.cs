using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuEstructuracion_dao
	{
		public abstract int Insertar(PtuEstructuracion pPtuEstructuracion);
		public abstract PtuEstructuracion Actualizar(PtuEstructuracion pPtuEstructuracion);
		public abstract void Eliminar(int? intcodestructuracion);
		public abstract List<PtuEstructuracion> Listar();
		public abstract PtuEstructuracion ListarKey(int? intcodestructuracion);
		public abstract List<PtuEstructuracion> ListarKeys(int? intcodestructuracion, Int16? smlestado);

	}
}
