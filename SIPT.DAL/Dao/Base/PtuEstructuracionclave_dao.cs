using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuEstructuracionclave_dao
	{
		public abstract Int32 Insertar(PtuEstructuracionclave pPtuEstructuracionclave);
		public abstract Int32 Actualizar(PtuEstructuracionclave pPtuEstructuracionclave);
		public abstract Int32 Eliminar(int? intcodestructuracionclave);
		public abstract List<PtuEstructuracionclave> Listar();
		public abstract PtuEstructuracionclave ListarKey(int? intcodestructuracionclave);
		public abstract List<PtuEstructuracionclave> ListarKeys(
								int? intcodestructuracionclave,
								int? intcodestructuracion);

	}
}
