using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Taller
{
    public partial class Login : Form
    {
        Crud paso = new Crud();
       
        public bool autenticar = false;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text== "Introduce Your User")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text== "")
            {
                txtUser.Text = "Introduce Your User";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Introduce Your Pass")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Introduce Your Pass";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterUSer add = new RegisterUSer();
            add.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrogetPass ps = new FrogetPass();
            ps.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cadena;
            cadena = txtPass.Text;
            Home hom = new Home();
            string buscar = "SELECT * FROM Users WHERE username= '" + txtUser.Text + "' AND pass='" + cadena + "'";
            paso.ConsultarTextto(buscar);
            if (paso.dr.Read())
            {
                MessageBox.Show("Bienvenido");
                autenticar = true;
                hom.Show();
                this.Hide();
                /* En el metodo main como es C# tenes que hacer unas config 
                 pero ya las hice alli las revisas xd, aqui dirctamente si cerras
                 el form te manda todo a la M*/
               
            }
            else
            {
                MessageBox.Show("Error en el user o pass");
                limpiar();
                paso.conexion.Close();
                   

            }
            
        }
        public void limpiar()
        {
            txtUser.Text = "";
            txtPass.Text = "";
        }
    }
}
