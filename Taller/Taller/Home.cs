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
    public partial class Home : Form
    {
        Crud paso = new Crud();
        public Home()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;
            panelPlaylistSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubMenu);
        }

        #region RegisterMenu
        private void btnMVehicles_Click(object sender, EventArgs e)
        {
            openChildForm(new AddVehicles());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnMClients_Click(object sender, EventArgs e)
        {
            openChildForm(new AddClients());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnMLabors_Click(object sender, EventArgs e)
        {
            openChildForm(new AddLabors());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnMParts_Click(object sender, EventArgs e)
        {
            openChildForm(new AddParts());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnMExtrainf_Click(object sender, EventArgs e)
        {
            openChildForm(new AddExtraInf());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPlaylistSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new NewSearcher());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string filename = "instrucciones.pdf";
            System.Diagnostics.Process.Start(filename);
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2IIMGTL;Initial Catalog=PruebaTaller;Integrated Security=True");
        DataTable datos = new DataTable();
        void autoCompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Vehicle", conexion);
            adaptador.Fill(datos);

            for (int i = 0;  i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["licenseplate_vehicle"].ToString()); 
            }
          
           
            
        }
        
        private void Home_Load(object sender, EventArgs e)
        {

            
        }
       

       
    }
}
