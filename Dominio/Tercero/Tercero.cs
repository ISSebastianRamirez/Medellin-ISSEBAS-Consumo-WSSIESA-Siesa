using Infraestructura.Procesos;
using System.Data;

namespace Dominio.Tercero
{
    //Esta clase hereda de la clase conexion para poder obtener el valor de las varibales
    //que están instanciadas en la clase configuracion
    public class Tercero : Configuraciones
    {
        //Se crea un procedimiento que retorne un DataSet para poder
        //hacer uso del servicio de Consultar del Web service de siesa
        public DataSet ConsultarTercero(string Cia, string Tercero)
        {
            //Se retorna la ejecucion del servicio de consular utilizando la varibale
            //creada en la clase Configuraciones para poder hacer uso de los servicios
            //del web service de siesa.

            //Luego se crea un XML con la estructura correspondiente para poder realizar la consulta
            //Utilizando las varibales definidas en la clase Configuraciones 
            //para poder realizar la conexion y ejecucion del servicio
            return _WebServiceUnoee.EjecutarConsultaXML("<Consulta>" +
                $"<NombreConexion>{NombreConexion}</NombreConexion>" +
                $"<IdCia>{IdCia}</IdCia>" +
                $"<IdProveedor>{IdProveedor}</IdProveedor>" +
                $"<IdConsulta>{IdConsulta}</IdConsulta>" +
                $"<Usuario>{Usuario}</Usuario>" +
                $"<Clave>{Clave}</Clave>" +
                $"<Parametros><idcia>{Cia}</idcia><tercero>{Tercero}</tercero></Parametros>" +
                $"</Consulta>");
        }

        //Se crea el procedimiento que retornará un dataset con la importacion
        public string ActualizarTercero(string contacto50,string direccion40,string telefono20,string celular50,string email255)
        {
            //Infraestructura.WSGT.wsGenerarPlano objGTI = new Infraestructura.WSGT.wsGenerarPlano();

            //DataTable table1 = new DataTable("Terceros_Prueba");
            //table1.Columns.Add("CodTercero");
            //table1.Columns.Add("NumIdentificacion");
            //table1.Rows.Add(tercero, tercero);


            //// Create a DataSet and put both tables in it.
            //DataSet set = new DataSet("office");
            //set.Tables.Add(table1);
            //var resultado = "C:\\inetpub\\wwwroot\\GTIntegration\\Planos\\";
            //short resultado2 = 0;

            //Se crea la varibale error la cual nos dirá el resultado de la importación
            short Resultado = 0;

            //string RespuestaServicio = string.Empty;

            //Se retorna la ejecucion del servicio de importar utilizando la varibale
            //creada en la clase Configuraciones para poder hacer uso de los servicios
            //del web service de siesa.

            //Luego se crea un XML con la estructura correspondiente para poder realizar la importacion
            //respetando las posiciones que maneja cada uno de los campos.

            //Estas posiciones podemos confirmarlas con el Generic Transfer al momento de personalizar la estructura
            //del conector cuando lo se crea.

            //Utilizando las varibales definidas en la clase Configuraciones 
            //para poder realizar la conexion y ejecucion del servicio

            var strXML= "<Importar>" +
                $"<NombreConexion>{NombreConexion}</NombreConexion>" +
                $"<IdCia>{IdCia}</IdCia>" +
                $"<Usuario>{Usuario}</Usuario>" +
                $"<Clave>{Clave}</Clave>" +
                $"<Datos>" +
                $"<Linea>000000100000001003</Linea>" +
                $"<Linea>00000020200000800311001456468     1001456468                  C1RAMIREZ GARCIA SEBASTIAN                                                                            RAMIREZ                      GARCIA                       SEBASTIAN                               INTERFACES Y SOLUCIONES                           000000" + contacto50 + direccion40+"                                                                                16905266LAS VEGAS                               "+telefono20+"                              "+email255+"20011126    11"+celular50+"</Linea>" +
                $"<Linea>000000399990001003</Linea>" +
                $"" +
                $"</Datos>" +
                $"" +
                $"</Importar>";

            var DsResponse = _WebServiceUnoee.ImportarXML(strXML.ToString(), ref Resultado);

            //if(Resultado == 0) { RespuestaServicio = "Importación Exitosa"; } else { RespuestaServicio = DsResponse.Tables[0].Rows[0]["f_detalle"].ToString();}

            return Resultado == 0 ? "Importación Exitosa" : DsResponse.Tables[0].Rows[0]["f_detalle"].ToString();
        }
    }
}
