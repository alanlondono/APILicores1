using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ConectionDAL
    {
        private static SqlConnection conexion;
        private static ConectionDAL singleton;

        public SqlConnection ConnetionFactory
        {
            get { return conexion; }
        }

        private ConectionDAL()
        {
        }

        public static string Cadena()
        {
            try
            {
                string CadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
                return CadenaConexion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ConectionDAL Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new ConectionDAL();
                conexion = new SqlConnection(Cadena());
                //conexion.Open();
                return singleton;
            }
        }

    }
}
