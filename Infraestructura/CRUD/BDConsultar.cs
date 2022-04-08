using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDConsultar
    {
        public DataSet EjecutarSP(string NombreProcedimiento)
        {
            DataSet DsGenerico = new DataSet();

            SqlConnection _SqlConnection = new SqlConnection(Settings.Default.ConexionSebas);
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            SqlCommand _SqlCommand = new SqlCommand();

            _SqlCommand.Connection = _SqlConnection;
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            _SqlCommand.CommandText = NombreProcedimiento;
            _SqlCommand.CommandTimeout = 999999999;
            _SqlDataAdapter.SelectCommand = _SqlCommand;

            try
            {
                _SqlCommand.Connection.Open();
                _SqlDataAdapter.Fill(DsGenerico);
                return DsGenerico;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                _SqlCommand.Connection.Close();
            }
        }
    }
}
