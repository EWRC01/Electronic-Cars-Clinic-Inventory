using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Taller
{
    public partial class AddLabors : Form
    {
        Crud paso = new Crud();
        LoadCombo placas = new LoadCombo();
        public AddLabors()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int i = 0;

        private void AddLabors_Load(object sender, EventArgs e)
        {
            cmbVehicle.DataSource = placas.CargarCombo();

            cmbVehicle.DisplayMember = "licenseplate_vehicle";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string save = "INSERT INTO Labors (licenseplate_vehicle, dateVehicle, laborName, laborPrice) VALUES ('" + cmbVehicle.Text + "', '" + dtpDate.Text + "',  '" + txtLabor.Text + "', '" + txtPrice.Text + "')";
            if (paso.Operacion(save))
            {
                MessageBox.Show("El registro se guardo con exito");
                txtLabor.Text = "";
                txtPrice.Text = "";
                dtpDate.Value = DateTime.Today;
            }
            else
            {
                MessageBox.Show("Error al guardar el registro");
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtLabor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
