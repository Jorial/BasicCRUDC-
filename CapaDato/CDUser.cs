using System.Data;
using System.Data.SqlClient;
using CapaDato;
using CapaEntidad;
namespace CapaDato
{
    public class CDUser
    {
        // Creando la conexion con la base de datos

        // cade de conexion
         //string StringConexion = @"Server=MGTMGTMD0110\MAINSERVER;User=jose;Password=Alonso123;database=CRUD_db"; 
        string StringConexion = @"Server=MGTMGTMD0110\MAINSERVER;Database=CRUD_db;Trusted_Connection=True";

        public void Prueba()
        {
            SqlConnection Conexion = new SqlConnection(StringConexion);
            try
            {
                Conexion.Open();
                MessageBox.Show("Conectado");

            }
            catch (Exception ex)
            {
                Conexion.Close();
                MessageBox.Show("Erro de Conexion" + ex.Message);
                throw;
            }
            
        }
        /***********************************************/

        // Creando CRUD a la base de datos
        public void CrearUsuario(CEUsuario CEU)
        {
            try
            {
                // instanciamos la conexion
                SqlConnection userconexion = new SqlConnection(StringConexion);
                // abrimos la conexion
                userconexion.Open();
                // creamos la cadena a ejecutar 
                string Query = "INSERT INTO usuario (id,nombre, apellido, foto) values ('" + CEU.Id + "','" + CEU.Nombre + "','" + CEU.Apellido + "','" + CEU.Foto + "' );";
                //  instacionamos el comando de sql pasamos 2 valores, 1 la consulta 2 la conexion
                SqlCommand cmd = new SqlCommand(Query, userconexion);
                // Ejecutamos con execute no Query
                cmd.ExecuteNonQuery();
                // Cerramos la conexion a la base de datos 
                userconexion.Close();
                // creando la notificacion 
                MessageBox.Show("Registro Creado");
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Crear usuario" + ex.Message);

                throw;
            }

            

        }

        /***********************************************/

        // Leer Datos de la Base de Datos
        public DataSet ListarUsuarios()
        {
            try
            {
                SqlConnection readConexion = new SqlConnection(StringConexion);
                readConexion.Open();
                string Query = "SELECT id As ID, nombre As Name, apellido as 'Last Name', foto as Picture  FROM usuario;";
                SqlDataAdapter adapter;
                DataSet ds = new DataSet();

                adapter = new SqlDataAdapter(Query, readConexion);
                adapter.Fill(ds, "tbluser");

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los usuarios" + ex.Message);
                throw;
            }
            

        }
         /***********************************************/
        public void EditarUser(CEUsuario ceU)
        {
            try
            {
                SqlConnection conexionEditar = new SqlConnection(StringConexion);
                conexionEditar.Open();
                string Query = "update usuario set nombre = '" +ceU.Nombre + "', apellido = '" + ceU.Apellido +"', foto = '"+ ceU.Foto +"' where id ="+ ceU.Id + ";";
                SqlCommand command = new SqlCommand(Query, conexionEditar);
                command.ExecuteNonQuery();
                conexionEditar.Close();
                MessageBox.Show("Registro Editado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Editar el Usuario" + ex.Message);
                throw;
            }
            
        }
       
        public void EliminarUser(CEUsuario ceU)
        {
            try
            {
                SqlConnection userConn = new SqlConnection(StringConexion);
                userConn.Open();
                string query = "delete from usuario where id =" + ceU.Id + ";";
                SqlCommand cmd = new SqlCommand(query, userConn);
                cmd.ExecuteNonQuery();
                userConn.Close();
                MessageBox.Show("El usuario ha sido Eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar el usuario" + ex.Message);
                throw;
            }
        }

        public DataSet LlenarCBX()
        {
            SqlConnection llenarConexion = new SqlConnection(StringConexion);
            llenarConexion.Open();
            string query = "select id, CONCAT(nombre, ' ' , apellido) as Usuarios from usuario;";
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();

            adapter = new SqlDataAdapter(query, llenarConexion);
            adapter.Fill(ds, "CBXuser");

            return ds;

        }

        

    }
}