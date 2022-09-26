using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller
{
    public partial class AddVehicles : Form
    {
        LoadCombo cli = new LoadCombo();
        Crud paso = new Crud();
        public AddVehicles()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string validacion = "SELECT licenseplate_vehicle FROM Vehicle WHERE licenseplate_vehicle='" + txtLicenseplate.Text + "'";
            paso.ConsultarTextto(validacion);
            if(paso.dr.Read())
            {
                MessageBox.Show("La placa que ha ingresado ya esta registrada");
                paso.cerrarConn();
            }
            else
            {
                string save = "INSERT INTO Vehicle (licenseplate_vehicle, year_vehicle, make_vehicle, model_vehicle, odometer_vehicle) VALUES ('" + txtLicenseplate.Text + "', '" + txtYear.Text + "', '" + txtMake.Text + "', '" + txtModel.Text + "', '" + txtOdometer.Text + "')";
                if (paso.Operacion(save))
                {
                    MessageBox.Show("Registro almacenado correctamente");
                    LimpiarFiels();
                }
                else
                {
                    MessageBox.Show("Error al almacenar el registro");
                }
            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string update = "UPDATE Vehicle set licenseplate_vehicle='" + txtLicenseplate.Text + "', year_vehicle='" + txtYear.Text + "', make_vehicle='" + txtMake.Text + "', model_vehicle='" + txtMake.Text + "', odometer_vehicle='" + txtOdometer.Text + "' where licenseplate_vehicle='" + txtLicenseplate.Text + "'";
            if (paso.Operacion(update))
            {
                MessageBox.Show("Registro actualizado correctamente");
                LimpiarFiels();
            }
            else
            {
                MessageBox.Show("Error al actualizar el registro");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM Vehicle Where licenseplate_vehicle='" + txtLicenseplate.Text + "'";
            if (MessageBox.Show("Esta seguro de que quiere borrar el registro", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (paso.Operacion(delete))
                {
                    MessageBox.Show("Registro eliminado con exito");
                    LimpiarFiels();

                }
                else
                    MessageBox.Show("No se pudo eliminar el registro");

            }
            else
            {
                MessageBox.Show("Redireccionando al registro vehiculos");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "SELECT * FROM Vehicle where licenseplate_vehicle= '" + txtLicenseplate.Text + "'";
            paso.ConsultarTextto(search);
            if (paso.dr.Read())
            {
                txtLicenseplate.Text = Convert.ToString(paso.dr[0]);
                txtYear.Text = Convert.ToString(paso.dr[1]);
                txtMake.Text = Convert.ToString(paso.dr[2]);
                txtModel.Text = Convert.ToString(paso.dr[3]);
                txtOdometer.Text = Convert.ToString(paso.dr[4]);
                paso.dr.Close();
                paso.cerrarConn();
            }
            else
            {
                MessageBox.Show("El vehiculo no existe");
            }

        }

        public void LimpiarFiels()
        {
            txtLicenseplate.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtOdometer.Text = "";
            txtYear.Text = "";

            txtLicenseplate.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarFiels();
        }

        private void AddVehicles_Load(object sender, EventArgs e)
        {
            txtLicenseplate.Focus();
        }
    }
}
