using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.DTO.Mapper;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;

namespace SIPT.BL.Services
{
    public class PtuUso_bo
    {
        private PtuUso_dao oPtuUso_dao;
        private List<PtuUso> oPtuUsoList;
        private List<PtuUsoDTO> oPtuUsoDTOList;

        private PtuUso pPtuUso;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuUso_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public  void Insertar(PtuUso pPtuUso) 
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                oPtuUso_dao.Insertar(pPtuUso);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Actualizar(PtuUso pPtuUso) 
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                
                oPtuUso_dao.Actualizar(pPtuUso);
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Eliminar(PtuUso pPtuUso)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                
                oPtuUso_dao.Eliminar(pPtuUso);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public List<PtuUso> Listar()
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                
                oPtuUsoList = oPtuUso_dao.Listar();

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuUsoList;
        }

        public PtuUso ListarPorId(int? intcoduso)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                
                pPtuUso = oPtuUso_dao.ListarPorId(intcoduso);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return pPtuUso;
        }
        
        public List<PtuUsoDTO> ListarPorFiltro(PtuUso pPtuUso)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();

                oPtuUso_dao = ObjectFactory.Instanciar<PtuUso_dao>(new PtuUso(), this.logMensajes, dbconex);
                
                oPtuUsoList = oPtuUso_dao.ListarPorFiltro(pPtuUso);

                Mapeos mapeo = new Mapeos();
                PtuUsoDTO ptuUsoDTO;
                oPtuUsoDTOList = new List<PtuUsoDTO>();
                foreach (PtuUso oPtuUso in oPtuUsoList)
                {
                    ptuUsoDTO = mapeo.Map<PtuUso, PtuUsoDTO>(oPtuUso);
                    ptuUsoDTO.vchnombreusocompleto = oPtuUso.vchcoduso + " - " + oPtuUso.vchnombreuso;

                    oPtuUsoDTOList.Add(ptuUsoDTO);
                }
                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuUsoDTOList;
        }

    }
}