using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDato
{
    public class CDProducto
    {
        public string conexionString = "";


        public void ProbandoConexion()
        {
            SqlConnection CreateConection = new SqlConnection(conexionString);
            CreateConection.Open();
            string Query = " ";
            SqlCommand cmd = new SqlCommand(Query, CreateConection);
            CreateConection.Close();

        }

        public void CreateData()
        {
            SqlConnection CreateConexion = new SqlConnection(conexionString);
            CreateConexion.Open();
            string query = "";
            SqlCommand cmd = new SqlCommand(query, CreateConexion);
            cmd.ExecuteNonQuery();
            CreateConexion.Close();
        }

        public DataSet ReadData()
        {
            SqlConnection ReadConexion = new SqlConnection(conexionString);
            ReadConexion.Open();
            string query = " ";
            SqlDataAdapter adapter = new SqlDataAdapter(query,ReadConexion);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblproduct");
            return ds;

        }

        public void InsertandoDAta()
        {
            SqlConnection InsertConexion = new SqlConnection(conexionString);
            InsertConexion.Open();
            string query = " dd";
            SqlCommand cmd = new SqlCommand(query, InsertConexion);
            cmd.ExecuteNonQuery();
            InsertConexion.Close();
        }

        public DataSet CargandDatos()
        {
            SqlConnection cargarConexion = new SqlConnection(conexionString);
            cargarConexion.Open();
            string query = " ";
            SqlDataAdapter adatador = new SqlDataAdapter(query,cargarConexion);
            DataSet ds = new DataSet();
            adatador.Fill(ds, "TBL1");

            return ds;
        }

        public void Eliminando()
        {
            SqlConnection ElimnarConexion = new SqlConnection(conexionString);
            ElimnarConexion.Open();
            string query = "";
            SqlCommand cmd = new SqlCommand(query, ElimnarConexion);
            cmd.ExecuteNonQuery();
            ElimnarConexion.Close();

        }
        
        
    }
}
