using Microsoft.Data.SqlClient;
using System.Data;

namespace Proyecto_final
{
    public static class Conexion
    {
        public static SqlConnection cn = new SqlConnection(
            "Server=localhost;Database=empleo_local;Integrated Security=True;TrustServerCertificate=True;");

        public static void Abrir()
        {
            if (cn.State == ConnectionState.Closed) cn.Open();
        }

        public static void Cerrar()
        {
            if (cn.State == ConnectionState.Open) cn.Close();
        }
    }
}