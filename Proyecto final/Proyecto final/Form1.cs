namespace Proyecto_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.Abrir();
                MessageBox.Show("Conexión exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Conexion.Cerrar();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
