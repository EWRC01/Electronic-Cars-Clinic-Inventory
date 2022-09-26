using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller
{
    public partial class SearchFast : Form
    {
        LoadCombo placas = new LoadCombo();
        public SearchFast()
        {
            InitializeComponent();
            //autoCompletar();
        }
        Crud paso = new Crud();

        private void SearchFast_Load(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT V.licenseplate_vehicle, year_vehicle, make_vehicle, model_vehicle, odometer_vehicle, name_client, date_client, phone_client, addres_client, city_client, state_client  FROM Vehicle V, Client C WHERE V.licenseplate_vehicle LIKE '%" + textBox2.Text + "%' AND V.licenseplate_vehicle=C.licenseplate_vehicle", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Extrainformation WHERE licenseplate_vehicle LIKE '%" + textBox2.Text + "%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView2.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Parts WHERE licenseplate_vehicle LIKE '%" + textBox2.Text + "%' AND dateVehicle LIKE '%"+dateTimePicker2.Text+"%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView3.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Labors WHERE licenseplate_vehicle LIKE '%" + textBox2.Text + "%' AND dateVehicle LIKE '%"+dateTimePicker2.Text+"%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView4.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string save = "INSERT INTO Labors (licenseplate_vehicle, dateVehicle, laborName, laborPrice) VALUES ('" + cmbVehicle.Text + "', '" + dtpDate.Text + "',  '" + txtLabor.Text + "', '" + txtPrice1.Text + "')";
            if (paso.Operacion(save))
            {
                MessageBox.Show("El registro se guardo con exito");
                txtLabor.Text = "";
                txtPrice1.Text = "";
                dtpDate.Value = DateTime.Today;
            }
            else
            {
                MessageBox.Show("Error al guardar el registro");
            }
        }

        private void SearchFast_Load_1(object sender, EventArgs e)
        {
            cmbVehicle.DataSource = placas.CargarCombo();

            cmbVehicle.DisplayMember = "licenseplate_vehicle";
        }




        //SqlConnection conexion = new SqlConnection("Data  Source=DESKTOP-2IIMGTL;Initial Catalog=PruebaTaller;Integrated Security=True");
        //DataTable datos = new DataTable();
        //void autoCompletar()
        //{
        //    AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
        //    SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Vehicle", conexion);
        //    adaptador.Fill(datos);

        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        lista.Add(datos.Rows[i]["licenseplate_vehicle"].ToString());
        //    }

        //    textBox2.AutoCompleteCustomSource = lista;

        //}
    }
}
