using SistemaBusqueda2.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusqueda2.Repositorios
{
    public class PaisRepositorio
    {
        public List<PaisesListaModelo> ObtenerPaises()
        {
            var respuesta = new List<PaisesListaModelo>();
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_mostrar_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoPais = new PaisesListaModelo()
                    {
                        Codpais = (int)reader["codpais"],
                        Nombrepais = reader["nombrepais"].ToString(),
                    };

                    respuesta.Add(nuevoPais);
                }
            }
            return respuesta;
        }

        public void InsertarPais(string nombrepais)
        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_insertar_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombrepais", nombrepais));

            sql.Open();
            cmd.ExecuteNonQuery();
        }

       

       

        public PaisesListaModelo ObtenerPaisPorId(int codpais)
        {
            var respuesta = new PaisesListaModelo();
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_obtiene_pais_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codpais", codpais));

            sql.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoPais = new PaisesListaModelo()
                    {
                        Codpais = (int)reader["codpais"],
                        Nombrepais = reader["nombrepais"].ToString(),
                    };

                    respuesta = nuevoPais;
                }
            }
            return respuesta;
        }

        public void ActualizarPais(int codpais, string nombrepais)

        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_actualizar_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codpais", codpais));
            cmd.Parameters.Add(new SqlParameter("@nombrepais", nombrepais));

            sql.Open();
            cmd.ExecuteNonQuery();
        }
        public void EliminarPais(int Codpais)
        {
            string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand("sp_elimina_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codpais", Codpais));

            sql.Open();
            cmd.ExecuteNonQuery();
        }


    }
}
