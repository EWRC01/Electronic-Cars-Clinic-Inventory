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
    public partial class RegisterUSer : Form
    {
        Crud paso = new Crud();
        public RegisterUSer()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterUSer_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Introduce Your User")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
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
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Introduce Your Pass";
                txtPass.ForeColor = Color.LightGray;
            }
            }

        private void txtLevel_Enter(object sender, EventArgs e)
        {
            if (txtLevel.Text== "Introduce Your Level")
            {
                txtLevel.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtLevel_Leave(object sender, EventArgs e)
        {
            if (txtLevel.Text=="")
            {
                txtLevel.Text = "Introduce Your Level";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Introduce Your Name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.LightGray;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Introduce Your Name";
                txtName.ForeColor = Color.LightGray;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show("Hay un espacio en blanco");
            }
            else
            {
                string validacion = ("SELECT username FROM Users WHERE username='" + txtUser.Text + "'");
                paso.ConsultarTextto(validacion);
                if (paso.dr.Read())
                {
                    MessageBox.Show("Este usuario ya existe");
                    paso.cerrarConn();
                }
                else
                {
                    //cadena oara insertar los datos
                    string insertar = "INSERT INTO Users(username, pass, nivel, nombre) VALUES('" + txtUser.Text + "', '" + txtPass.Text + "', '" + txtLevel.Text + "', '" + txtName.Text + "')";
                    if (paso.Operacion(insertar))
                    {
                        MessageBox.Show("Registros agregados correctamente");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar los datos");
                    }
                }
            }

        }
    }

}
