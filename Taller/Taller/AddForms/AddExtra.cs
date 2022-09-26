using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;





namespace Taller
{
    public partial class aggExtra : Form
    {
        Crud paso = new Crud();
        LoadCombo placas = new LoadCombo();
        public aggExtra()
        {
            InitializeComponent();
        }

        private void AddExtra_Load(object sender, EventArgs e)
        {
            cmbVehicle.DataSource = placas.CargarCombo();

            cmbVehicle.DisplayMember = "licenseplate_vehicle";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "All Files|*.*";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pic1.Image = Image.FromFile(BuscarImagen.FileName);
            }
            txtImg1.Text = BuscarImagen.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "All Files|*.*";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pic2.Image = Image.FromFile(BuscarImagen.FileName);
            }
            txtImg2.Text = BuscarImagen.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "All Files|*.*";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pic3.Image = Image.FromFile(BuscarImagen.FileName);
            }
            txtImg3.Text = BuscarImagen.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "All Files|*.*";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pic4.Image = Image.FromFile(BuscarImagen.FileName);
            }
            txtImg4.Text = BuscarImagen.FileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "All Files|*.*";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pic5.Image = Image.FromFile(BuscarImagen.FileName);
            }
            txtImg5.Text = BuscarImagen.FileName;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LimpiarBotones();
        }
        public void LimpiarBotones()
        {
            txtComments.Text = "";
            txtExtraInformation.Text = "";
            txtImg1.Text = "";
            txtImg2.Text = "";
            txtImg3.Text = "";
            txtImg4.Text = "";
            txtImg5.Text = "";
            pic1.Image.Dispose();
            pic1.Image = null;
            pic2.Image.Dispose();
            pic2.Image = null;
            pic3.Image.Dispose();
            pic3.Image = null;
            pic4.Image.Dispose();
            pic4.Image = null;
            pic5.Image.Dispose();
            pic5.Image = null;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string insertar = "INSERT INTO extrainformation (licenseplate_vehicle, recommendations, comments, imageupload, imageupload1, imageupload2, imageupload3, imageupload4) VALUES('" + cmbVehicle.Text + "', '" + txtExtraInformation.Text + "', '" + txtComments.Text + "', '" + txtImg1.Text + "', '" + txtImg2.Text + "', '" + txtImg3.Text + "', '" + txtImg4.Text + "', '" + txtImg5.Text + "')";
            if (paso.Operacion(insertar))
            {
                MessageBox.Show("Registro guardado con exito");
                LimpiarBotones();
            }
            else
            {
                MessageBox.Show("Error al guardar el registro");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string update = "UPDATE extrainformation set licenseplate_vehicle='" + cmbVehicle.Text + "', recommendations='" + txtExtraInformation.Text + "', comments='" + txtComments.Text + "', imageupload='" + txtImg1.Text + "', imageupload1='" + txtImg2.Text + "', imageupload2='" + txtImg3.Text + "', imageupload3='" + txtImg4.Text + "', imageupload4='" + txtImg5.Text + "' where licenseplate_vehicle= '" + cmbVehicle.Text + "'";
            if (paso.Operacion(update))
            {
                MessageBox.Show("Registro actualizado correctamente");
                LimpiarBotones();

            }
            else
            {
                MessageBox.Show("Error al actualizar el resgitro");
            }
      
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM extrainformation where licenseplate_vehicle='" + cmbVehicle.Text + "'";

            if (MessageBox.Show("Esta seguro de que quiere borrar el registro", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (paso.Operacion(delete))
                {
                    MessageBox.Show("Registro eliminado con exito");
                    LimpiarBotones();

                }
                else
                    MessageBox.Show("No se pudo eliminar el registro");

            }
            else
            {
                MessageBox.Show("Redireccionando al registro Extra Information");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "SELECT * FROM extrainformation WHERE licenseplate_vehicle= '" + cmbVehicle.Text + "'";
            paso.ConsultarTextto(search);
            if (paso.dr.Read())
            {
                cmbVehicle.Text = Convert.ToString(paso.dr[0]);
                txtExtraInformation.Text = Convert.ToString(paso.dr[1]);
                txtComments.Text = Convert.ToString(paso.dr[2]);
                txtImg1.Text = Convert.ToString(paso.dr[3]);
                txtImg2.Text = Convert.ToString(paso.dr[4]);
                txtImg3.Text = Convert.ToString(paso.dr[5]);
                txtImg4.Text = Convert.ToString(paso.dr[6]);
                txtImg5.Text = Convert.ToString(paso.dr[7]);
                pic1.Image = Image.FromFile(txtImg1.Text);
                pic2.Image = Image.FromFile(txtImg2.Text);
                pic3.Image = Image.FromFile(txtImg3.Text);
                pic4.Image = Image.FromFile(txtImg4.Text);
                pic5.Image = Image.FromFile(txtImg5.Text);
                paso.dr.Close();
                paso.cerrarConn();

            }
            else
            {
                MessageBox.Show("El cliente no existe");
                paso.cerrarConn();
            }
        }
    }
}
