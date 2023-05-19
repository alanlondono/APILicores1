using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DAL
{
    public class UsuariosDAL
    {
        SqlConnection Conn = new SqlConnection();
        /// <summary>
        /// Metodo par listar los clientes existentes
        /// </summary>
        /// <returns></returns>
        public List<Usuarios> obtenerUsuarios()
        {

            try
            {
                Conn = ConectionDAL.Singleton.ConnetionFactory;
                Conn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[ObtenerClientes]", Conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                List<Usuarios> listaUsuarios = new List<Usuarios>();
                listaUsuarios = (from DataRow dr in dt.Rows
                                 select new Usuarios
                                 {
                                     Id_Usuario = Convert.ToInt32(dr["id_cliente"]),
                                     Nombres = dr["nombres"].ToString(),
                                     Apellidos = dr["apellidos"].ToString(),
                                     numeroIdentificacion = dr["identificacion"].ToString()

                                 }).ToList();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
            finally
            {
                Conn.Close();
            }
        }
    }
        
}
