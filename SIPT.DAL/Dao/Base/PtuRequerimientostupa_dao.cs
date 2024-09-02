using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;
using SIPT.BL.DTO.DTO;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuRequerimientostupa_dao
	{
		public abstract Int32 Insertar(PtuRequerimientostupa pPtuRequerimientostupa);
		public abstract void Actualizar(PtuRequerimientostupa pPtuRequerimientostupa);
		public abstract void Eliminar(int? intcodrequerimientotupa);
		public abstract List<PtuRequerimientostupa> Listar();
		public abstract PtuRequerimientostupa ListarKey(int? intcodrequerimientotupa);
		public abstract List<PtuRequerimientostupa> ListarKeys(
								int? intcodrequerimientotupa,
								int? intcodplantilla,
								int? intcodigoprocedimiento);
		//public abstract List<PtuRequerimientostupaDTO> ListarPlantillas(
		//						int? intcodrequerimientotupa,
		//						int? intcodplantilla,
		//						int? intcodigoprocedimiento);

	}
}
