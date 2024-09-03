using AppGimnasio.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppGimnasio
{
    public partial class Nuevo : Form
    {
        ContratoDao oBD;
        public Nuevo()
        {
            InitializeComponent();
            oBD = new ContratoDao();
            
        }

        private void CargarCombo(ComboBox cbo, string nombreTabla)
        {
            DataTable dataTable = oBD.ConsultarTabla(nombreTabla);

            cbo.DataSource = dataTable;
            cbo.DisplayMember = dataTable.Columns[1].ColumnName;
            cbo.ValueMember = dataTable.Columns[0].ColumnName;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.MinDate = DateTime.Now;
            CargarCombo(cboMembresias, "Membresias");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea cancelar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Clientes oCliente = new Clientes();
            
            oCliente.Dni = Convert.ToInt32(txtDni.Text);
            oCliente.Nombres = txtNombres.Text;
            oCliente.Apellido = txtApellido.Text;
            oCliente.Membresia = (int)cboMembresias.SelectedValue;
            oCliente.Contacto = Convert.ToInt32(txtConctacto.Text);
            oCliente.FechaIncio = dtpFechaInicio.Value;

            if (GuardarCliente(oCliente))
                MessageBox.Show("Cliente ingresado");
            else
                MessageBox.Show("Cliente NO ingresado");




        }

        public bool GuardarCliente(Clientes oCliente)
        {
            string query = "INSERT INTO Clientes (dni, nombre, apellido, membresia, fechaInicio, contacto) VALUES (@dni,@nombre,@apellido,@membresia,@fechaInicio,@contacto)";
            List<Parametro> list = new List<Parametro>();
            list.Add(new Parametro("@dni", oCliente.Dni));
            list.Add(new Parametro("@nombre", oCliente.Nombres));
            list.Add(new Parametro("@apellido", oCliente.Apellido));
            list.Add(new Parametro("@membresia", oCliente.Membresia));
            list.Add(new Parametro("@fechaInicio", oCliente.FechaIncio));
            list.Add(new Parametro("@contacto", oCliente.Contacto));

            return oBD.ActualizarBD(query, list) == 1;



        }
    }
}
