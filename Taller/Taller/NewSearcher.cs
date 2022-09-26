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
    public partial class NewSearcher : Form
    {
        Crud paso = new Crud();
        LoadCombo placas = new LoadCombo();
        public NewSearcher()
        {
            InitializeComponent();
            llenadoDeDatos();
        }

        public void llenadoDeDatos()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT V.licenseplate_vehicle, year_vehicle, make_vehicle, model_vehicle, odometer_vehicle, name_client, date_client, phone_client, addres_client, city_client, state_client, comments, imageupload1, imageupload2, imageupload3, imageupload4, imageupload5, imageupload6  FROM Vehicle V, Client C, Extrainformation E WHERE V.licenseplate_vehicle=C.licenseplate_vehicle AND V.licenseplate_vehicle=E.licenseplate_vehicle", paso.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            MessageBox.Show("Se ha presionado una celda");
       
                    
        }

        private void NewSearcher_Load(object sender, EventArgs e)
        {
            cmbVehicle.DataSource = placas.CargarCombo();

            cmbVehicle.DisplayMember = "licenseplate_vehicle";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LllenadodeFroms n = new LllenadodeFroms();
            n.Show();
            n.txtLicenseplate.Text = cmbVehicle.Text;
            string sql = "select * from Vehicle where licenseplate_vehicle='" + n.txtLicenseplate.Text + "'";
            paso.ConsultarTextto(sql);
            if(paso.dr.Read())
            {
                n.txtYear.Text = Convert.ToString(paso.dr[1]);
                n.txtMake.Text = Convert.ToString(paso.dr[2]);
                n.txtModel.Text = Convert.ToString(paso.dr[3]);
                n.txtOdometer.Text = Convert.ToString(paso.dr[4]);
                paso.dr.Close();
                paso.cerrarConn();

            }
            string sql1 = "select * from Client where licenseplate_vehicle='" + n.txtLicenseplate.Text + "'";
            paso.ConsultarTextto(sql1);
            if(paso.dr.Read())
            {
                n.txtName.Text = Convert.ToString(paso.dr[2]);
                n.txtDateClient.Text = Convert.ToString(paso.dr[3]);
                n.txtPhone.Text = Convert.ToString(paso.dr[4]);
                n.txtAddress.Text = Convert.ToString(paso.dr[5]);
                n.txtCity.Text = Convert.ToString(paso.dr[6]);
                n.txtState.Text = Convert.ToString(paso.dr[7]);
                paso.dr.Close();
                paso.cerrarConn();
            }

            string sql2 = "select *  from Extrainformation where licenseplate_vehicle='" + n.txtLicenseplate.Text + "'";
            paso.ConsultarTextto(sql2);
            if(paso.dr.Read())
            {
                n.txtComments.Text = Convert.ToString(paso.dr[2]);
                paso.dr.Close();
                paso.cerrarConn();
            }

            SqlDataAdapter ds = new SqlDataAdapter("select comments from Extrainformation where licenseplate_vehicle='" +n.txtLicenseplate.Text + "'", paso.conexion);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            n.dgvComments.DataSource = dt;


        }
    }
}
