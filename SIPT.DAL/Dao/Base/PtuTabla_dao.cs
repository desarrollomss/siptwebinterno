using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuTabla_dao
	{
		public abstract Int16 Insertar(PtuTabla pPtuTabla);
		public abstract void Actualizar(PtuTabla pPtuTabla);
		public abstract void Eliminar(int? smlcodtabla);
		public abstract List<PtuTabla> Listar();
		public abstract PtuTabla ListarKey(int? smlcodtabla);
		public abstract List<PtuTabla> ListarKeys(
								Int16? smlcodtabla,
								Int16? smlestado);

	}
}
