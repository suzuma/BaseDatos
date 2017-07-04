using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Clases;

namespace MySql
{
    public partial class frmMain : Form
    {
        private BaseDatos objDatos = new BaseDatos();
        /// <summary>
        /// funcion para llenar la cuadricula con todos el contenido de la tabla
        /// </summary>
        public void CargarDatos() {
            this.grdDatos.DataSource = objDatos.ejecutarConsulta("SELECT * FROM USUARIO");                            
        }

        public frmMain()
        {
            InitializeComponent();
            //desactivas la propiedad para que no genere las columnas mas que las que tu seleccionaste
            //this.grdDatos.AutoGenerateColumns = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            this.CargarDatos();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //generamos la consulta sql para filtrar
            string sql = "SELECT * FROM USUARIO WHERE NOMBRE LIKE '%" +  txtFiltro.Text + "%'";
            this.grdDatos.DataSource = objDatos.ejecutarConsulta(sql);
        }

        private void grdDatos_DataSourceChanged(object sender, EventArgs e)
        {
            //cuando cambia el contenido, datos, se muestra el total de registros
            lblTotal.Text="No. Registros: "+ (this.grdDatos.Rows.Count-1).ToString();
        }
    }
}
