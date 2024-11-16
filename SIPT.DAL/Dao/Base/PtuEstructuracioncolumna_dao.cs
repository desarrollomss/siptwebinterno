using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuEstructuracioncolumna_dao
	{
		public abstract int Insertar(PtuEstructuracioncolumna pPtuEstructuracioncolumna);
		public abstract PtuEstructuracioncolumna Actualizar(PtuEstructuracioncolumna pPtuEstructuracioncolumna);
		public abstract void Eliminar(int? intcodestructuracioncolumna);
		public abstract List<PtuEstructuracioncolumna> Listar();
		public abstract PtuEstructuracioncolumna ListarKey(int? intcodestructuracioncolumna);
		public abstract List<PtuEstructuracioncolumna> ListarKeys(
								int? intcodestructuracioncolumna,
								int? intcodestructuracion);

	}
}
