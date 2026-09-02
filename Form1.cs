using System;
using System.Windows.Forms;

namespace Calculadora_de_costos_por_metro_de_agua
{
    public partial class Form1 : Form
    {
        // Se define una tarifa promedio fija por m³ (USD)
        private const double TARIFA_METRO = 0.21;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar que el usuario haya ingresado un número válido
            if (double.TryParse(textBox1.Text, out double metros))
            {
                if (metros < 0)
                {
                    MessageBox.Show("Ingresa una cantidad de metros válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cálculo del total
                double totalPagar = metros * TARIFA_METRO;

                // Si la tarifa mínima de ANDA es $2.29 para <= 10 m3, puedes aplicar la lógica de cobro mínimo:
                if (totalPagar < 2.29 && metros > 0)
                {
                    totalPagar = 2.29;
                }

                // Mostrar resultado en la etiqueta
                label2.Text = $"Valor a pagar: ${totalPagar:F2} USD";
            }
            else
            {
                MessageBox.Show("Por favor ingresa un número válido en los metros utilizados.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}