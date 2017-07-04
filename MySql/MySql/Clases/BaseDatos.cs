using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

//using System.Data.Sql;

namespace MySql.Clases
{

    /// <summary>
    /// CLASE PARA TRABAJAR CON LA BASE DE DATOS, EN ESTE CASO SE TRABAJO CON MYSQL PERO SI SE REQUIERE TRABAJAR CON SQLSERVER
    /// SE DEBEN CAMBIAR TODAS LAS VARIABLES DE TIPO MYSQL.... A SQL.... 
    /// TAMBIEN SE DEBE INCLUIR LA LIBRERIA DE SQLSERVER.  SYSTEM.DATA.SQLSERVER
    /// </summary>
    class BaseDatos
    {
        private  MySqlConnection Cn;
        /// <summary>
        /// CONSTRUCTOR RESPONSABLE DE CONFIGURAR LA CADENA DE CONECCION Y CREAR LA INSTANCIA DEL OBJETO
        /// </summary>
        public BaseDatos() {
            Cn = new MySqlConnection();
            //cadena de coneccion aqui se cambia los datos en caso de que cambie el nombre de la base de datos
            //usuario o password
            Cn.ConnectionString = "Server=localhost;Database=acacia2017;Uid=root;Pwd=123123;";
        }
        /// <summary>
        /// FUNCION RESPONSABLE DE REALIZAR LA DESCONECCION DE LA CONECCION DE LA BASE DE DATOS
        /// </summary>
        private void desconectar() {
            try {
                if (Cn.State == System.Data.ConnectionState.Open) {
                    Cn.Close();
                }
            } catch (Exception ex) { }
        }
        /// <summary>
        /// FUNCION RESPONABLE DE REALIZAR LA CONECCION A LA BASE DE DATOS
        /// </summary>
        /// <returns>REGRESA TRUE SI LA CONECCION FUE REALIZADA CON EXITO</returns>
        private Boolean conactar() {
            Boolean res = false;
            try {
                if (Cn.State == System.Data.ConnectionState.Closed) {
                    Cn.Open();
                }
                res= true;
            } catch (Exception ex) {
                res = false;
            }
            return res;
        }

        /// <summary>
        /// FUNCION RESPONSABLE DE EJECUTAR EN LA BASE DE DATOS CUALQUIER CONSULTA SQL DE TIPO 
        /// SELECT
        /// </summary>
        /// <param name="sql">SENTENCIA SQL TIPO SELECT EJEMPLO. SELECT * FROM ALUMNOS</param>
        /// <returns>REGRESA UN OBJETO TIPO TABLA CON LOS DATOS (RESULTADOS) DE LA CONSULTA</returns>
        public DataTable ejecutarConsulta(string sql) {
            DataTable datos = new DataTable("DatosTemporal");
            try
            {
                MySqlCommand cm = new MySqlCommand(sql, Cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(datos);
            }
            catch (Exception ex) {
                //TODO: MANEJAR ERROR                
            }
            return datos;
        } 

        /// <summary>
        /// FUNCION RESPONSABLE DE EJECUTAR CUALQUIERO CONSULTA TIPO INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="sql">INSTRUCCION SQL A EJECUTAR</param>
        /// <returns>REGRESA TRUE SI LA EJECUCION FUE CORRECTA Y FALSE EN CASO CONTRARIO</returns>
        public Boolean ejecutarAccion(String sql) {
            Boolean res = false;
            try
            {
                if (this.conactar())
                {
                    MySqlCommand cm = new MySqlCommand(sql, Cn);
                    cm.ExecuteNonQuery();
                    res = true;
                }
            }
            catch (Exception ex) {
                //TODO: MANEJAR EL ERROR
            }

            return res;
        }
    }
}
