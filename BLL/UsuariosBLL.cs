using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTIDADES;

namespace BLL
{
    public class UsuariosBLL
    {
        public List<Usuarios> obtenerUsuarios()
        {
            UsuariosDAL tipo = new UsuariosDAL();
            return tipo.obtenerUsuarios();
        }
    }
}
