using System;
using System.Windows.Forms;
using Entidades.ControlEscolarApp;
using LogicaNegocio.ControlEscolarApp;

namespace ControlEscolarApp
{
    public partial class VistaAlu : Form
    {
        AlumnoManejador _alumnoManejador;
        Alumnos _alumnos;
        public VistaAlu()
        {
            InitializeComponent();
            _alumnoManejador = new AlumnoManejador();
            _alumnos = new Alumnos();
        }

        private void VistaAlu_Load(object sender, EventArgs e)
        {
            BuscarAlum("");
        }
        private void BuscarAlum(string filtro)
        {
            dgvUsuarios.DataSource = _alumnoManejador.ObtenerListaAlu(filtro);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro Que Desea Eliminar El Regitro Seleccionado", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EliminarAlu();
                    BuscarAlum("");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EliminarAlu()
        {
            string control = dgvUsuarios.CurrentRow.Cells["Numero_control"].Value.ToString();
            _alumnoManejador.EliminarAlum(control);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AlumnosModal AluModal = new AlumnosModal();
            AluModal.ShowDialog();
            BuscarAlum("");
        }

        private void BindingAlumno()
        {
            _alumnos.Numero_control = dgvUsuarios.CurrentRow.Cells["Numero_control"].Value.ToString();
            _alumnos.Nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            _alumnos.Apellidop = dgvUsuarios.CurrentRow.Cells["apellidop"].Value.ToString();
            _alumnos.Apellidom = dgvUsuarios.CurrentRow.Cells["apellidom"].Value.ToString();
            _alumnos.Sexo = dgvUsuarios.CurrentRow.Cells["Sexo"].Value.ToString();
            _alumnos.Nacimiento = dgvUsuarios.CurrentRow.Cells["Nacimiento"].Value.ToString();
            _alumnos.Correo = dgvUsuarios.CurrentRow.Cells["Correo"].Value.ToString();
            _alumnos.Telefono = dgvUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();
            _alumnos.Estado = dgvUsuarios.CurrentRow.Cells["Estado"].Value.ToString();
            _alumnos.Municipio = dgvUsuarios.CurrentRow.Cells["Municipio"].Value.ToString();
            _alumnos.Apellidom = dgvUsuarios.CurrentRow.Cells["Domicilio"].Value.ToString();

        }

        private void dgvUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingAlumno();
            AlumnosModal alumnomoldal = new AlumnosModal(_alumnos);
            alumnomoldal.ShowDialog();
            BuscarAlum("");
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingAlumno();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingAlumno();
            AlumnosModal alumnomoldal = new AlumnosModal(_alumnos);
            alumnomoldal.ShowDialog();
            BuscarAlum("");
        }
    }
}
