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

namespace AppGimnasio
{
    public partial class Menu : Form
    {
        ContratoDao contratoDao;
        public Menu()
        {
            InitializeComponent();
            contratoDao=new ContratoDao();
            CargarGrilla();
        }

        private void CargarGrilla()
        {

            DataTable dataTable = contratoDao.ConsultarBD("SELECT dni, nombre, apellido, fechaInicio, m.membresia from Clientes c, Membresias m" +
                                                                            " where c.membresia = m.id_membresia");
            dvgClientes.Rows.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dvgClientes.Rows.Add(dataTable.Rows[i]["dni"], dataTable.Rows[i]["nombre"], dataTable.Rows[i]["apellido"], dataTable.Rows[i]["membresia"], dataTable.Rows[i]["fechaInicio"]);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir del formulario?"
                                , "Saliendo"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button2)
                                == DialogResult.Yes) ;
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo ventanaNuevo = new Nuevo();
            ventanaNuevo.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
