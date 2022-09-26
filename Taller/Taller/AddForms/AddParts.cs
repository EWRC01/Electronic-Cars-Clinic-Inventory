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
    public partial class AddParts : Form
    {
        Crud paso = new Crud();
        LoadCombo placas = new LoadCombo();
        public AddParts()
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
            string save = "INSERT INTO Parts (licenseplate_vehicle, dateVehicle, quantityParts, nameParts, priceParts) VALUES ('" + cmbVehicle.Text + "', '" + dtpDate.Text + "', '" + txtQty.Text + "', '" + txtParts.Text + "', '" + txtPrice.Text + "')";
            if (paso.Operacion(save))
            {
                MessageBox.Show("Registro almacenado correctamente");
                txtQty.Text = "";
                txtParts.Text = "";
                txtPrice.Text = "";
                dtpDate.Value = DateTime.Today;
            }
            else
            {
                MessageBox.Show("Error al almaceanr el registro");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtParts_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
