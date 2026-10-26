using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_final
{
    public partial class frmEmpleoLocal : Form
    {
        public frmEmpleoLocal()
        {
            InitializeComponent();
            // Ya no creamos el TextBox aquí porque se carga automáticamente desde el Diseñador visual.
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Cambia 'textBox1' por el nombre exacto que tiene tu TextBox en el Diseñador visual
            string filtro = txtBusqueda.Text.Trim();

            try
            {
                // 1. Abrimos la conexión con tu clase Conexion existente
                Conexion.Abrir();

                // 2. Aquí puedes colocar tu consulta SQL más adelante
                MessageBox.Show("¡Conexión y búsqueda exitosas!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 3. Cerramos la conexión de forma segura
                Conexion.Cerrar();
            }
        }

        private void frmEmpleoLocal_Load(object sender, EventArgs e)
        {

        }
    }
}