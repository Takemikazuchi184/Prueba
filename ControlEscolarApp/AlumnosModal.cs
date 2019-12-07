using System;
using System.Windows.Forms;
using Entidades.ControlEscolarApp;
using LogicaNegocio.ControlEscolarApp;

namespace ControlEscolarApp
{
    public partial class AlumnosModal : Form
    {
        private AlumnoManejador _AlumnoManejador;
        private Alumnos _alumnos;
        private EstadoManejador _EstadoManejador;
        private Estados _estados;
        private Municipios _muni;
        private MunicipioManejador _munimanejador;
        private bool _isEnabledBinding = false;
        

        public AlumnosModal()
        {
            InitializeComponent();
            _AlumnoManejador = new AlumnoManejador();
            _alumnos = new Alumnos();
            _EstadoManejador = new EstadoManejador();
            _estados = new Estados();
            _muni = new Municipios();
            _munimanejador = new MunicipioManejador();
            //combos();
            _isEnabledBinding = true;
            BindingAlumnos();

        }

        public AlumnosModal(Alumnos alumno)
        {
            
            _AlumnoManejador = new AlumnoManejador();
            _alumnos = new Alumnos();
            _EstadoManejador = new EstadoManejador();
            _estados = new Estados();
            _muni = new Municipios();
            _munimanejador = new MunicipioManejador();
            _alumnos = alumno;
            InitializeComponent();
            BindingAluReload();
            _isEnabledBinding = true;
           

        }

        private void BindingAlumnos()
        {
            if (_isEnabledBinding)
            {
                if (_alumnos.Numero_control == "")
                {
                   _alumnos.Numero_control = "";

                }
                _alumnos.Numero_control = txtControl.Text;
                _alumnos.Nombre = txtNombre.Text;
                _alumnos.Apellidop = txtAPaterno.Text;
                _alumnos.Apellidom = txtAMaterno.Text;
                _alumnos.Sexo = txtSex.Text;
                _alumnos.Nacimiento = txtNaci.Text;
                _alumnos.Correo = txtMail.Text;
                _alumnos.Telefono = txtCel.Text;
                //_alumnos.Estado = txtEstado.Text;
                _alumnos.Estado = comboBox1.Text;
                //_alumnos.Municipio = txtMuni.Text;
                _alumnos.Municipio = comboBox2.Text;
                _alumnos.Domicilio = txtDomi.Text;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BindingAluReload()
        {
            txtControl.Text = _alumnos.Numero_control;
            txtNombre.Text = _alumnos.Nombre;
            txtAPaterno.Text = _alumnos.Apellidop;
            txtAMaterno.Text = _alumnos.Apellidom;
            txtSex.Text = _alumnos.Sexo;
            txtMail.Text = _alumnos.Correo;
            txtCel.Text = _alumnos.Telefono;
            txtNaci.Text = _alumnos.Nacimiento;
            comboBox1.Text = _alumnos.Estado;
            comboBox2.Text = _alumnos.Municipio;
            txtDomi.Text = _alumnos.Domicilio;


        }






        private void btnGuardar_Click(object sender, EventArgs e)
        {
                BindingAlumnos();  
                GuardarAlumno();
                this.Close();
           
        }

        private void GuardarAlumno()
        {
            _AlumnoManejador.GuardarAlum(_alumnos);
        }

        /*private void BuscarEstados(string filtro)
        {
            comboBox1.DataSource  = _EstadoManejador.ObtenerListaEst(filtro);
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "codigo";
           
            
        }*/
        /*private void BuscarMuni()
        {
            
            comboBox2.DataSource = _munimanejador.ObtenerListaMuni(comboBox1.SelectedValue.ToString());
            comboBox2.ValueMember = "nombre";


        }*/

        private void combos()
        {
            comboBox1.DataSource = _EstadoManejador.ObtenerListaEst();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "codigo";

            comboBox2.DataSource = _munimanejador.ObtenerListaMuni(comboBox1.SelectedValue.ToString());
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";
            
        }
        private void AlumnosModal_Load(object sender, EventArgs e)
        {
            combos();
        }

        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtAPaterno_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtAMaterno_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtCel_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtNaci_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtMuni_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void txtDomi_TextChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingAlumnos();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = _munimanejador.ObtenerListaMuni(comboBox1.SelectedValue.ToString());
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "id";
        }
    }
}
