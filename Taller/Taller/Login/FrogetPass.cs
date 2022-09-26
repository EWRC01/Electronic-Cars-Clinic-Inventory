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
    public partial class FrogetPass : Form
    {
        Crud paso = new Crud();
        public FrogetPass()
        {
            InitializeComponent();

        }

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

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "Introduce Your New Pass")
            {
                txtNewPass.Text = "";
                txtNewPass.ForeColor = Color.LightGray;
            }
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "")
            {
                txtNewPass.Text = "Introduce Your New Pass";
                txtNewPass.ForeColor = Color.LightGray;
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrogetPass_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show("Por favor ingrese un usuario");
            }
            else
            {
                string validacion= ("SELECT username FROM Users WHERE username = '"+txtUser.Text+"'");
                paso.ConsultarTextto(validacion);
                if(paso.dr.Read())
                {
                    string update=("UPDATE Users set pass= '"+txtNewPass.Text+"' WHERE username='"+txtUser.Text+"'");
                    if (paso.Operacion(update))
                    {
                        MessageBox.Show("Pass cambiada correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al cambiar la pass");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                    paso.cerrarConn();
                }

            }
        }
    }
}
