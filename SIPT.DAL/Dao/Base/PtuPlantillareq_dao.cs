using System;
using SIPT.BL.Models.Entity;
using SIPT.BL.Models.Consultas;
using System.Collections.Generic;

namespace SIPT.DAL.Dao.Base
{
	public abstract class PtuPlantillareq_dao
	{
		public abstract Int32 Insertar(PtuPlantillareq pPtuPlantillareq);
		public abstract void Actualizar(PtuPlantillareq pPtuPlantillareq);
		public abstract void Eliminar(int? intcodplantilla);
		public abstract List<PtuPlantillareq> Listar();
		public abstract PtuPlantillareq ListarKey(int? intcodplantilla);
		public abstract List<PtuPlantillareq> ListarKeys(
								int? intcodplantilla);
		public abstract List<PtuPlantillareq> ListarPlantillas(
								int? intcodplantilla,
								int? intcodigoprocedimiento, 
								int? intcodsolicitud);

	}
}
