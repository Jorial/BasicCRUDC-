using CapaEntidad;
using CapaDato;
using System.Data;
namespace CapaNegocio
{
    // Creando reglas para validar los datos. 
    public class CNUsuario
    {
        CDUser cDUser = new CDUser();
        public bool ValidarDatos(CEUsuario user)
        {
            if (user.Nombre == string.Empty)
            {
                MessageBox.Show("El Nombre del Usuario es Requerido");
                return false;
            }
             if(user.Apellido == string.Empty)
            {
                MessageBox.Show("El Apellido del Usuario es Requidio");               
                return false;
            }
            if (user.Foto == null)
            {
                MessageBox.Show("Debe seleccionar una Foto");
                return false;
            }

            return true;
        }

        public void conectarsql()
        {
            cDUser.Prueba();

        }

        public void InsertarUsuario(CEUsuario cE)
        {
            cDUser.CrearUsuario(cE);
        }

        public DataSet ObetenerDatos()
        {
            return cDUser.ListarUsuarios();
        }

        public void EditarUsuario(CEUsuario ceu)
        {
            cDUser.EditarUser(ceu);
        }
        public void EliminarUsuario(CEUsuario ceu)
        {
            cDUser.EliminarUser(ceu);
        }

        public DataSet LLenandoCBX()
        {
            return cDUser.LlenarCBX();
        }

    }
}