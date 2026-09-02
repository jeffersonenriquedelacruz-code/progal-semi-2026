using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impuestos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
            if (this.Controls.ContainsKey("button1"))
            {
                this.button1.Click += new System.EventHandler(this.button1_Click);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string textoEntrada = textBox1.Text.Replace(',', '.');

            
            if (decimal.TryParse(textoEntrada, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal monto))
            {
                decimal valorAPagar = 0;

                
                if (monto > 1000.01m)
                {
                    decimal excedente = monto - 1000.01m;
                    valorAPagar = ((excedente / 1000m) * 3m) + 3m;
                }
                else
                {
                    valorAPagar = 3m;
                }

                // Redondear a 2 decimales 
                valorAPagar = Math.Round(valorAPagar, 2, MidpointRounding.AwayFromZero);

                label2.Text = $"Resultado: ${valorAPagar:F2}";
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un monto numérico válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}