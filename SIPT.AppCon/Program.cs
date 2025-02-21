using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SIPT.AppCon
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sbLista = new StringBuilder();
            String strPathPDF = @"C:\archivos\PDF\";
            String strPathZIP = @"C:\archivos\ZIP\";

            String strPackedFile = strPathZIP + "Proceso_" + DateTime.Now.ToString("MMddHHmmss") + ".7z";

            sbLista.Append(strPathPDF + "06790326.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07036362.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07061936.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07164691.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07250110.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07368577.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07634848.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07755200.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07809452.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "07866800.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "47223827.PDF"); sbLista.Append(" ");
            sbLista.Append(strPathPDF + "74972862.PDF"); sbLista.Append(" ");

            comprimirArchivos(sbLista, strPackedFile);

        }

        static void comprimirArchivos(StringBuilder psbLista, string archivoZip)
        {
            string directorio7z = @"C:\Program Files\7-Zip\7z.exe";
            //System.mana .Configuration.AppSettingsReader("Ruta7Zip"); // Ruta al ejecutable de 7-Zip   
            string argumentos;
            argumentos = "a " + archivoZip + " " + psbLista.ToString();
            Process proceso = new Process();
            proceso.StartInfo.FileName = directorio7z;
            proceso.StartInfo.Arguments = argumentos;
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.RedirectStandardOutput = true;
            proceso.Start();

            //Puedes manejar el resultado del proceso aquí
            string resultado = proceso.StandardOutput.ReadToEnd();
            proceso.Close();

        }

    } 
}
