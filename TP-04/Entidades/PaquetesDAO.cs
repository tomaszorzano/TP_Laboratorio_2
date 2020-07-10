using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = "INSERT INTO dbo.Paquetes (direccionentrega,trackingId,alumno) VALUES('" +
                        p.DireccionEntrega + "','" + p.TrackingID + "', 'Luquez.Eliseo')";
                //"INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES('" + p.DireccionEntrega + p.TrackingID + "', 'Luquez.Eliseo')";
                // "INSERT INTO dbo.Paquetes (direccionEntrega,alumno,trackingID) values ('" + p.DireccionEntrega + "','Federico.Andrade'," + p.TrackingID + ")";
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al Insertar Paquete", e);
            }
        }


        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source=ELI-PC;Initial Catalog=correo-sp-2017;" +
                "Integrated Security=True");
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }


    }
}