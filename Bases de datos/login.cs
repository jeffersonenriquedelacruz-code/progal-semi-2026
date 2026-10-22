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

namespace Nuevarama
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        // Método unificado para validar al presionar Enter en cualquier caja de texto
        private void RealizarLogin()
        {
            string usuario = textBox1.Text.Trim();
            string clave = textBox2.Text;

            // Consulta en tu tabla de usuarios
            string query = $"SELECT COUNT(*) FROM usuarios_usss128826 WHERE usuario = '{usuario}' AND clave = '{clave}'";

            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_academica.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand comando = new SqlCommand(query, conexion);

            try
            {
                conexion.Open();
                int existe = (int)comando.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("¡Acceso concedido!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre el formulario principal y oculta el login
                    frm_usuario formUsuario = new frm_usuario();
                    this.Hide();
                    formUsuario.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o no estás registrado.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RealizarLogin();
            }
        }

        // Por si presionas Enter desde la caja de usuario también
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RealizarLogin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Por si acaso llegas a usar el botón en algún momento, también ejecuta el login
            RealizarLogin();
        }
    }
}