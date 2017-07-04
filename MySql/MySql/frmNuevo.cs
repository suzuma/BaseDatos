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
    public partial class frmNuevo : Form
    {
        frmMain vMain;

        public frmNuevo(frmMain tMain)
        {
            InitializeComponent();
            vMain = tMain;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quiere salir del formulario","Saliendo...",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) {
                this.Close();
            }
        }

        private void frmNuevo_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO USUARIOS (NOMBRE,APELLIDOS)VALUES('"+txtNombre.Text+"','" + txtApellidos.Text + "')";
            BaseDatos objDatos = new BaseDatos();
            if (objDatos.ejecutarAccion(sql)) {
                this.vMain.CargarDatos();                
            }
            this.Close();
           
        }
    }
}
