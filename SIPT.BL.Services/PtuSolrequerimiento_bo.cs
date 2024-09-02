using System;
using DBAccess;
using System.Collections.Generic;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.DTO.Mapper;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;

namespace SIPT.BL.Services
{
	public class PtuSolrequerimiento_bo
	{
		private PtuSolrequerimiento_dao oPtuSolrequerimiento_dao;
		private PtuSolreqgrupo_dao oPtuSolreqgrupo_dao;
		private PtuPlantillareq_dao oPtuPlantillareq_dao;
		private PtuSolreqdetalle_dao oPtuSolreqdetalle_dao;		
		private PtuUbicaciones_dao oPtuUbicaciones_dao;
		private LogMensajes logMensajes;
		private Db dbconex;

		public PtuSolrequerimiento_bo(ref LogMensajes logMensajes)
		{
			this.logMensajes = logMensajes;
		}

		public PtuSolrequerimientoDTO Insertar(PtuSolrequerimientoDTO pPtuSolrequerimientoDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolrequerimiento oPtuSolrequerimiento = mapeo.Map<PtuSolrequerimientoDTO, PtuSolrequerimiento>(pPtuSolrequerimientoDTO);

				dbconex.IniciarTransaccion();
				pPtuSolrequerimientoDTO.intsolicitudplantilla = oPtuSolrequerimiento_dao.Insertar(oPtuSolrequerimiento);
				dbconex.RegistrarTransaccion();

				return pPtuSolrequerimientoDTO;
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Actualizar(PtuSolrequerimientoDTO pPtuSolrequerimientoDTO)
		{
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);
				Mapeos mapeo = new Mapeos();
				PtuSolrequerimiento oPtuSolrequerimiento = mapeo.Map<PtuSolrequerimientoDTO, PtuSolrequerimiento>(pPtuSolrequerimientoDTO);

				dbconex.IniciarTransaccion();
				oPtuSolrequerimiento_dao.Actualizar(oPtuSolrequerimiento);
				dbconex.RegistrarTransaccion();
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public void Eliminar(int? intsolicitudplantilla)
		{
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolrequerimiento_dao.Eliminar(intsolicitudplantilla);
				dbconex.RegistrarTransaccion();
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
		}

		public List<PtuSolrequerimientoDTO> Listar()
		{
			List<PtuSolrequerimiento> oPtuSolrequerimientoList;
			List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolrequerimientoList = oPtuSolrequerimiento_dao.Listar();
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				foreach (PtuSolrequerimiento oPtuSolrequerimiento in oPtuSolrequerimientoList)
				{
					var oPtuSolrequerimientoDTO = mapeo.Map<PtuSolrequerimiento, PtuSolrequerimientoDTO>(oPtuSolrequerimiento);
					oPtuSolrequerimientoDTOList.Add(oPtuSolrequerimientoDTO);
				}
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolrequerimientoDTOList;
		}

		public PtuSolrequerimientoDTO ListarKey(int? intsolicitudplantilla)
		{
			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO;
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				PtuSolrequerimiento oPtuSolrequerimiento = oPtuSolrequerimiento_dao.ListarKey(intsolicitudplantilla);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuSolrequerimientoDTO = mapeo.Map<PtuSolrequerimiento, PtuSolrequerimientoDTO>(oPtuSolrequerimiento);
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolrequerimientoDTO;
		}

		public List<PtuSolrequerimientoDTO> ListarKeys(
								int? intsolicitudplantilla,
								int? intcodplantilla,
								int? intcodsolicitud,
								Int16? smlevaluacion,
								Int16? smlestadodocumento)
		{
			List<PtuSolrequerimiento> oPtuSolrequerimientoList;
			List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolrequerimientoList = oPtuSolrequerimiento_dao.ListarKeys(
								intsolicitudplantilla,
								intcodplantilla,
								intcodsolicitud,
								smlevaluacion,
								smlestadodocumento);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuSolrequerimiento oPtuSolrequerimiento in oPtuSolrequerimientoList)
				{
					var oPtuSolrequerimientoDTO = mapeo.Map<PtuSolrequerimiento, PtuSolrequerimientoDTO>(oPtuSolrequerimiento);
					oPtuSolrequerimientoDTOList.Add(oPtuSolrequerimientoDTO);
				}
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolrequerimientoDTOList;
		}

