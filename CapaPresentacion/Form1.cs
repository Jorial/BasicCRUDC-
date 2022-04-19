using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion

{
    public partial class FrmUser : Form
    {
        CNUsuario cNUsuario = new CNUsuario();

        public FrmUser()
        {
            InitializeComponent();
            CargarDatos();
            LlenadoCBX();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            
        }

        public void LimpiarDatos()
        {
            TxtId.Value = 0;
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            PicPhoto.Image = null;
            TxtId.Enabled = true;
        }

        private void Lkphoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // configurando el seleccionador de imagen
            OFDFoto.FileName = string.Empty;

            if (OFDFoto.ShowDialog() == DialogResult.OK)
            {
                PicPhoto.Load(OFDFoto.FileName);
            }

            OFDFoto.FileName = String.Empty;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
          

        }

        public void GuardarDatos()
        {
            CEUsuario cEUsuario = new CEUsuario();

            bool validate;

            cEUsuario.Id = (int)TxtId.Value;
            cEUsuario.Nombre = TxtNombre.Text;
            cEUsuario.Apellido = TxtApellido.Text;
            cEUsuario.Foto = PicPhoto.ImageLocation;

            validate = cNUsuario.ValidarDatos(cEUsuario);
            if (validate == false)
            {
                return;
            }

            if (TxtId.Enabled == true)
            {
                cNUsuario.InsertarUsuario(cEUsuario);
                               

            }
            else
            {
                cNUsuario.EditarUsuario(cEUsuario);
            }

            CargarDatos();            

            MessageBox.Show("Exelente!!!");
            LimpiarDatos();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (TxtId.Value == 0) return;

            if (MessageBox.Show("Esta Seguro de elimar el registro ?","Titulo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CEUsuario ce = new CEUsuario();
                ce.Id = (int)TxtId.Value;
                cNUsuario.EliminarUsuario(ce);
                CargarDatos();
                LimpiarDatos();             

            }



            
        }

        public void CargarDatos()
        {
            DgvUser.DataSource = cNUsuario.ObetenerDatos().Tables["tbluser"];
        }

        public void LlenadoCBX()
        {
            CBXuser.DataSource = cNUsuario.LLenandoCBX().Tables["CBXuser"];
            CBXuser.ValueMember = "id";
            CBXuser.DisplayMember = "Usuarios";        
        }

        private void DgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Value = Convert.ToInt32(DgvUser.CurrentRow.Cells["ID"].Value);
            TxtNombre.Text = DgvUser.CurrentRow.Cells["Name"].Value.ToString();
            TxtApellido.Text = DgvUser.CurrentRow.Cells["Last Name"].Value.ToString();
            PicPhoto.Load(DgvUser.CurrentRow.Cells["Picture"].Value.ToString());
            TxtId.Enabled = false;
        }

        private void OFDFoto_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}