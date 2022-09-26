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

namespace Taller
{
    public partial class Form3 : Form
    {

        Crud paso = new Crud();
        LoadCombo placas = new LoadCombo();
        public Form3()
        {
            InitializeComponent();
            cargarPlaca();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

           
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vehicle WHERE licenseplate_vehicle LIKE '" + cmbVehicle.Text + "%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Client WHERE licenseplate_vehicle LIKE '" + cmbVehicle.Text + "%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM extrainformation WHERE licenseplate_vehicle LIKE '" + cmbVehicle.Text + "%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Parts WHERE licenseplate_vehicle LIKE '" + cmbVehicle.Text + "%' AND dateVehicle LIKE '"+cmbFecha.Text+"%'", paso.conexion);
                

                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Labors WHERE licenseplate_vehicle LIKE '" + cmbVehicle.Text + "%' AND dateVehicle LIKE '" + cmbLabors.Text + "%'", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbVehicle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cmbFecha.DataSource = placas.CargarComboFecha();
            //cmbFecha.DisplayMember = "dateVehicle";
        }

        public void CargarFecha(string licenseplate_vehicle)
        {
            paso.conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT dateVehicle, nameParts FROM Parts WHERE licenseplate_vehicle= @licenseplate_vehicle", paso.conexion);
            cmd.Parameters.AddWithValue("licenseplate_vehicle", licenseplate_vehicle);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            paso.cerrarConn();

            DataRow dr = dt.NewRow();
            dr["dateVehicle"] = "Select a date";
            dt.Rows.InsertAt(dr, 0);

            cmbFecha.ValueMember = "dateVehicle";
            cmbFecha.DisplayMember = "dateVehicle";
            cmbFecha.DataSource = dt;

            
        }

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedValue.ToString() != null)
            {
                string licenseplate_vehicle = cmbVehicle.SelectedValue.ToString();
                CargarFecha(licenseplate_vehicle);
                CargarFechaLabors(licenseplate_vehicle);
            }
        }
        public void cargarPlaca()
        {

            paso.conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT licenseplate_vehicle FROM Vehicle", paso.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            paso.cerrarConn();

            DataRow fila = dt.NewRow();
            fila["licenseplate_vehicle"] = "Select a Vehicle";
            dt.Rows.InsertAt(fila, 0);


            cmbVehicle.ValueMember = "licenseplate_vehicle";
            cmbVehicle.DisplayMember = "licenseplate_vehicle";
            cmbVehicle.DataSource = dt;
        }

        public void CargarFechaLabors(string licenseplate_vehicle)
        {
            paso.conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT dateVehicle FROM Labors WHERE licenseplate_vehicle= @licenseplate_vehicle", paso.conexion);
            cmd.Parameters.AddWithValue("licenseplate_vehicle", licenseplate_vehicle);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            paso.cerrarConn();

            DataRow dr = dt.NewRow();
            dr["dateVehicle"] = "Select a date";
            dt.Rows.InsertAt(dr, 0);

            cmbLabors.ValueMember = "dateVehicle";
            cmbLabors.DisplayMember = "dateVehicle";
            cmbLabors.DataSource = dt;


        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            cmbFecha.Visible = true;
            cmbLabors.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmbFecha.Visible = false;
            cmbLabors.Visible = true;
        }
    }
}
