using DBAccess;
using SIPT.APPL.Logs;
using SIPT.BL.Models.Entity;
using SIPT.DAL.Dao.Base;
using SIPT.DAL.Dao.Factory;
using System;
using System.Collections.Generic;

namespace SIPT.BL.Services
{
    public class PtuSolLicenciaAnalista_bo
    {
        private PtuSolLicenciaAnalista_dao oPtuSolLicenciaAnalista_dao;
        private List<PtuSolLicenciaAnalista> oPtuSolLicenciaAnalistaList;
        private PtuSolLicenciaAnalista oPtuSolLicenciaAnalista;
        private LogMensajes logMensajes;
        private Db dbconex;

        public PtuSolLicenciaAnalista_bo(ref LogMensajes logMensajes)
        {
            this.logMensajes = logMensajes;
        }

        public void Insertar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicenciaAnalista_dao = ObjectFactory.Instanciar<PtuSolLicenciaAnalista_dao>(new PtuSolLicenciaAnalista(), this.logMensajes, dbconex);


                oPtuSolLicenciaAnalista_dao.Insertar(pPtuSolLicenciaAnalista);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Actualizar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicenciaAnalista_dao = ObjectFactory.Instanciar<PtuSolLicenciaAnalista_dao>(new PtuSolLicenciaAnalista(), this.logMensajes, dbconex);

                oPtuSolLicenciaAnalista_dao.Actualizar(pPtuSolLicenciaAnalista);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public void Eliminar(PtuSolLicenciaAnalista pPtuSolLicenciaAnalista)
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicenciaAnalista_dao = ObjectFactory.Instanciar<PtuSolLicenciaAnalista_dao>(new PtuSolLicenciaAnalista(), this.logMensajes, dbconex);

                oPtuSolLicenciaAnalista_dao.Eliminar(pPtuSolLicenciaAnalista);

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
        }

        public List<PtuSolLicenciaAnalista> Listar()
        {
            dbconex = new Db();
            try
            {
                dbconex.IniciarTransaccion();
                oPtuSolLicenciaAnalista_dao = ObjectFactory.Instanciar<PtuSolLicenciaAnalista_dao>(new PtuSolLicenciaAnalista(), this.logMensajes, dbconex);

                oPtuSolLicenciaAnalistaList = oPtuSolLicenciaAnalista_dao.Listar();

                dbconex.RegistrarTransaccion();
            }
            finally
            {
                dbconex.CerrarConexion();
            }
            return oPtuSolLicenciaAnalistaList;
        }


    }
}