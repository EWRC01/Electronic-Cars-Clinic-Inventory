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
    public partial class AddClients : Form
    {
        Crud paso = new Crud();
        LoadCombo placas = new LoadCombo();
        public AddClients()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            
            
                string save = "INSERT INTO Client ( licenseplate_vehicle, idClient, name_client, date_client, phone_client, addres_client, city_client, state_client) VALUES ('" + cmbVehicle.Text + "','" + txtidClient.Text + "', '" + txtName.Text + "', '" + dtpDate.Text + "', '" + txtPhone.Text + "', '" + txtAddress.Text + "', '" + txtCity.Text + "', '" + txtState.Text + "')";

                if (paso.Operacion(save))
                {
                    MessageBox.Show("Registro almacenado correctamente");
                    LimpiarFiels();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al almacenar el registro");
                }
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string update = "UPDATE  Client set licenseplate_vehicle='" + cmbVehicle.Text + "', idClient= '" + txtidClient.Text + "', name_client= '" + txtName.Text + "', date_client='" + dtpDate.Value + "', phone_client='" + txtPhone.Text + "', addres_client='" + txtAddress.Text + "', city_client='" + txtCity.Text + "', state_client='" + txtState.Text + "' where licenseplate_vehicle='" + cmbVehicle.Text + "'";
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
            string delete = "DELETE FROM Client Where licenseplate_vehicle= '" + cmbVehicle.Text + "'";

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
                MessageBox.Show("Redireccionando al registro clientes");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "SELECT * FROM Client WHERE licenseplate_vehicle='" + cmbVehicle.Text + "'";
            paso.ConsultarTextto(search);
            if (paso.dr.Read())
            {
                txtidClient.Text = Convert.ToString(paso.dr[0]);
                cmbVehicle.Text = Convert.ToString(paso.dr[1]);
                txtName.Text = Convert.ToString(paso.dr[2]);
                dtpDate.Value = Convert.ToDateTime(paso.dr[3]);
                txtPhone.Text = Convert.ToString(paso.dr[4]);
                txtAddress.Text = Convert.ToString(paso.dr[5]);
                txtCity.Text = Convert.ToString(paso.dr[6]);
                txtState.Text = Convert.ToString(paso.dr[7]);

                paso.dr.Close();
                paso.cerrarConn();

            }
            else
            {
                MessageBox.Show("El Cliente no existe");
                paso.cerrarConn();
            }

        }

        public void LimpiarFiels()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtPhone.Text = "";
            txtState.Text = "";
            txtidClient.Text = "";
            dtpDate.Value = DateTime.Today;

            numerodeRegistro();
            txtName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarFiels();
        }


        private void AddClients_Load(object sender, EventArgs e)
        {
            cmbVehicle.DataSource = placas.CargarCombo();

            cmbVehicle.DisplayMember = "licenseplate_vehicle";

            txtName.Focus();
            numerodeRegistro();
        }

        public void numerodeRegistro()
        {
            SqlCommand cmd;

            string query = "SELECT count(*) FROM Client";

            paso.conexion.Open();
            cmd = new SqlCommand(query, paso.conexion);


            Int32 contador = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            paso.conexion.Close();

            contador = contador + 1;
            txtidClient.Text = contador.ToString();
        }
    }
}
