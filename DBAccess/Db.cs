using System;
using System.Data.Common;
using System.Data.SqlClient;
using IBM.Data.DB2;

namespace DBAccess
{
    public class Db: IDisposable
    {
        private DbConnection conex;
        private DbTransaction trans;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void CrearConexion()
        {
            if (this.conex is null)
            {
                if (Conexion.Servidor == "SqlServer")
                {
                    this.conex = new SqlConnection(Conexion.CadenaConexion);
                }
                else if (Conexion.Servidor == "Db2")
                {
                    this.conex = new DB2Connection(Conexion.CadenaConexion);
                }
                else if (Conexion.Servidor == "Oracle")
                {
                }
                this.conex.Open();
            }
        }

       
        public DbTransaction IniciarTransaccion()
        {
            if (this.conex is null)
            {
                CrearConexion();
            }
            else
            {
                if(this.conex.State == System.Data.ConnectionState.Closed)
                {
                    this.conex.Open();
                }
            }

            if (this.trans is null)
            {
                this.trans = this.conex.BeginTransaction();
            }
            return this.trans;
        }

        public DbTransaction Transaccion()
        {
            /*if (this.trans is null)
            {
                return this.conex;                
            }
            else
            {
                return this.trans;
            }*/
            return this.trans;
            
        }

        public void RegistrarTransaccion()
        {
            if (this.trans is null)
            { }
            else
            {
                this.trans.Commit();
                this.trans.Dispose();
                this.trans = null;
            }
        }


        public void AnularTransaccion()
        {
            if (this.trans is null)
            { }
            else
            {
                this.trans.Rollback();
                this.trans.Dispose();
                this.trans = null;
            }
        }
        public void CerrarConexion()
        {
            if (this.trans is null)
            { }
            else
            {
                this.trans.Dispose();
                this.trans = null;
            }

            if (this.conex is null)
            { }
            else 
            {
                this.conex.Close();
                this.conex.Dispose();
                this.conex = null;                
            }

            this.Dispose();
        }

    }
}