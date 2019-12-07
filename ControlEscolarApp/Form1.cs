using System;
using System.Windows.Forms;
using Entidades.ControlEscolarApp;
using LogicaNegocio.ControlEscolarApp;

namespace ControlEscolarApp
{
    public partial class FrmUsers : Form
    {
        UsuarioManejador _usuarioManejador;
        Usuarios _usiario;
        public FrmUsers()
        {
            InitializeComponent();
            _usuarioManejador = new UsuarioManejador();
            _usiario = new Usuarios();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuscarUsuarios("");
        }

        private void BuscarUsuarios(string filtro)
        {
            dgvUsuarios.DataSource = _usuarioManejador.ObtenerLista(filtro);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuarios(txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro Que Desea Eliminar El Regitro Seleccionado","Eliminar Registro",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                try
                {
                    Eliminar();
                    BuscarUsuarios("");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Eliminar()
        {
            int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idusuario"].Value);
            _usuarioManejador.Eliminar(id);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuariosModal usuariosModal = new UsuariosModal();
            usuariosModal.ShowDialog();
            BuscarUsuarios("");
        }

        private void BindingUsuarios()
        {
            _usiario.IdUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idusuario"].Value);
            _usiario.Nombre = dgvUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
            _usiario.ApellidoPaterno = dgvUsuarios.CurrentRow.Cells["apellidopaterno"].Value.ToString();
            _usiario.ApellidoMaterno = dgvUsuarios.CurrentRow.Cells["apellidomaterno"].Value.ToString();


        }

      

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingUsuarios();
            UsuariosModal usuariosmoldal = new UsuariosModal(_usiario);
            usuariosmoldal.ShowDialog();
            BuscarUsuarios("");
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingUsuarios();
        }
    }
}
