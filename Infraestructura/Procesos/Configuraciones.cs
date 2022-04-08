using Infraestructura.CRUD;
using System;
using System.Data;

namespace Infraestructura.Procesos
{
    //Se hereda de la clase BDConsultar para poder ejecutar el procedimiento almacenado
    // para realizar la conexion con la base de datos
    public class Configuraciones: BDConsultar
    {
        //Se instancian las variables que serán usadas para ejecutar el procedimiento almacenado

        //Se crea la variable que podrá llamar a los servicios del web service
        public static WSUNOEE.WSUNOEE _WebServiceUnoee = new WSUNOEE.WSUNOEE();


        public static string ConexionSiesa;
        public static string NombreConexion;
        public static int IdCia;
        public static string IdProveedor;
        public static string IdConsulta;
        public static string Usuario;
        public static string Clave;

        //Se crea un procedimiento para realizar la conexion enviando el procedimiento almacenado
        //con los parametros
        public void Obtener()
        {
            //Se crea un DataSet para ejecutar el procedimiento almacenado
            DataSet DsConfiguraciones = EjecutarSP("Sp_ObtenerPropiedades");
            //Se le mandan las variables al procedimiento almacenado para que pueda realizar la conexion
            //con el web service de siesa y la base de datos
            ConexionSiesa = Convert.ToString(DsConfiguraciones.Tables[0].Rows[0]["ConexionSiesa"]);
            NombreConexion = Convert.ToString(DsConfiguraciones.Tables[0].Rows[0]["NombreConexion"]);
            IdCia = Convert.ToInt16(DsConfiguraciones.Tables[0].Rows[0]["IdCia"]);
            IdProveedor = Convert.ToString(DsConfiguraciones.Tables[0].Rows[0]["IdProveedor"]);
            IdConsulta = Convert.ToString(DsConfiguraciones.Tables[0].Rows[0]["IdConsulta"]);
            Usuario = Convert.ToString(DsConfiguraciones.Tables[0].Rows[0]["Usuario"]);
            Clave = Convert.ToString(DsConfiguraciones.Tables[0].Rows[0]["Clave"]);
        }
    }
}