		public List<PtuSolrequerimientoDTO> ListarAcredita(int? intcodsolicitud)
		{
			List<PtuSolrequerimiento> oPtuSolrequerimientoList;
			List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
			dbconex = new Db();
			try
			{
				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolrequerimientoList = oPtuSolrequerimiento_dao.ListarAcredita(intcodsolicitud);
				dbconex.RegistrarTransaccion();
				Mapeos mapeo = new Mapeos();

				foreach (PtuSolrequerimiento oPtuSolrequerimiento in oPtuSolrequerimientoList)
				{
					var oPtuSolrequerimientoDTO = mapeo.Map<PtuSolrequerimiento, PtuSolrequerimientoDTO>(oPtuSolrequerimiento);
					oPtuSolrequerimientoDTOList.Add(oPtuSolrequerimientoDTO);
				}
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolrequerimientoDTOList;
		}

		public List<PtuSolrequerimientoDTO> ListarRequerimientosPorSolicitud(
										int? intcodsolicitud)
		{
			List<PtuSolrequerimiento> oPtuSolrequerimientoList;
			List<PtuSolrequerimientoDTO> oPtuSolrequerimientoDTOList = new List<PtuSolrequerimientoDTO>();
			dbconex = new Db();
			try
			{

				oPtuSolrequerimiento_dao = ObjectFactory.Instanciar<PtuSolrequerimiento_dao>(new PtuSolrequerimiento(), this.logMensajes, dbconex);
				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);

				Mapeos mapeo = new Mapeos();
				dbconex.IniciarTransaccion();
				oPtuSolrequerimientoList = oPtuSolrequerimiento_dao.ListarKeys(
								0,
								0,
								intcodsolicitud,
								0,
								0);

				foreach (PtuSolrequerimiento oPtuSolrequerimiento in oPtuSolrequerimientoList)
				{
					PtuPlantillareq oPtuPlantillareq = oPtuPlantillareq_dao.ListarKey(oPtuSolrequerimiento.intcodplantilla);

					var oPtuSolrequerimientoDTO = mapeo.Map<PtuSolrequerimiento, PtuPlantillareq, PtuSolrequerimientoDTO>(oPtuSolrequerimiento, oPtuPlantillareq);
					oPtuSolrequerimientoDTOList.Add(oPtuSolrequerimientoDTO);
				}
				dbconex.RegistrarTransaccion();
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuSolrequerimientoDTOList;
		}

		//public List<PtuSolreqgrupoDTO> ListarSolReqGrupo(int? intsolicitudplantilla)
		public object ListarSolReqGrupo(int? intsolicitudplantilla)
		{
			List<PtuSolreqgrupo> oPtuSolreqgrupoList;
			List<PtuSolreqgrupoDTO> oPtuSolreqgrupoDTOList = new List<PtuSolreqgrupoDTO>();
			IDictionary<string, object> objeto = new System.Dynamic.ExpandoObject();
			dbconex = new Db();
			try
			{
				oPtuSolreqgrupo_dao = ObjectFactory.Instanciar<PtuSolreqgrupo_dao>(new PtuSolreqgrupo(), this.logMensajes, dbconex);
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuSolreqgrupoList = oPtuSolreqgrupo_dao.ListarSegunFuncion(intsolicitudplantilla);

				Mapeos mapeo = new Mapeos();
				PtuModeloDTO modelo;
				PtuModelo2DTO modelo2;
				foreach (PtuSolreqgrupo oPtuSolreqgrupo in oPtuSolreqgrupoList)
				{
					if (oPtuSolreqgrupo.smlnivel == 1)
					{
						/*
						var oPtuSolreqgrupoDTO = mapeo.Map<PtuSolreqgrupo, PtuSolreqgrupoDTO>(oPtuSolreqgrupo);
						oPtuSolreqgrupoDTO.PtuSolreqgrupoDTOList = PtuSolreqgrupoDTOHijos(oPtuSolreqgrupoDTO.intcodsolreqgrupo, oPtuSolreqgrupoList);
						oPtuSolreqgrupoDTOList.Add(oPtuSolreqgrupoDTO);
						*/
						modelo = new PtuModeloDTO();
						modelo.type = "label";
						modelo.label = oPtuSolreqgrupo.vchnombregrupo;
						modelo.rules = new Reglas(false);
						objeto.Add("lbl_" + oPtuSolreqgrupo.vchcodgrupo, modelo);

						if (oPtuSolreqgrupo.smltipogrupo == 35) //Una Selección (RADIO)
						{
							List<PtuSolreqdetalle> oPtuSolreqdetalleList = oPtuSolreqdetalle_dao.ListarKeys(0, oPtuSolreqgrupo.intcodsolreqgrupo);
							var vPtuSolreqdetalleList = oPtuSolreqdetalleList.FindAll(o => o.chreditable == "S");

							modelo = new PtuModeloDTO();
							modelo.type = "radio";
							modelo.label = "";
							Opcion[] opciones = new Opcion[vPtuSolreqdetalleList.Count];
							int i = 0;
							foreach (PtuSolreqdetalle oPtuSolreqdetalle in vPtuSolreqdetalleList)
							{
								opciones[i] = new Opcion(oPtuSolreqdetalle.vchdescripcion, i.ToString());
								i++;
							}
							modelo.options = opciones;
							string etiqueta = oPtuSolreqgrupo.vchcodgrupo;
							objeto.Add("ctl_" + etiqueta, modelo);
						}
						else
						{
							List<PtuSolreqdetalle> oPtuSolreqdetalleList = oPtuSolreqdetalle_dao.ListarKeys(0, oPtuSolreqgrupo.intcodsolreqgrupo);
							var vPtuSolreqdetalleList = oPtuSolreqdetalleList.FindAll(o => o.chreditable == "S");
							foreach (PtuSolreqdetalle oPtuSolreqdetalle in vPtuSolreqdetalleList)
							{
								if (oPtuSolreqgrupo.chreditable == "S")
								{
									modelo2 = new PtuModelo2DTO();
									modelo = new PtuModeloDTO();

									if (oPtuSolreqgrupo.smltipogrupo == 33) //Textos Simple
									{
										if (oPtuSolreqdetalle.vchtipovalor == "Número")
										{
											modelo.type = "number";
											modelo2.type = "number";
										}
										else if (oPtuSolreqdetalle.vchtipovalor == "Fecha")
										{
											modelo.type = "date";
											modelo2.type = "date";
										}
										else
										{
											modelo.type = "text";
											modelo2.type = "text";
										}
									}
									else if (oPtuSolreqgrupo.smltipogrupo == 34) //Textos Multi-Linea
									{
										modelo.type = "textarea";
										modelo2.type = "textarea";
									}
									else if (oPtuSolreqgrupo.smltipogrupo == 35) //Una Selección
									{
										//modelo.type = "radio";
									}
									else if (oPtuSolreqgrupo.smltipogrupo == 36) //Multi Selección
									{
										modelo.type = "checkbox";
										modelo2.type = "checkbox";
									}

									if (oPtuSolreqgrupo.smltipogrupo != 34)
									{
										modelo.label = oPtuSolreqdetalle.vchdescripcion;
										modelo2.label = oPtuSolreqdetalle.vchdescripcion;
									}

									string etiqueta = oPtuSolreqdetalle.vchetiqueta.Replace("[", "").Replace("]", "");

									if (oPtuSolreqdetalle.chrobligatorio == "S")
									{
										modelo.rules = new Reglas(true);
										objeto.Add("ctl_" + etiqueta, modelo);
									}
									else
									{
										objeto.Add("ctl_" + etiqueta, modelo2);
									}
								}
							}
						}

					}
				}

				dbconex.RegistrarTransaccion();

			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return objeto;
		}

		private List<PtuSolreqgrupoDTO> PtuSolreqgrupoDTOHijos(int? intcodsolreqgrupo, List<PtuSolreqgrupo> oPtuSolreqgrupoList)
		{
			Mapeos mapeo = new Mapeos();
			List<PtuSolreqgrupoDTO> oPtuSolreqgrupoDTOList = new List<PtuSolreqgrupoDTO>();
			var vPtuSolreqgrupoList = oPtuSolreqgrupoList.FindAll(o => o.intcodsolreqgrppadre == intcodsolreqgrupo);
			if (vPtuSolreqgrupoList.Count > 0)
			{
				foreach (PtuSolreqgrupo oPtuSolreqgrupo in vPtuSolreqgrupoList)
				{
					var oPtuSolreqgrupoDTO = mapeo.Map<PtuSolreqgrupo, PtuSolreqgrupoDTO>(oPtuSolreqgrupo);
					oPtuSolreqgrupoDTO.PtuSolreqgrupoDTOList = PtuSolreqgrupoDTOHijos(oPtuSolreqgrupoDTO.intcodsolreqgrupo, oPtuSolreqgrupoList);
					oPtuSolreqgrupoDTOList.Add(oPtuSolreqgrupoDTO);
				}
			}
			return oPtuSolreqgrupoDTOList;
		}

		public PtuSolrequerimientoDTO GuardarRequerimiento(Dictionary<string, object> valores)
		{
			int intsolicitudplantilla = Convert.ToInt32(valores["intsolicitudplantilla"].ToString());
			string vchaudusumodif = valores["vchaudusumodif"].ToString();
			string vchaudequipo = valores["vchaudequipo"].ToString();
			string vchaudprograma = valores["vchaudprograma"].ToString();
			int? intcodplantilla = 0;
			int? intcodsolicitud = 0;

			Dictionary<string, object> controles = (Dictionary<string, object>)valores["controles"];
			PtuSolreqdetalle oPtuSolreqdetalle;
			PtuPlantillareq oPtuPlantillareq;
			PtuSolrequerimientoDTO oPtuSolrequerimientoDTO;

			dbconex = new Db();
			try
			{
				oPtuUbicaciones_dao = ObjectFactory.Instanciar<PtuUbicaciones_dao>(new PtuUbicaciones(), this.logMensajes, dbconex);
				oPtuSolreqdetalle_dao = ObjectFactory.Instanciar<PtuSolreqdetalle_dao>(new PtuSolreqdetalle(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				List<PtuRequerimiento_Editables> oPtuRequerimiento_EditablesList = oPtuUbicaciones_dao.ListarEditables(intsolicitudplantilla);

				foreach (PtuRequerimiento_Editables oPtuRequerimientoEdit in oPtuRequerimiento_EditablesList)
				{
					intcodsolicitud = oPtuRequerimientoEdit.intcodsolicitud;
					intcodplantilla = oPtuRequerimientoEdit.intcodplantilla;

					foreach (var control in controles)
					{
						string nombre = control.Key;
                        if (nombre.Contains("ctl"))
                        {
							nombre = nombre.Replace("ctl_","");
							if(nombre == oPtuRequerimientoEdit.vchetiqueta)
                            {
								string valor = "";
                                if (oPtuRequerimientoEdit.smltipogrupo == 35 || oPtuRequerimientoEdit.smltipogrupo == 36)
                                {
									if(control.Value is null)
										valor = "";
                                    else
										valor = "X";
                                }
                                else
                                {
									valor = control.Value ==null ? "" : control.Value.ToString();
								}
								
								oPtuSolreqdetalle = new PtuSolreqdetalle();
								oPtuSolreqdetalle.intcodsolreqdetalle = oPtuRequerimientoEdit.intcodsolreqdetalle;
								oPtuSolreqdetalle.vchvalor = valor;
								oPtuSolreqdetalle.vchaudusumodif = vchaudusumodif;
								oPtuSolreqdetalle.vchaudequipo = vchaudequipo;
								oPtuSolreqdetalle.vchaudprograma = vchaudprograma;
								oPtuSolreqdetalle_dao.Actualizar(oPtuSolreqdetalle);
								
								if(oPtuRequerimientoEdit.vchcampo != "X")
                                {
									string script = GenerarScript(oPtuRequerimientoEdit.vchtabla, oPtuRequerimientoEdit.vchcampo, oPtuRequerimientoEdit.vchtipovalor, valor, intcodsolicitud);
									oPtuUbicaciones_dao.EjecutarScript(script);
								}								
								break;
							}
						}						
					}

				}

				oPtuPlantillareq_dao = ObjectFactory.Instanciar<PtuPlantillareq_dao>(new PtuPlantillareq(), this.logMensajes, dbconex);
				oPtuPlantillareq = oPtuPlantillareq_dao.ListarKey(intcodplantilla);
				dbconex.RegistrarTransaccion();

				Mapeos mapeo = new Mapeos();
				oPtuSolrequerimientoDTO = mapeo.Map<PtuPlantillareq, PtuSolrequerimientoDTO>(oPtuPlantillareq);
				oPtuSolrequerimientoDTO.intsolicitudplantilla = intsolicitudplantilla;
				oPtuSolrequerimientoDTO.intcodplantilla = intcodplantilla;
				oPtuSolrequerimientoDTO.intcodsolicitud = intcodsolicitud;
				oPtuSolrequerimientoDTO.vchaudusumodif = vchaudusumodif;
				oPtuSolrequerimientoDTO.vchaudequipo = vchaudequipo;
				oPtuSolrequerimientoDTO.vchaudprograma = vchaudprograma;

				return oPtuSolrequerimientoDTO;
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			
		}

		public List<PtuPlantillareqvalores> ListarValores(int intsolicitudplantilla)
		{
			List<PtuPlantillareqvalores> oPtuPlantillareqvaloresList;
			dbconex = new Db();
			try
			{
				oPtuUbicaciones_dao = ObjectFactory.Instanciar<PtuUbicaciones_dao>(new PtuUbicaciones(), this.logMensajes, dbconex);

				dbconex.IniciarTransaccion();
				oPtuPlantillareqvaloresList = oPtuUbicaciones_dao.ListarValores(intsolicitudplantilla);
				dbconex.RegistrarTransaccion();
			}
			catch (Exception ex)
			{
				dbconex.AnularTransaccion();
				throw ex;
			}
			finally
			{
				dbconex.CerrarConexion();
			}
			return oPtuPlantillareqvaloresList;
		}

		private string GenerarScript(string tabla, string campo, string tipocampo, string valor, int? clave)
        {
            if (tipocampo != "Número")
            {
				valor = "'" + valor + "'";
			}

			string script = "UPDATE SIPT." + tabla + " SET " + campo + " = " + valor + " WHERE INTCODSOLICITUD = " + clave.ToString();
			return script;
        }
				

	}
}
