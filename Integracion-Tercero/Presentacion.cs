using System;
using System.Data;
using System.Windows.Forms;

namespace Integracion_Tercero
{
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        //Se instancia una varibale del proyecto infraestructura
        // y de la clase configuraciones para obtener los procedimientos

        public Infraestructura.Procesos.Configuraciones _Configuraciones = new Infraestructura.Procesos.Configuraciones();

        private void Presentacion_Load(object sender, System.EventArgs e)
        {
            //Va a la clase configuraciones para obtener los valores de las variables para la conexion
            //para la consulta
            _Configuraciones.Obtener();
        }

        //procedimiento para realizar la consulta al web service de siesa y trater los resultados
        //usando una consulta hecha en sqlserver para poder traer la información que necesitamos mostrar
        private void ConsultarTercero_Click(object sender, System.EventArgs e)
        {
            //Se instancia una variable del proyecto dominio 
            // y de la clase tercero
            Dominio.Tercero.Tercero _Tercero = new Dominio.Tercero.Tercero();
            //Se crea una variable tipo DataSet para llenarla con el procedimiento que traemos 
            // de la clase de terceros.
            DataSet DsTercero = new DataSet();
            DsTercero = _Tercero.ConsultarTercero(idCia.Text.ToString(), idTercero.Text.ToString());

            //Se crea una matriz con la cual se llenará cada uno de los textbox del formulario
            if(DsTercero.Tables.Count > 0)
            {
                idCia.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["Cia"]);
                idTercero.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["IdTercero"]);
                idTipo.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["IdTipoIdent"]);
                razonSocial.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["RazonSocial"]);
                fechaNacimiento.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["FechaNacimiento"]);
                nombreEstable.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["NombreEstab"]);
                primerApellido.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["PrimerApellido"]);
                segundoApellido.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["SegundoApellido"]);
                txtContacto.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["Contacto"]);
                txtDireccion.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["Direccion"]);
                txtTelefono.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["Telefono"]);
                txtCelular.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["Celular"]);
                txtEmail.Text = Convert.ToString(DsTercero.Tables[0].Rows[0]["Email"]);
            }
        }
        //Proceso para importar un tercero o un registro por medio del web service de siesa
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Dominio.Tercero.Tercero _Tercero = new Dominio.Tercero.Tercero();
            DataSet DsTercero = new DataSet();

            string contacto50 = txtContacto.Text.ToString().Length > 50 ? string.Empty : txtContacto.Text.ToString().PadRight(50);
            string direcion40 = txtDireccion.Text.ToString().Length > 40 ? string.Empty : txtDireccion.Text.ToString().PadRight(40);
            string telefono20 = txtTelefono.Text.ToString().Length > 20 ? string.Empty : txtTelefono.Text.ToString().PadRight(20);
            string celular50 = txtCelular.Text.ToString().Length > 50 ? string.Empty : txtCelular.Text.ToString().PadRight(50);
            string email255 = txtEmail.Text.ToString().Length > 255 ? string.Empty : txtEmail.Text.ToString().PadRight(255);
            if (contacto50 != string.Empty && direcion40 != string.Empty && telefono20 != string.Empty && celular50 != string.Empty && email255 != string.Empty) { MessageBox.Show(_Tercero.ActualizarTercero(contacto50.ToString(), direcion40.ToString(), telefono20.ToString(), celular50.ToString(), email255.ToString())); } else { MessageBox.Show("Sobrepaso el limite revise bien el tamaño"); }

            //string contacto50 = txtContacto.Text.ToString();


            //if (contacto50.Length > 50)
            //{
            //    MessageBox.Show("Sobrepaso el limite de caracteres permitidos");
            //}
            //else
            //{
            //    contacto50 = contacto50.PadRight(50);
            //    DsTercero = _Tercero.ActualizarTercero(contacto50.ToString());

            //}


            //Se instancia una variable del proyecto dominio 
            // y de la clase tercero
            //Dominio.Tercero.Tercero _Tercero = new Dominio.Tercero.Tercero();
            //Se crea una variable tipo DataSet para llenarla con el procedimiento que traemos 
            // de la clase de terceros.
            //DataSet DsTercero = new DataSet();
            //DsTercero = _Tercero.ActualizarTercero(idCia.Text.ToString(), idTercero.Text.ToString());


        }
    }
}
