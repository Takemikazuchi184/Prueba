using System;
using System.Windows.Forms;
using LogicaNegocio.ControlEscolarApp;
using Entidades.ControlEscolarApp;

namespace ControlEscolarApp
{
    public partial class UsuariosModal : Form
    {
        private UsuarioManejador _usuarioManejador;
        private Usuarios _usuarios;
        private bool _isEnabledBinding = false;
        public UsuariosModal()
        {
            InitializeComponent();
            _usuarioManejador = new UsuarioManejador();
            _usuarios = new Usuarios();
            _isEnabledBinding = true;
            BindingUsuario();

            
        }

        public UsuariosModal(Usuarios usuario)
        {
            _usuarioManejador = new UsuarioManejador();
            _usuarios = new Usuarios();
            _usuarios = usuario;
            InitializeComponent();
            BindingUsuarioReload();
            _isEnabledBinding = true;

        }

        private void BindingUsuarioReload()
        {
            txtNombre.Text = _usuarios.Nombre;
            txtAPaterno.Text = _usuarios.ApellidoPaterno;
            txtAMaterno.Text = _usuarios.ApellidoMaterno;
            

        }



        private void UsuariosModal_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BindingUsuario();
            if (ValidarUsuario())
            {
                Guardar();
                this.Close();
            }
            
        }

        private void Guardar()
        {
            _usuarioManejador.Guardar(_usuarios);
        }
        private bool ValidarUsuario()
        {
            var res = _usuarioManejador.EsUsuarioValido(_usuarios);
            if (!res.Item1)
            {
                MessageBox.Show(res.Item2);
            }

            return res.Item1;
        }

        private void BindingUsuario()
        {
            if (_isEnabledBinding)
            {
                if (_usuarios.IdUsuario == 0)
                {
                    _usuarios.IdUsuario = 0;
                    
                }
                _usuarios.Nombre = txtNombre.Text;
                _usuarios.ApellidoPaterno = txtAPaterno.Text;
                _usuarios.ApellidoMaterno = txtAMaterno.Text;
            }
            
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BindingUsuario();
        }

        private void txtAPaterno_TextChanged(object sender, EventArgs e)
        {
            BindingUsuario();
        }

        private void txtAMaterno_TextChanged(object sender, EventArgs e)
        {
            BindingUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAMaterno_Click(object sender, EventArgs e)
        {

        }

        private void lblAPaterno_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
