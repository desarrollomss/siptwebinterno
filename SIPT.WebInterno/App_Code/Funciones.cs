using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Configuration;
using SIPT.APPL.Logs;
using SIPT.BL.DTO.DTO;
using SIPT.BL.Models.Consultas;
using SIPT.BL.Models.Entity;
using SIPT.BL.Services;
using SIPT.APPL.FrondEnd;
using System.Web.UI.WebControls;

namespace SIPT.WebInterno.App_Code
{

    public class Funciones
    {
        public int? codigo { get; set; }
        public string nombre { get; set; }


        //private LogMensajes logMensajes;
        //private Request request;
        //private Usuario_bo oUsuario_bo;
        public static DataTable ListarUsuariosRol(Request request, string pRolName)
        {
            LogMensajes logMensajes = new LogMensajes(request, System.Reflection.MethodBase.GetCurrentMethod().Name);


            DataTable dtTabla = null;
            DataColumn dcColumna;
            DataRow row;

            dtTabla = new DataTable("ANALISTA");

            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "INTUSUANALISTA";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);


            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "VCHUSUANALISTA";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);

            row = dtTabla.NewRow();

            Usuario_bo oUsuario_bo = new Usuario_bo(ref logMensajes);
            List<SicUsuario> oSicUsuarioList = oUsuario_bo.ListarUsuariosAppRol("SIPT", pRolName );

            foreach (SicUsuario Analista in oSicUsuarioList)
            {
                row = dtTabla.NewRow();

                row["INTUSUANALISTA"] = Analista.intusuariocodigo;
                row["VCHUSUANALISTA"] = Analista.vchusuarionombres;
                dtTabla.Rows.Add(row);
            }

            return dtTabla;
        }

        public static DataTable ListarAnio()
        {
            Int32 lnmAnio = Convert.ToInt32(ConfigurationManager.AppSettings["AnioInicio"]);

            DataTable dtTabla = null;
            DataColumn dcColumna;
            DataRow row;

            dtTabla = new DataTable("ANIOS");

            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "INTANIO";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);


            dcColumna = new DataColumn();
            dcColumna.DataType = System.Type.GetType("System.String");
            dcColumna.ColumnName = "TXTANIO";
            dcColumna.DefaultValue = "";
            dtTabla.Columns.Add(dcColumna);

            row = dtTabla.NewRow();

            for (int i = lnmAnio; i <= lnmAnio; i++)
            {
                row = dtTabla.NewRow();

                row["INTANIO"] = i;
                row["TXTANIO"] = i.ToString();
                dtTabla.Rows.Add(row);
            }

            return dtTabla;
        }



        public static void LlenarComboBox(ref DropDownList ddl, DataTable dt, string Valor, string Texto, Cabecera titulo)
        {
            ddl.DataSource = dt;
            ddl.DataValueField = Valor;
            ddl.DataTextField = Texto;
            ddl.DataBind();
            string txt = "";
            if (titulo == Cabecera.Seleccione)
            {
                txt = "-- Seleccione --";
            }
            else if (titulo == Cabecera.Todos)
            {
                txt = "-- Todos --";
            }
            ddl.Items.Insert(0, new ListItem(txt));

        }

        public enum Cabecera
        {
            Seleccione = 0,
            Todos = 1
        }

    }

}